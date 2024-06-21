using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Input.Systems;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.ECS.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Input
{
	public class InputFeature : Feature
	{
		private readonly InputContext _inputContext;
		private readonly IInputService _inputService;

		public InputFeature(InputContext inputContext, IInputService inputService)
		{
			_inputContext = inputContext;
			_inputService = inputService;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new InitializeInputSystem(_inputContext));
			systems.Add(new UpdateMoveInputSystem(_inputContext, _inputService));
			systems.Add(new UpdateRotateInputSystem(_inputContext, _inputService));
			systems.Add(new UpdateBulletAttackInputSystem(_inputContext, _inputService));
			systems.Add(new UpdateLaserAttackInputSystem(_inputContext, _inputService));
		}
	}
}