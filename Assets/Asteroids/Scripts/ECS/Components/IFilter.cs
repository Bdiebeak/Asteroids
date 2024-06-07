using System;
using System.Collections.Generic;

namespace Asteroids.Scripts.ECS.Components
{
	public interface IFilter
	{
		IReadOnlyCollection<Type> GetIncluded();
		IReadOnlyCollection<Type> GetExcluded();
		Filter Include<TComponent>() where TComponent : IComponent;
		Filter Exclude<TComponent>() where TComponent : IComponent;
	}
}