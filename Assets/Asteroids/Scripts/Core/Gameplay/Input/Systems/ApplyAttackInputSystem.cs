using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.Input.Systems
{
	public class ApplyAttackInputSystem : IUpdateSystem
	{
		private readonly IContext _inputContext;
		private readonly IContext _gameplayContext;

		public ApplyAttackInputSystem(IContext inputContext, IContext gameplayContext)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
		}

		public void Update(float deltaTime)
		{
		}
	}
}