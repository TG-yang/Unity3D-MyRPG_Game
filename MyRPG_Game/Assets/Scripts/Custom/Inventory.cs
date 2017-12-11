using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    public static Inventory _instance;
    private TweenPosition tween;

    private int coinCount = 1000; //金币数量

    public List<InventoryItemGrid> itemGridList = new List<InventoryItemGrid>();
    public UILabel coinNumberLabel;
    public GameObject inventoryItem;

    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
        tween.PlayReverse();
        //this.gameObject.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetId(Random.Range(1001,1004));
        }
    }
    //拾取id物品的功能,并添加到物品栏里面
    public void GetId(int id,int count =1)
    {
        //第一步查找所有的物品是否存在该物品
        // 第二,如果存在,num+1
        InventoryItemGrid grid = null;
        foreach (InventoryItemGrid temp in itemGridList)
        {
            if (temp.id == id)
            {
                grid =temp;
                break;
            }
            
        }
        if (grid != null) //存在的情况
        {
            grid.PlusNumber(count);
        }
        else
        {
            //不存在的话,找个新的格子
            foreach (InventoryItemGrid temp in itemGridList)
            {
                if (temp.id==0)
                {
                    grid = temp;
                    break;
                }
            }
            if (grid!=null) //第三 查找新的方格,然后把新创建的 放到新的空格去
            {
                //添加空的物体
                GameObject itemGo = NGUITools.AddChild(grid.gameObject, inventoryItem);
                itemGo.transform.localPosition = Vector3.zero;
                itemGo.GetComponent<UISprite>().depth = 4;
                grid.SetId(id, count);
            }
        }   
    }

    private bool isShow = false;
    public void Show()
    {
        isShow = true;
        tween.PlayForward();
    }

    public void Hide()
    {
        isShow = false;
        tween.PlayReverse();
    }

    public void TransformState()
    {
        if (isShow == false)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    //取款方法
    public bool GetCoin(int count)
    {
        if (coinCount>=count)
        {
            coinCount -= count;
            coinNumberLabel.text = coinCount.ToString(); //更新金币的显示
            return true;
        }
        return false;
    }
}
