using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SpLevelUpSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;

    public SpLevelUpSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Spexp);     // Spexp 发生变化
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSpexp && entity.hasSplevel;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            if (e.spexp.spexp >= e.splevel.splevel * 100) LevelUpdate(e);// 如果符合升级条件 - 升级，经验清零
        }
        
    }

    private void LevelUpdate(GameEntity e)
    {
        e.ReplaceSplevel(e.splevel.splevel + 1);
        e.ReplaceSpexp(0);
    }

}
