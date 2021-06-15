using Entitas;
using UnityEngine;

public class MoveControllerSystem : IExecuteSystem
{
	readonly GameContext _context;
	IGroup<GameEntity> moveableHeroGroup;

	public MoveControllerSystem(Contexts contexts)
	{
		_context = contexts.game;
		var matcher = Matcher<GameEntity>.AllOf(GameMatcher.Hero, GameMatcher.Speed);
		moveableHeroGroup = _context.GetGroup(matcher);
	}

	public void Execute()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		// left:-1, right:1, default 0
		float moveY = Input.GetAxisRaw("Vertical");
		// down:-1. up:1, default 0
		

		foreach (var e in moveableHeroGroup)
		{

			if (Input.GetMouseButtonDown(1))
			{
				Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				e.ReplaceVelocity(target.x, target.y);
			}
		}
	}
}