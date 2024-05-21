using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using Asteroids.Scripts.Logic.Components;

namespace Asteroids.Scripts.Logic.Systems.Input
{
	public class InitializeInputSystem : IStartSystem
	{
		private readonly IContext _inputContext;

		public InitializeInputSystem(IContext inputContext)
		{
			_inputContext = inputContext;
		}

		public void Start()
		{
			Entity entity = _inputContext.CreateEntity();
			entity.Add<MoveInputComponent>();
			entity.Add<AttackInputComponent>();
		}
	}
}