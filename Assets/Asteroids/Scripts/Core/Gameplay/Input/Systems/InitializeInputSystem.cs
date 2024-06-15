using Asteroids.Scripts.Core.Gameplay.Input.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.Input.Systems
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
			entity.Add<MoveInputComponent>(new MoveInputComponent());
			entity.Add<RotateInputComponent>(new RotateInputComponent());
			entity.Add<BulletAttackInputComponent>(new BulletAttackInputComponent());
			entity.Add<LaserAttackInputComponent>(new LaserAttackInputComponent());
		}
	}
}