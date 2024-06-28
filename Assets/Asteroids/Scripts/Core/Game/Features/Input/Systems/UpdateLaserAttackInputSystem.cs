using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Events;
using Asteroids.Scripts.Core.Game.Features.Input.Components;
using Asteroids.Scripts.Core.Utilities.Services.Input;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Input.Systems
{
	public class UpdateLaserAttackInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly IInputService _inputService;

		public UpdateLaserAttackInputSystem(InputContext inputContext, IInputService inputService)
		{
			_inputContext = inputContext;
			_inputService = inputService;
		}

		public void Update()
		{
			_inputContext.DestroyEvents<LaserAttackPerformedEvent>();
			if (_inputService.LaserAttack)
			{
				_inputContext.CreateEvent(new LaserAttackPerformedEvent());
			}
		}
	}
}