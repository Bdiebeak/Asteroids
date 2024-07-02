using System.Collections.Generic;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.ECS.Systems.Container
{
	public class SystemsContainer
	{
		private readonly List<IStartSystem> _startSystems = new();
		private readonly List<IUpdateSystem> _updateSystems = new();
		private readonly List<IDestroySystem> _destroySystems = new();

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
			if (system is IDestroySystem destroySystem)
			{
				_destroySystems.Add(destroySystem);
			}

			return this;
		}

		public void Start()
		{
			for (int i = 0; i < _startSystems.Count; i++)
			{
				_startSystems[i].Start();
			}
		}

		public void Update()
		{
			for (int i = 0; i < _updateSystems.Count; i++)
			{
				_updateSystems[i].Update();
			}
		}

		public void Destroy()
		{
			for (int i = 0; i < _destroySystems.Count; i++)
			{
				_destroySystems[i].Destroy();
			}

			_startSystems.Clear();
			_updateSystems.Clear();
			_destroySystems.Clear();
		}
	}
}