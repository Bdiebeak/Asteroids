using Asteroids.Scripts.Core.Gameplay.Input.Components;
using Asteroids.Scripts.Core.Infrastructure.Services;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.Input.Systems
{
	public class UpdateAttackInputSystem : IUpdateSystem
	{
		private readonly IContext _inputContext;
		private readonly IInputService _inputService;
		private readonly Mask _mask;

		public UpdateAttackInputSystem(IContext inputContext, IInputService inputService)
		{
			_inputContext = inputContext;
			_inputService = inputService;
			_mask = new Mask().Include<AttackInputComponent>();
		}

		public void Update(float deltaTime)
		{
			var inputEntities = _inputContext.GetEntities(_mask);
			foreach (Entity inputEntity in inputEntities)
			{
				AttackInputComponent attackInput = inputEntity.Get<AttackInputComponent>();
				attackInput.isFiring = _inputService.IsFiringPressed;
			}
		}
	}
}