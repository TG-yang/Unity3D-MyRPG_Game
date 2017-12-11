using UnityEngine;
using System.Collections;

//Status 脚本赋值NGUI面板上
public class Status : MonoBehaviour
{

    public static Status _instance;
    private TweenPosition tween;
    private bool isShow = false;

    private UILabel attackLabel;
    private UILabel defLabel;
    private UILabel speedLabel;
    private UILabel remainPointLabel;
    private UILabel summaryLabel;

    private GameObject attackButtonGo;
    private GameObject defButtonGo;
    private GameObject speedButtonGo;

    private PlayerStatus ps;

    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();

        
        attackLabel = transform.Find("Attack").GetComponent<UILabel>();
        defLabel = transform.Find("Def").GetComponent<UILabel>();
        speedLabel = transform.Find("Speed").GetComponent<UILabel>();
        remainPointLabel = transform.Find("RemainPoint").GetComponent<UILabel>();
        summaryLabel = transform.Find("Summary").GetComponent<UILabel>();
        attackButtonGo = transform.Find("PlusAttackButton").gameObject;
        defButtonGo = transform.Find("PlusDefButton").gameObject;
        speedButtonGo = transform.Find("PlusSpeedButton").gameObject;

        ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }

    public void TransformState()
    {
        if (isShow == false)
        {
            UpdateShow();
            tween.PlayForward();
            isShow = true;
        }
        else
        {
            tween.PlayReverse();
            isShow = false;
        }
    }

    void UpdateShow() //更新显示, 根据属性值,去更新显示
    {
        attackLabel.text = ps.attack + " + " + ps.attackPlus;
        defLabel.text = ps.def + " +" + ps.defPlus;
        speedLabel.text = ps.speed + " + " + ps.speedPlus;

        remainPointLabel.text = ps.pointRemain.ToString();

        summaryLabel.text = "伤害: " + (ps.attack + ps.attackPlus)
                            + "  " + "防御: " + (ps.def + ps.defPlus)
                            + "  " + "速度: " + (ps.speed + ps.speedPlus);
        if (ps.pointRemain > 0)
        {
            attackButtonGo.SetActive(true);
            defButtonGo.SetActive(true);
            speedButtonGo.SetActive(true);
        }
        else
        {
            attackButtonGo.SetActive(false);
            defButtonGo.SetActive(false);
            speedButtonGo.SetActive(false);
        }
        
    }

    public void OnAttackPlusClick()
    {
        bool success = ps.GetPoint();
        if (success)
        {
            ps.attackPlus++;
            UpdateShow();
        }
    }

    public void OnDefPlusClick()
    {
        bool success = ps.GetPoint();
        if (success)
        {
            ps.defPlus++;
            UpdateShow();
        }
    }

    public void OnSpeedPlusClick()
    {
        bool success = ps.GetPoint();
        if (success)
        {
            ps.speedPlus++;
            UpdateShow();
        }
    }
}
