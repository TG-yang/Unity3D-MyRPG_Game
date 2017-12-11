using UnityEngine;
using System.Collections;

public class ShopDrug : MonoBehaviour
{

    public static ShopDrug _instance;
    private TweenPosition tween;
    private bool isShow = false;

    private GameObject numberDialog;
    private UIInput numberInput;
    private int buyId = 0;

    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
        numberDialog = this.transform.Find("NumberDialog").gameObject;
        numberInput = transform.Find("NumberDialog/NumberInput").GetComponent<UIInput>();
        numberDialog.SetActive(false);

    }


    public void TransformState()
    {
        if (isShow == false)
        {
            tween.PlayForward();
            isShow = true;
        }
        else
        {
            tween.PlayReverse();
            isShow = false;
        }
    }

    public void OnCloseButtonClick()
    {
        TransformState();
    }

    public void OnBuyId1001()
    {
        Buy(1001);
    }
    public void OnBuyId1002()
    {
        Buy(1002);
    }
    public void OnBuyId1003()
    {
        Buy(1003);
    }

    public void OnOKButtonClick()
    {
        int count = int.Parse(numberInput.value);
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(buyId);
        int price = info.price_buy;
        int priceTotal = price * count;
        bool success = Inventory._instance.GetCoin(priceTotal);
        if (success)//如果取款成功,可以购买
        {
            if (count > 0)
            {
                Inventory._instance.GetId(buyId, count);
            }
        }
        numberDialog.SetActive(false);
    }

    void Buy(int id)
    {
        ShowNumberDialog();
        buyId = id;
    }

    void ShowNumberDialog()
    {
        numberDialog.SetActive(true);
        numberInput.value = "0";
    }
}
