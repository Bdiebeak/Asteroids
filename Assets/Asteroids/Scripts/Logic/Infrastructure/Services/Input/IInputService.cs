﻿namespace Asteroids.Scripts.Logic.Infrastructure.Services.Input
{
	public interface IInputService
	{
		float HorizontalInput { get; }
		float VerticalInput { get; }
		bool IsFiring { get; }

		void Initialize();
	}
}