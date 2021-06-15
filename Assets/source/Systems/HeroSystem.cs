using Entitas;

public class HeroSystem : Feature
{
    public HeroSystem(Contexts contexts)
    {
        Add(new HeroInitSystem(contexts));
        Add(new MoveControllerSystem(contexts)); 
        Add(new MoveSystem(contexts));
    }
}
