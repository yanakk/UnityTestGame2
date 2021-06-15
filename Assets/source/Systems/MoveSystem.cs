using Entitas;
using UnityEngine;

public sealed class MoveSystem : IExecuteSystem {
	IGroup<GameEntity> moveableGroup;

	public MoveSystem(Contexts contexts) 
	{
		var matcher = Matcher<GameEntity>.AllOf(GameMatcher.Velocity, GameMatcher.Position);
		moveableGroup = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach(var e in moveableGroup)
		{
			GameObject go = e.view.gameObject;
			Transform transform = go.transform;
			string speed = "";
			int speed_int = 5;
			e.data.values.TryGetValue("speed",out speed);
			if (speed.Length != 0) {

				speed_int = int.Parse(speed);
			}
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(e.velocity.x,e.velocity.y), speed_int * Time.deltaTime);


			//e.ReplacePosition(e.position.x + e.velocity.x*Time.deltaTime, e.position.y + e.velocity.y* Time.deltaTime);
		}
	}
}