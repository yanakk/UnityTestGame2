using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class DropItemSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _ItemContainer = new GameObject("Items").transform;
    readonly GameContext _context;

    public DropItemSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && !entity.hasView && entity.hasItem && entity.isDropped.isdrop;   // is Item
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            GameObject itemonworld = new GameObject("item");
            itemonworld.transform.SetParent(_ItemContainer, false);
            e.AddView(itemonworld);
            itemonworld.Link(e);

            BoxCollider2D bc = itemonworld.GetComponent<BoxCollider2D>();
            if (bc == null) bc = itemonworld.AddComponent<BoxCollider2D>();
            bc.isTrigger = true;

        }
    }
}
