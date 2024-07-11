using System.Linq;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Events;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.ECS.Unity.Debug.Systems
{
	public class EventsLogSystem : IUpdateSystem
	{
		private readonly IContext _context;

		public EventsLogSystem(IContext context)
		{
			_context = context;
		}

		public void Update()
		{
			var entities = _context.GetEntities();
			foreach (Entity entity in entities)
			{
				var eventComponents = entity.GetComponents().Where(x => x is IEvent);
				foreach (IComponent component in eventComponents)
				{
					IEvent eventComponent = (IEvent)component;
					UnityEngine.Debug.Log($"{eventComponent.GetType().Name} was called.");
				}
			}
		}
	}
}