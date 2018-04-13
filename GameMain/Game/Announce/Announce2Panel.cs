﻿using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
partial class Announce2Panel : UIPanelBase
{
    table.Trailerdatabase m_Trailerdata = null;
    uint m_nItemID = 0;

    protected override void OnLoading()
    {
        base.OnLoading();
        UIEventListener.Get(m_spriteEx_btnget.gameObject).onClick = onClick_Btnget_Btn;
        m_label_btnLabel.overflowMethod = UILabel.Overflow.ResizeFreely;
        AddCreator(m_sprite_item.transform);
    }

    protected override void OnShow(object data)
    {
        base.OnShow(data);
        m_Trailerdata = null;
        m_nItemID = 0;
        if (data is table.Trailerdatabase)
        {
            m_Trailerdata = (table.Trailerdatabase)data;
            ShowUI();
        }
    }

    void OnClickItem(GameObject go)
    {
        if (m_nItemID != 0)
        {
            TipsManager.Instance.ShowItemTips(m_nItemID, m_sprite_item.gameObject, false);
        }
    }

    void ShowUI()
    {
        if (m_Trailerdata == null)
        {
            return;
        }
        m_lst_UIItemRewardDatas.Clear();
        m_label_title.text = m_Trailerdata.strTitle;
        m_label_desc.text = m_Trailerdata.strDesc;
        if (string.IsNullOrEmpty(m_Trailerdata.strJobItem) == false)
        {
            string[] strJobItem = m_Trailerdata.strJobItem.Split(';');
            int job = MainPlayerHelper.GetMainPlayerJob();
            if (strJobItem.Length >= job && job>0)
            {
                string[] strItem = strJobItem[job -1].Split('_');
                if (strItem.Length == 2)
                {
                    uint itemId = uint.Parse(strItem[0]);
                    uint itemNum = uint.Parse(strItem[1]);

                    m_nItemID = itemId;
                    m_lst_UIItemRewardDatas.Add(new UIItemRewardData()
                    {
                        itemID = itemId,
                        num = itemNum,
                    });
                }
            }
        }
        else if (string.IsNullOrEmpty(m_Trailerdata.strItem) == false)
        {
            string[] strItem = m_Trailerdata.strItem.Split('_');
            if (strItem.Length == 2)
            {
                uint itemId = uint.Parse(strItem[0]);
                uint itemNum = uint.Parse(strItem[1]);
                
                m_nItemID = itemId;
                m_lst_UIItemRewardDatas.Add(new UIItemRewardData()
                {
                    itemID = itemId,
                    num = itemNum,
                });
            }
        }
        m_ctor_UIItemRewardCreator.CreateGrids(m_lst_UIItemRewardDatas.Count);

        FunctionPushManager manager = DataManager.Manager<FunctionPushManager>();
        UIParticleWidget p = m_spriteEx_btnget.GetComponent<UIParticleWidget>();
        if (p == null)
        {
            p = m_spriteEx_btnget.gameObject.AddComponent<UIParticleWidget>();
            p.depth = 20;
        }

        if (manager.CanOpen(m_Trailerdata))
        {
            m_label_conditionDesc.text = ColorManager.GetColorString(ColorType.JZRY_Green, (string.Format("{0}", m_Trailerdata.strCondidtionDesc)));
            m_label_btnLabel.text = "领取奖励";
            m_spriteEx_btnget.ChangeSprite(2);

           
            if (p != null)
            {
                p.SetDimensions(200, 54);
                p.ReleaseParticle();
                p.AddRoundParticle();
            }
        }
        else
        {
            if (p != null)
            {
                p.ReleaseParticle();
            }
            
            
            m_label_btnLabel.text = "前往升级";
            m_spriteEx_btnget.ChangeSprite(1);

            string[] strcondition = m_Trailerdata.strCondidtionDesc.Split(new string[] { "\\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (strcondition.Length == 2)
            {
                int level = MainPlayerHelper.GetPlayerLevel();
                StringBuilder msg = new StringBuilder();
                if (level < m_Trailerdata.level)
                {
                    msg.Append(ColorManager.GetColorString(ColorType.JZRY_Txt_Red, string.Format("{0}(还差{1}级)\n", strcondition[0], (m_Trailerdata.level - level))));
                }
                else
                {
                    msg.Append(ColorManager.GetColorString(ColorType.JZRY_Green, string.Format("{0}", strcondition[0])));
                }

                if (DataManager.Manager<TaskDataManager>().CheckTaskFinished(m_Trailerdata.task))
                {
                    msg.Append(ColorManager.GetColorString(ColorType.JZRY_Green, (string.Format("\n{0}", strcondition[1]))));
                }
                else
                {

                    msg.Append(ColorManager.GetColorString(ColorType.JZRY_Txt_Red, string.Format("\n{0}", strcondition[1])));
                }
                m_label_conditionDesc.text = msg.ToString();

            }
            else
            {
                int level = MainPlayerHelper.GetPlayerLevel();
                if (level < m_Trailerdata.level)
                {
                    m_label_conditionDesc.text = ColorManager.GetColorString(ColorType.JZRY_Txt_Red, string.Format("{0}(还差{1}级)", strcondition[0], (m_Trailerdata.level - level)));
                }
                else
                {
                    m_label_conditionDesc.text = ColorManager.GetColorString(ColorType.JZRY_Green, string.Format("{0}", strcondition[0]));
                }
            }
        }

    }

    void onClick_Btnclose_Btn(GameObject caster)
    {
        this.HideSelf();
    }

    void onClick_Btnget_Btn(GameObject caster)
    {
        this.HideSelf();
        if (m_Trailerdata == null)
        {
            return;
        }
        FunctionPushManager manager = DataManager.Manager<FunctionPushManager>();
        if (manager.CanOpen(m_Trailerdata))
        {
            Protocol.Instance.RequestSystemForecastReward(m_Trailerdata.dwId);
            return;
        }

        List<QuestTraceInfo> listInfo = null;
        DataManager.Manager<TaskDataManager>().GetAllQuestTraceInfo(out listInfo);
        for (int i = 0; i < listInfo.Count; i++)
        {
            if (listInfo[i].taskType == GameCmd.TaskType.TaskType_Normal)
            {
                Engine.Utility.EventEngine.Instance().DispatchEvent((int)Client.GameEventID.TASK_DONING,
            new Client.stDoingTask() { taskid = listInfo[i].taskId });

                break;
            }
        }      
    }

    #region UIItemRewardGridCreator
    UIGridCreatorBase m_ctor_UIItemRewardCreator;
    List<UIItemRewardData> m_lst_UIItemRewardDatas = new List<UIItemRewardData>();
    void AddCreator(Transform parent)
    {
        if (parent != null)
        {
            m_ctor_UIItemRewardCreator = parent.GetComponent<UIGridCreatorBase>();
            if (m_ctor_UIItemRewardCreator == null)
            {
                m_ctor_UIItemRewardCreator = parent.gameObject.AddComponent<UIGridCreatorBase>();
            }
            m_ctor_UIItemRewardCreator.arrageMent = UIGridCreatorBase.Arrangement.Horizontal;
            m_ctor_UIItemRewardCreator.gridWidth = 90;
            m_ctor_UIItemRewardCreator.gridHeight = 90;
            m_ctor_UIItemRewardCreator.RefreshCheck();
            m_ctor_UIItemRewardCreator.Initialize<UIItemRewardGrid>(m_trans_UIItemRewardGrid.gameObject, OnUpdateGridData, null);
        }
    }
    void OnUpdateGridData(UIGridBase grid, int index)
    {
        if (grid is UIItemRewardGrid)
        {
            UIItemRewardGrid itemShow = grid as UIItemRewardGrid;
            if (itemShow != null)
            {
                if (index < m_lst_UIItemRewardDatas.Count)
                {
                    UIItemRewardData data = m_lst_UIItemRewardDatas[index];
                    uint itemID = data.itemID;
                    uint num = data.num;
                    itemShow.SetGridData(itemID, num, false);
                }
            }
        }
    }
    #endregion
    public override void Release(bool depthRelease = true)
    {
        base.Release(depthRelease);
    }
    protected override void OnHide()
    {
        base.OnHide();
        Release();
    }
    protected override void OnPanelBaseDestory()
    {
        base.OnPanelBaseDestory();
        Release();
    }
}
