using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PhyAttrUpgradeSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;

    public PhyAttrUpgradeSystem(Contexts contexts) : base(contexts.game)
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
            if (e.phylevel.phylevel >= 2) AttrUpdate(e);     // 如果等级变动（升级），加属性    有加载的bug
        }

    }

    private void AttrUpdate(GameEntity e)
    {
                                                    // + 攻防，血上限，移速
    }

}
