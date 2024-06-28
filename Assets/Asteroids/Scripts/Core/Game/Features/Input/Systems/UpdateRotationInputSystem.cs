using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Input.Components;
using Asteroids.Scripts.Core.Utilities.Services.Input;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Input.Systems
{
	public class UpdateRotationInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly IInputService _inputService;
		private readonly Mask _rotationInputMask;

		public UpdateRotationInputSystem(InputContext inputContext, IInputService inputService)
		{
			_inputContext = inputContext;
			_inputService = inputService;
			_rotationInputMask = new Mask().Include<RotationInput>();
		}

		public void Update()
		{
			var entities = _inputContext.GetEntities(_rotationInputMask);
			foreach (Entity entity in entities)
			{
				RotationInput rotationInput = entity.Get<RotationInput>();
				rotationInput.value = _inputService.Rotate;
			}
		}
	}
}