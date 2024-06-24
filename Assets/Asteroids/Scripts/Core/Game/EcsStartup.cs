using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Input;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game
{
	public class EcsStartup
	{
		private SystemsContainer _inputSystems;
		private SystemsContainer _gameplaySystems;
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly ISystemsFactory _systemsFactory;

		public EcsStartup(InputContext inputContext, GameplayContext gameplayContext,
						  ISystemsFactory systemsFactory)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_systemsFactory = systemsFactory;
		}

		public void Initialize()
		{
			InitializeInputSystems();
			InitializeGameplaySystems();
		}

		public void Start()
		{
			_inputSystems.Start();
			_gameplaySystems.Start();
		}

		public void Update()
		{
			_inputSystems.Update();
			_gameplaySystems.Update();
		}

		public void CleanUp()
		{
			_inputSystems.CleanUp();
			_gameplaySystems.CleanUp();
		}

		public void Stop()
		{
			_inputSystems.Stop();
			_gameplaySystems.Stop();
			_inputContext.Destroy();
			_gameplayContext.Destroy();
		}

		private void InitializeInputSystems()
		{
			_inputSystems = new SystemsContainer();
			_inputSystems.Add(new InputFeature(_systemsFactory));
		}

		private void InitializeGameplaySystems()
		{
			_gameplaySystems = new SystemsContainer();
			_gameplaySystems.Add(new GameplayFeature(_systemsFactory));
		}
	}
}