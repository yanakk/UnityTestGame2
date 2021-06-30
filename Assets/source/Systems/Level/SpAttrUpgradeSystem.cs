using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SpAttrUpgradeSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;

    public SpAttrUpgradeSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Splevel);     // Splevel 发生变化
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSpexp && entity.hasSplevel;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            if (e.splevel.splevel >= 2) AttrUpdate(e);     // 如果等级变动（升级），加属性    有加载的bug
        }

    }

    private void AttrUpdate(GameEntity e)
    {
        e.ReplaceLifetime(e.lifetime.lifetime + 5); // + 寿命
                                                    // + 五行
                                                    // + 攻击，灵力上限
    }

}
