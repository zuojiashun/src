﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using Common;

namespace GX.Net
{
	/// <summary>
	/// 消息注册分发器
	/// </summary>
	public class MessageDispatcher<T> : IEnumerable<Type>
	{
		#region class MessageInvoker
		private abstract class MessageInvoker
		{
			class Invoker<TMessage> : MessageInvoker
				where TMessage : T
			{
				private Func<TMessage, IEnumerator> action;

				public override object Target { get { return action.Target; } }
				public override Type MessageType { get { return typeof(TMessage); } }

				public Invoker(Func<TMessage, IEnumerator> action)
				{
					this.action = action;
				}

				public Invoker(MethodInfo methodInfo, object target)
				{
					if (methodInfo.ReturnType == typeof(void))
					{
						this.action = new Func<TMessage, IEnumerator>(m =>
						{
							var act = (Action<TMessage>)methodInfo.CreateDelegate(typeof(Action<TMessage>), target);
							act(m);
							return null;
						});
					}
					else
					{
						this.action = (Func<TMessage, IEnumerator>)methodInfo.CreateDelegate(typeof(Func<TMessage, IEnumerator>), target);
					}
				}

				public override IEnumerator Invoke(T message)
				{
					return this.action((TMessage)message);
				}

				public override string ToString()
				{
					return action.GetMethodInfo().ToString();
				}
			}

			public abstract object Target { get; }
			public abstract Type MessageType { get; }
			public abstract IEnumerator Invoke(T message);

			public static MessageInvoker Create(MethodInfo method, object target)
			{
				return Activator.CreateInstance(
					typeof(MessageDispatcher<>.MessageInvoker.Invoker<>).MakeGenericType(typeof(T), GetMessageType(method)),
					method, target) as MessageInvoker;
			}

			/// <summary>
			/// 根据消息响应函数，得到其可以处理的消息类型
			/// </summary>
			private static Type GetMessageType(MethodInfo method)
			{
				var parameters = method.GetParameters();
				Debug.Assert(parameters.Count() == 1);
#if !UNITY_WINRT || UNITY_EDITOR
				Debug.Assert(typeof(T).IsAssignableFrom(parameters[0].ParameterType));
#endif
				return method.GetParameters()[0].ParameterType;
			}
		}
		#endregion

		private readonly Dictionary<Type, MessageInvoker> items = new Dictionary<Type, MessageInvoker>();

		/// <summary>
		/// 将消息发送到对应的接收者
		/// </summary>
		/// <param name="message"></param>
		/// <param name="result">消息接收者处理消息后的返回值</param>
		/// <returns>是否有对应的消息接收者并进行了分发</returns>
		public bool Dispatch(T message, out IEnumerator result)
		{
			MessageInvoker invoker;
			if (items.TryGetValue(message.GetType(), out invoker))
			{
				result = invoker.Invoke(message);
				return true;
			}
			else
			{
				result = null;
				return false;
			}
		}

		#region 消息响应注册

		/// <summary>
		/// 静态消息响应函数
		/// </summary>
		public void StaticRegister(bool wait = false)
		{
            //if(wait)
            //    StaticRegisterAsync().Wait();
            //else
            //    Singleton.Instance.StartCoroutine(StaticRegisterAsync());
		}

		/// <summary>
		/// 静态消息响应函数
		/// </summary>
		public IEnumerator StaticRegisterAsync()
		{
#if UNITY_EDITOR
			var watch = new System.Diagnostics.Stopwatch();
			watch.Start();
#endif
			yield return null;
			foreach (var method in ExecuteAttribute.GetStaticExecuteMethod(Reflection.GetExecutingAssembly()))
			{
				RegisterMethod(method);
				yield return null;
			}
#if UNITY_EDITOR
			watch.Stop();
			UnityEngine.Debug.Log(string.Format("MessageDispatcher.StaticRegister: {0}s", watch.Elapsed.TotalSeconds));
#endif
		}

		/// <summary>
		/// 注册对象的消息响应。
		/// 请及时调用UnRegister以取消注册，否则<paramref name="target"/>对象将不会被GC！
		/// </summary>
		public void Register(object target)
		{
			foreach (var method in ExecuteAttribute.GetInstanceExecuteMethod(target.GetType()))
			{
				RegisterMethod(method, target);
			}
		}

		public bool RegisterMethod(MethodInfo method, object target = null)
		{
#if UNITY_EDITOR && !GX_UNITTEST
			if (IsValid(method) == false)
				UnityEngine.Debug.LogWarning(string.Format("无法兼容的函数签名: {0}", method));
#endif
			var invoker = MessageInvoker.Create(method, target);
#if UNITY_EDITOR
			if (items.ContainsKey(invoker.MessageType))
				UnityEngine.Debug.LogWarning(string.Format("消息类型重复注册并覆盖: {0}", invoker.MessageType));
#endif
			items[invoker.MessageType] = invoker;
			return true;
		}

		/// <summary>
		/// 取消对象的消息响应注册
		/// </summary>
		/// <param name="target"></param>
		public void UnRegister(object target)
		{
			var keys = (from pair in items where pair.Value.Target == target select pair.Key).ToList();
			keys.ForEach(k => items.Remove(k));
		}

		#endregion

		public static bool IsValid(MethodInfo method)
		{
			if (method == null)
				return false;
			var param = method.GetParameters();
			// 消息响应函数参数个数判断
			if (param.Length != 1)
				return false;
			// 消息响应函数参数类型判断
			if (Common.Reflection.IsAssignableFrom(typeof(T), param[0].ParameterType) == false)
				return false;
			// 消息响应函数参数返回类型判断
			if (method.ReturnType != typeof(void) && method.ReturnType != typeof(IEnumerator))
				return false;
			return true;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var invoker in items.Values)
				sb.AppendLine(invoker.ToString());
			return sb.ToString();
		}

		#region IEnumerable<Type> 成员

		public IEnumerator<Type> GetEnumerator()
		{
			foreach (var t in this.items.Keys)
				yield return t;
		}

		#endregion

		#region IEnumerable 成员

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion
	}
}
