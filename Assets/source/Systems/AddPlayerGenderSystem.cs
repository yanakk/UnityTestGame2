/// <summary>
/// 为玩家角色添加性别，可变
/// </summary>
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddPlayerGenderSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext context;
    int t_gender;
    public AddPlayerGenderSystem(Contexts contexts, int gender) : base(contexts.game)
    {
        context = contexts.game;
        t_gender = gender;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CharacterIndex);
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.characterIndex.id == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.hasCharacterGender)
            {
                e.characterGender.gender = t_gender;
            }
            else
            {
                e.AddCharacterGender(t_gender);
            }
        }
    }
}