using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas;

public class SkillManager : MonoBehaviour
{
    static SkillManager instance;
    public GameObject slotGrid;
    public GameObject Grid_skill4battle;
    public Slot slotPrefab;
    public Text skillInformation;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    public static void AddSkill2Entity(GameEntity bag, int character_id, int skill_id)
    {
        Vector2 temp = new Vector2(character_id, skill_id);

        //不在背包中，添加
        if (!bag.skillInBag.SkillInBagList.Exists(t => t == temp))
        {
            List <Vector2> now = bag.skillInBag.SkillInBagList;
            now.Add(temp);
            bag.ReplaceSkillInBag(now);     // 一定要用replace
            //bag.skillInBag.SkillInBagList.Add(temp);
        }
    }

    // 获得所有Skill的信息，传给Slot
    public static void CreateNewItem(GameEntity item, GameObject Grid)
    {
        Slot newItem = Instantiate(instance.slotPrefab, Grid.transform.position, Quaternion.identity);   // Object, Position, Quaternion
        newItem.gameObject.transform.SetParent(Grid.transform);    // 父节点
        newItem.slotImage.sprite = Resources.Load<Sprite>(item.sprite.name); ;      // 图片
        newItem.slotitemid = item.skillIndex.id;    // 里面skill的编号
    }

    public static void RefreshItem(GameEntity bagdata, IGroup<GameEntity> _skills)
    {
        // 目前只做玩家装备的刷新与显示
        int character_id = 0;
        var playeritem = bagdata.skillInBag.SkillInBagList.FindAll(t => t[0] == character_id);    // 属于玩家p的所有物品，(p, item_id)
        var total_num = playeritem.Count;                                                       // 玩家p的所有物品数量

        // 先清零再重载
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < total_num; i++)
        {
            // 找到每个item id对应的entity，并找到其关联的数量，输入到函数中
            int now_iid = (int)playeritem[i][1]; // item id
            int now_cid = character_id;

            foreach (GameEntity e in _skills)
            {
                if (e.skillIndex.id == now_iid)
                {
                    GameEntity now_skill = e;    // 要放入背包的物品
                    CreateNewItem(now_skill,instance.slotGrid);
                    //if (e.hasisTaken2Battle && e.isTaken2Battle.istaken2battle) CreateNewItem(now_item, num, instance.Grid_item4battle);
                    break;
                }
            }
        }
    }

    public static void RefreshBattleSkill(GameEntity bagdata, IGroup<GameEntity> _items)
    {
        // 目前只做玩家装备的刷新与显示
        int character_id = 0;
        var playeritem = bagdata.skillInBag.SkillInBagList.FindAll(t => t[0] == character_id); 
        var total_num = playeritem.Count;

        // 先清零再重载
        for (int i = 0; i < instance.Grid_skill4battle.transform.childCount; i++)
        {
            Destroy(instance.Grid_skill4battle.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < total_num; i++)
        {
            // 找到每个skill id对应的entity，并找到其关联的数量，输入到函数中
            int now_iid = (int)playeritem[i][1]; // item id
            int now_cid = character_id;

            foreach (GameEntity e in _items)
            {
                if (e.hasSkillIndex && e.skillIndex.id == now_iid)
                {
                    GameEntity now_item = e;
                    if (e.hasisTaken2Battle && e.isTaken2Battle.istaken2battle) CreateNewItem(now_item, instance.Grid_skill4battle);
                    break;
                }
            }
        }
    }

}
