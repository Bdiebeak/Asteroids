﻿using Asteroids.Scripts.Core.UI.Screens;
using Asteroids.Scripts.Core.Utilities.Services.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameStartState : BaseState
	{
		private readonly IScreenService _screenService;

		public GameStartState(IScreenService screenService)
		{
			_screenService = screenService;
		}

		public override void Enter()
		{
			_screenService.Show<GameStartScreen>();
		}
	}
}