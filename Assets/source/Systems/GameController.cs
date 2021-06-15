using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    private static Contexts _contexts;

    void Start()
    {
        _contexts = Contexts.sharedInstance;
        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private static Systems CreateSystems(Contexts contexts)
    {

        return new Feature("Systems")
            .Add(new ViewSystems(contexts))
            .Add(new HeroSystem(contexts))
            .Add(new ItemSystems(contexts));
    }

    public static Contexts GetContext()
    {
        return _contexts;
    }
}