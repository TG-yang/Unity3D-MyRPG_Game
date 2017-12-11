using UnityEngine;
using System.Collections;

public class ShopDrugNPC : NPC {

    public void OnMouseOver()//当鼠标在这个游戏物体上的时候,会一直触发这个事件
    {
        if (Input.GetMouseButtonDown(0)) //弹出药品购买列表
        {
            ShopDrug._instance.TransformState();
        }
    }
}
