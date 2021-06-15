using Entitas;

public class ItemSystems : Feature
{
    public ItemSystems(Contexts contexts)
    {
        Add(new ItemInitSystem(contexts));
        Add(new DropItemSystem(contexts));
        //Add(new AddDataSystem(contexts));
        Add(new RenderSpriteSystem(contexts));
        Add(new RenderPositionSystem(contexts));
        Add(new ItemCollisionSystem(contexts));
        Add(new ItemColSystem(contexts));
    }
}
