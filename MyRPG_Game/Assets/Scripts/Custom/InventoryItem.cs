using UnityEngine;
using System.Collections;

public class InventoryItem : UIDragDropItem
{

    private UISprite sprite;
    private int id;

    void Awake()
    {
        sprite = this.GetComponent<UISprite>();
    }

    void Update()
    {
        if (isHover)
        {
            InventoryDes._instance.Show(id);
        }
    }

    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);

        if (surface != null)
        {
            if (surface.tag == Tags.inventoryItemGrid) //拖放到空的格子里去
            {
                if (surface == this.transform.parent.gameObject) // 拖放到自己的格子里去了
                {
                    ResetPosition();
                }
                else
                {
                    InventoryItemGrid oldParent = this.transform.parent.GetComponent<InventoryItemGrid>();
                    this.transform.parent = surface.transform;
                    ResetPosition();

                    InventoryItemGrid newParent = surface.GetComponent<InventoryItemGrid>();
                    newParent.SetId(oldParent.id, oldParent.num);

                    oldParent.ClearInfo();

                }
            }
            else if (surface.tag == Tags.inventoryItem) //放到一个已经有物品的空格里去
            {
                InventoryItemGrid grid1 = this.transform.parent.GetComponent<InventoryItemGrid>();
                InventoryItemGrid grid2 = surface.transform.parent.GetComponent<InventoryItemGrid>();

                int id = grid1.id;
                int num = grid1.num;
                grid1.SetId(grid2.id, grid2.num);
                grid2.SetId(id, num);
            }
        }
      
            ResetPosition();

      
    }
    

    void ResetPosition()
    {
        transform.localPosition = Vector3.zero;
    }
    public void SetId(int id)
    {
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        sprite.spriteName = info.icon_name;
    }

    public void SetIconName(int id, string icon_name)
    {
        sprite.spriteName = icon_name;
        this.id = id;
    }

    private bool isHover = false;
    //鼠标移上去
    public void OnHoverOver()
    {
        print("鼠标移上去");
        isHover = true;

    }
    //鼠标移下来
    public void OnHoverOut()
    {
        print("移下来");
        isHover = false;
    }
}
