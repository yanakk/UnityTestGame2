using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class ItemInitSystem : IInitializeSystem
{
    readonly GameContext _context;

    public ItemInitSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        // 测试时暂时人为初始化；实际需要从数据库中读取信息，来完成初始化
        var entity = _context.CreateEntity();
        entity.AddItem("sword3");
        entity.AddSprite("sword3");
        entity.AddItemIndex(3);
        entity.AddisDropped(true);  // 初始化应为false，测试时暂设为true且有position；
        entity.AddPosition(-6, -3);

        entity = _context.CreateEntity();
        entity.AddItem("RecoveryHP");
        entity.AddSprite("item4");
        entity.AddItemIndex(4);
        entity.AddisDropped(false);
        entity.AddisTaken2Battle(false);
        entity = _context.CreateEntity();
        entity.AddItem("RecoveryMP");
        entity.AddSprite("item5");
        entity.AddItemIndex(5);
        entity.AddisDropped(true);
        entity.AddisTaken2Battle(false);
        entity.AddPosition(-2, -4);

        // Item In Bag
        var IiBentity = _context.CreateEntity();
        // 测试时暂时人为初始化；实际需要从数据库中读取信息，来完成初始化
        List<int> AmountList = new List<int>();
        List<Vector2> ItemInBagList = new List<Vector2>();
        IiBentity.AddItemInBag(ItemInBagList, AmountList);

        for (int i = 0; i < 10; i++) BagManager.AddItem2Entity(IiBentity, 0, 4);    // 测试时放在包里

        IGroup<GameEntity> _items = _context.GetGroup(GameMatcher.ItemIndex);
        BagManager.RefreshItem(IiBentity, _items);
    }

}
