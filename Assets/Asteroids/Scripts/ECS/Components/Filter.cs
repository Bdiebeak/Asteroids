using System;
using System.Collections.Generic;

namespace Asteroids.Scripts.ECS.Components
{
	public class Filter : IFilter
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

		public Filter Include<TComponent>() where TComponent : IComponent
		{
			_includeComponents.Add(typeof(TComponent));
			return this;
		}

		public Filter Exclude<TComponent>() where TComponent : IComponent
		{
			_excludeComponents.Add(typeof(TComponent));
			return this;
		}
	}
}