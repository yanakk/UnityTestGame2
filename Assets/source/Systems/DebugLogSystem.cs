using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class DebugLogSystem : ReactiveSystem<GameEntity>
{
    public DebugLogSystem(IContext<GameEntity> context) : base(context) { }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            Debug.Log(e.debugLog.message);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDebugLog;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DebugLog);
    }
}

