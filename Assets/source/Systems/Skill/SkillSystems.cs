using Entitas;

public class SkillSystems : Feature
{
    public SkillSystems(Contexts contexts)
    {
        //Add(new SkillInitSystem(contexts));
        Add(new RenderSpriteSystem(contexts));
        //Add(new SkillViewSystem(contexts));   //  显示玩家装备的技能
    }
}
