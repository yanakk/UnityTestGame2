using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PhyLevelUpSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;

    public PhyLevelUpSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Phyexp);     // Phyexp 发生变化
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPhyexp && entity.hasPhylevel;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            if (e.phyexp.phyexp >= e.phylevel.phylevel * 100) LevelUpdate(e);// 如果符合升级条件 - 升级，经验清零
        }

    }

    private void LevelUpdate(GameEntity e)
    {
        e.ReplacePhylevel(e.phylevel.phylevel + 1);
        e.ReplacePhyexp(0);
    }
}
