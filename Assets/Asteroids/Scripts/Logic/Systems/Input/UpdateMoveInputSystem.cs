using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using Asteroids.Scripts.Logic.Components;
using Asteroids.Scripts.Logic.Infrastructure.Services;

namespace Asteroids.Scripts.Logic.Systems.Input
{
	public class UpdateMoveInputSystem : IUpdateSystem
	{
		private readonly IContext _inputContext;
		private readonly IInputService _inputService;
		private readonly Filter _filter;

		public UpdateMoveInputSystem(IContext inputContext, IInputService inputService)
		{
			_inputContext = inputContext;
			_inputService = inputService;
			_filter = new Filter().Include<MoveInputComponent>();
		}

		public void Update(float deltaTime)
		{
			var inputEntities = _inputContext.GetEntities(_filter);
			foreach (Entity inputEntity in inputEntities)
			{
				MoveInputComponent moveInput = inputEntity.Get<MoveInputComponent>();
				moveInput.value.X = _inputService.HorizontalInput;
				moveInput.value.Y = _inputService.VerticalInput;
			}
		}
	}
}