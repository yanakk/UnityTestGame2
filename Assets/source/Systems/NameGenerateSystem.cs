using Entitas;

public class NameGenerateSystem : Feature
{
    public NameGenerateSystem(Contexts contexts) : base("NameGenerate Systems")
    {
        Add(new NameInitSystem(contexts));
        //Add(new AddPlayerGenderSystem(contexts));
    }
}