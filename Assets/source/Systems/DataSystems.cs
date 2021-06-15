using Entitas;

public class DataSystems : Feature
{
    public DataSystems(Contexts contexts) : base("Data Systems")
    {
        Add(new AddDataSystem(contexts));
    }
}
