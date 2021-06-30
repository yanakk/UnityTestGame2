using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitSystem : IInitializeSystem
{
    readonly GameContext _context;

    public LevelInitSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        // 测试时暂时人为初始化；
        IGroup<GameEntity> _Bag = _context.GetGroup(GameMatcher.Hero);
        GameEntity hero = _Bag.GetEntities()[0];     // 表示Hero
        hero.AddCharacterIndex(0);
        hero.AddSplevel(1);
        hero.AddSpexp(0);
        hero.AddPhylevel(1);
        hero.AddPhyexp(0);
        hero.AddLifetime(70);

    }

}
