using Entitas;
using UnityEngine;

public class BattleController : MonoBehaviour
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

        return new Feature("BattleSystems")
            .Add(new ItemColSystem(contexts));
    }

    public static Contexts GetContext()
    {
        return _contexts;
    }
}