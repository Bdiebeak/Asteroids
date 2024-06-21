using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Input.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Input.Systems
{
	public class InitializeInputSystem : IStartSystem
	{
		private readonly InputContext _inputContext;

		public InitializeInputSystem(InputContext inputContext)
		{
			_inputContext = inputContext;
		}

		public void Start()
		{
			Entity entity = _inputContext.CreateEntity();
			entity.Add(new MoveInputComponent());
			entity.Add(new RotateInputComponent());
			entity.Add(new BulletAttackInputComponent());
			entity.Add(new LaserAttackInputComponent());
		}
	}
}