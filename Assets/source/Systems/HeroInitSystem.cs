using Entitas;

public sealed class HeroInitSystem : IInitializeSystem
{
	readonly GameContext _context;

	public HeroInitSystem(Contexts contexts)
	{
		_context = contexts.game;
	}

	public void Initialize()
	{
		var entity = _context.CreateEntity();
		entity.AddHero("character");
		entity.AddPosition(0, 0);
		entity.AddSpeed(5);
		entity.AddVelocity(0, 0);
		entity.AddSprite("character");
		
	}
}
