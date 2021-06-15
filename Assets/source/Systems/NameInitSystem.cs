using Entitas;

public sealed class NameInitSystem : IInitializeSystem
{
    readonly GameContext _context;

    public NameInitSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var PlayerEntity = _context.CreateEntity();   // 创建玩家角色，编号0
        PlayerEntity.AddCharacterIndex(0);
    }
}
