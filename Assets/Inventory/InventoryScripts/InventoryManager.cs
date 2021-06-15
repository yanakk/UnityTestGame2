using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInformation;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    private void Start()
    {
        RefreshItem();  //  初始化背包，加载已有物品
    }

    // 获得所有Item的信息，传给Slot
    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);   // Object, Position, Quaternion
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);    // 父节点
        newItem.slotItem = item;    // 信息赋值
        newItem.slotImage.sprite = item.itemImage;      // 图片
        newItem.slotNum.text = item.itemHeld.ToString();   // 个数
    }

    public static void RefreshItem()
    {
        // 先清零再重载
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
            CreateNewItem(instance.myBag.itemList[i]);
    }

}
