﻿namespace Asteroids.Scripts.Core.Utilities.Services.Time
{
	public class UnityTimeService : ITimeService
	{
		public float Time => UnityEngine.Time.time;
		public float DeltaTime => UnityEngine.Time.deltaTime;
	}
}