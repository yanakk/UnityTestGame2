using Entitas;

public class LevelSystems : Feature
{
    public LevelSystems(Contexts contexts)
    {
        Add(new LevelInitSystem(contexts));
        Add(new SpLevelUpSystem(contexts));
        Add(new PhyLevelUpSystem(contexts));
        Add(new SpAttrUpgradeSystem(contexts));
        Add(new PhyAttrUpgradeSystem(contexts));
    }
}