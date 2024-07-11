using System.Linq;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.ECS.Unity.Debug.Systems
{
	public class RequestsLogSystem : IUpdateSystem
	{
		private readonly IContext _context;

		public RequestsLogSystem(IContext context)
		{
			_context = context;
		}

		public void Update()
		{
			var entities = _context.GetEntities();
			foreach (Entity entity in entities)
			{
				var eventComponents = entity.GetComponents().Where(x => x is IRequest);
				foreach (IComponent component in eventComponents)
				{
					IRequest eventComponent = (IRequest)component;
					UnityEngine.Debug.Log($"{eventComponent.GetType().Name} was invoked.");
				}
			}
		}
	}
}