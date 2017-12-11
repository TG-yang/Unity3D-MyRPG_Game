using UnityEngine;
using System.Collections;

public class BarNPC : NPC
{
    public TweenPosition questTween;
    public int killCount = 0;
    public bool isInTask = false;
    public UILabel desLabel;

    public GameObject acceptBtnGo;
    public GameObject okBtnGo;
    public GameObject cancelBtnGo;

    //得分生命值对象
    private PlayerStatus status;

    void Start()
    {
        status = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }
    //当鼠标移动到某对象的上方时触发的事件
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {//isInTask 是否在任务中
            if (isInTask)
            {   //任务进行面板
                ShowTaskProgress();
            }
            else
            {//任务面板
                ShowTaskDes();    
            }
            ShowQuest();
        }
    }
    void ShowQuest()
    {
        questTween.gameObject.SetActive(true);
        questTween.PlayForward();
    }
    void HideQuest()
    {
        questTween.PlayReverse();
    }

    void ShowTaskDes()
    {
        desLabel.text = "任务:\n杀死了10只狼\n\n奖励:\n1000金币";
        okBtnGo.SetActive(false);
        acceptBtnGo.SetActive(true);
        cancelBtnGo.SetActive(true);
    }

    void ShowTaskProgress()
    {
        desLabel.text = "任务:\n你已经杀死了" + killCount + "\\10只狼\n\n奖励:\n1000金币";
        okBtnGo.SetActive(true);
        acceptBtnGo.SetActive(false);
        cancelBtnGo.SetActive(false);
    }
    public void OnCloseButtonClik()
    {
        //隐藏窗口
        HideQuest();
    }

    public void OnAcceptButtonClick()
    {
       ShowTaskProgress();
        isInTask = true;//表示在任务中
    }

    public void OnOkButtonClick()
    {
        if (killCount >= 10)
        {
            status.GetCoint(1000);
            killCount = 0;
        }
        else
        {
            //隐藏面板
            HideQuest();
        }
    }

    public void OnCancelButtonClick()
    {
        
    }
}
