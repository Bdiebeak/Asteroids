using System;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.ECS.Entities
{
	public interface IEntity
	{
		int Id { get; }

		TComponent Add<TComponent>() where TComponent : IComponent, new();
		TComponent Get<TComponent>() where TComponent : IComponent;
		bool Has<TComponent>() where TComponent : IComponent;
		bool Has(Type componentType);
		void Remove<TComponent>() where TComponent : IComponent;
	}
}