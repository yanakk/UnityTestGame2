using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ItemColSystem : ReactiveSystem<GameEntity>
{
    // 战斗物品栏的刷新
    readonly GameContext _context;

    public ItemColSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.isTaken2Battle);     // isTaken2Battle 发生变化
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasisTaken2Battle;   // taken to battle
    }

    protected override void Execute(List<GameEntity> entities)
    {
        //int count = entities.Count;
        IGroup<GameEntity> _Bag = _context.GetGroup(GameMatcher.ItemInBag);
        GameEntity bag = _Bag.GetEntities()[0];     // 表示物品与人物拥有关系的entity
        IGroup<GameEntity> _items = _context.GetGroup(GameMatcher.isTaken2Battle);
        BagManager.RefreshBattleItem(bag, _items);
    }

}
