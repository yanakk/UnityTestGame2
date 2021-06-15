using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddDataSystem : ReactiveSystem<GameEntity>
{
    public AddDataSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            e.AddData(new Dictionary<string, string>());
            e.data.values.Add("speed","10");

        }
    }
}