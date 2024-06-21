using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Input.Components;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Input.Systems
{
	public class UpdateLaserAttackInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly IInputService _inputService;
		private readonly Mask _mask;

		public UpdateLaserAttackInputSystem(InputContext inputContext, IInputService inputService)
		{
			_inputContext = inputContext;
			_inputService = inputService;
			_mask = new Mask().Include<LaserAttackInputComponent>();
		}

		public void Update()
		{
			var inputEntities = _inputContext.GetEntities(_mask);
			foreach (Entity inputEntity in inputEntities)
			{
				LaserAttackInputComponent laserInput = inputEntity.Get<LaserAttackInputComponent>();
				laserInput.value = _inputService.LaserAttack;
			}
		}
	}
}