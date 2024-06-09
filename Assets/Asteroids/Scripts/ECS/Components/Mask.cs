using System;
using System.Collections.Generic;

namespace Asteroids.Scripts.ECS.Components
{
	public class Mask
	{
		private readonly HashSet<Type> _includeComponents = new();
		private readonly HashSet<Type> _excludeComponents = new();

		public IReadOnlyCollection<Type> GetIncluded()
		{
			return _includeComponents;
		}

		public IReadOnlyCollection<Type> GetExcluded()
		{
			return _excludeComponents;
		}

		public Mask Include<TComponent>() where TComponent : IComponent
		{
			_includeComponents.Add(typeof(TComponent));
			return this;
		}

		public Mask Exclude<TComponent>() where TComponent : IComponent
		{
			_excludeComponents.Add(typeof(TComponent));
			return this;
		}
	}
}