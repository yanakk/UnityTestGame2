/// <summary>
/// 为玩家角色添加姓名，可变；Input(contexts, family_name, given_name)
/// </summary>
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddPlayerNameSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext context;
    string _fname;
    string _gname;
    public AddPlayerNameSystem(Contexts contexts, string fname, string gname) : base(contexts.game)
    {
        context = contexts.game;
        _fname = fname;
        _gname = gname;
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
            if (e.hasCharacterName)
            {
                e.characterName.fname = _fname;
                e.characterName.gname = _gname;
            }
            else
            {
                e.AddCharacterName(_fname,_gname);
            }
        }
    }
}