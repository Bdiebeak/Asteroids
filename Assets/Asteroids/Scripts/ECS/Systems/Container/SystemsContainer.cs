using System.Collections.Generic;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.ECS.Systems.Container
{
	public class SystemsContainer
	{
		private readonly List<IStartSystem> _startSystems = new();
		private readonly List<IUpdateSystem> _updateSystems = new();
		private readonly List<ICleanUpSystem> _cleanUpSystems = new();
		private readonly List<IStopSystem> _stopSystems = new();

		public SystemsContainer Add(Feature feature)
		{
			feature.AddTo(this);
			return this;
		}

		public SystemsContainer Add(ISystem system)
		{
			if (system is IStartSystem startSystem)
			{
				_startSystems.Add(startSystem);
			}
			if (system is IUpdateSystem updateSystem)
			{
				_updateSystems.Add(updateSystem);
			}
			if (system is ICleanUpSystem cleanUpSystem)
			{
				_cleanUpSystems.Add(cleanUpSystem);
			}
			if (system is IStopSystem stopSystem)
			{
				_stopSystems.Add(stopSystem);
			}

			return this;
		}

		public void Start()
		{
			foreach (IStartSystem system in _startSystems)
			{
				system.Start();
			}
		}

		public void Update()
		{
			foreach (IUpdateSystem system in _updateSystems)
			{
				system.Update();
			}
		}

		public void CleanUp()
		{
			foreach (ICleanUpSystem system in _cleanUpSystems)
			{
				system.CleanUp();
			}
		}

		public void Stop()
		{
			foreach (IStopSystem system in _stopSystems)
			{
				system.Stop();
			}
		}
	}
}