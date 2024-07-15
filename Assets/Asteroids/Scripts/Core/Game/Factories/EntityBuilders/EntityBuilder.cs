using System;
using System.Collections.Generic;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Factories.EntityBuilders
{
	public abstract class EntityBuilder
	{
		private readonly HashSet<IComponent> _components = new();

		public Entity Build(IContext context)
		{
			Entity entity = context.CreateEntity();
			ConfigureEntity(context, entity);
			AddPresetComponents(entity);
			return entity;
		}

		public EntityBuilder With<TComponent>(TComponent component) where TComponent : IComponent
		{
			_components.Add(component);
			return this;
		}

		protected abstract void ConfigureEntity(IContext context, Entity entity);

		private void AddPresetComponents(Entity entity)
		{
			foreach (IComponent component in _components)
			{
				Type componentType = component.GetType();
				if (entity.Has(componentType))
				{
					entity.Remove(componentType);
				}
				entity.Add(component);
			}
		}
	}
}