using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class ApplyAttackInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;

		public ApplyAttackInputSystem(InputContext inputContext, GameplayContext gameplayContext)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
		}

		public void Update()
		{
		}
	}
}