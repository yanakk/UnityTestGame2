using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ItemCollisionSystem : IExecuteSystem
{
    readonly GameContext _context;
    IGroup<GameEntity> _entities;
    readonly IGroup<GameEntity> _Bag;
    readonly IGroup<GameEntity> _items;
    static bool start;

    public ItemCollisionSystem(Contexts contexts)
    {
        _context = contexts.game;
        _entities = _context.GetGroup(GameMatcher.isDropped);
        _Bag = _context.GetGroup(GameMatcher.ItemInBag);
        _items = _context.GetGroup(GameMatcher.ItemIndex);
        start = false;
    }

    public void Execute()
    {
        foreach (GameEntity e in _entities)
        {
            if (e.isDropped.isdrop == true)
            {
                GameObject itemonworld = e.view.gameObject;
                BoxCollider2D bc = itemonworld.GetComponent<BoxCollider2D>();

                Collider2D[] results = new Collider2D[3];
                ContactFilter2D contactFilter = new ContactFilter2D();
                contactFilter.useTriggers = true;
                bc.OverlapCollider(contactFilter, results); // 第一次返回的有bug，设置start规避

                foreach (Collider2D other in results)
                {
                    if (start == true && other != null && other.gameObject.CompareTag("Player"))  // 人物名称Tag
                    {
                        Debug.Log("检测到物品与玩家碰撞");
                        e.isDropped.isdrop = false;
                        GameEntity bag = _Bag.GetEntities()[0];     // 用于表示物品与人物拥有关系的一个entity
                        int character_id = 0;
                        int item_id = e.itemIndex.id;

                        BagManager.AddItem2Entity(bag, character_id, item_id);
                        BagManager.RefreshItem(bag, _items);
                        //BagManager.RefreshBattleItem(bag, _items);
                        Object.Destroy(itemonworld);
                    }
                }
            }
        }
        start = true;
    }
}
