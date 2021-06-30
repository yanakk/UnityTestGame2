using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class SkillInitSystem : IInitializeSystem
{
    readonly GameContext _context;

    public SkillInitSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        // 测试时暂时人为初始化；实际需要从数据库中读取信息，来完成初始化
        var entity = _context.CreateEntity();   // 前两个技能默认自带，且无法卸下
        entity.AddSkill("RecoveryHP");
        entity.AddSprite("item4");
        entity.AddSkillIndex(0);
        entity.AddisTaken2Battle(true);

        entity = _context.CreateEntity();
        entity.AddSkill("RecoveryMP");
        entity.AddSprite("item5");
        entity.AddSkillIndex(1);
        entity.AddisTaken2Battle(true);

        entity = _context.CreateEntity();
        entity.AddSkill("sword3");
        entity.AddSprite("sword3");
        entity.AddSkillIndex(2);
        entity.AddisTaken2Battle(false);


        // Skill In Bag
        var SiBentity = _context.CreateEntity();
        // 测试时暂时人为初始化；实际需要从数据库中读取信息，来完成初始化
        List<Vector2> SkillInBagList = new List<Vector2>();
        SiBentity.AddSkillInBag(SkillInBagList);

        SkillManager.AddSkill2Entity(SiBentity, 0, 0);    // 测试时放在包里
        SkillManager.AddSkill2Entity(SiBentity, 0, 1);    // 测试时放在包里
        SkillManager.AddSkill2Entity(SiBentity, 0, 2);    // 测试时放在包里

        IGroup<GameEntity> _skills = _context.GetGroup(GameMatcher.SkillIndex);
        SkillManager.RefreshItem(SiBentity, _skills);
    }

}
