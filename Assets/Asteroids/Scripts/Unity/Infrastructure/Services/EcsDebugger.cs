using System.Collections.Generic;
using System.Text;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.Logic.Infrastructure.Services;
using UnityEngine;

namespace Asteroids.Scripts.Unity.Infrastructure.Services
{
	public class EcsDebugger : MonoBehaviour, IEcsDebugger
	{
		private List<IContext> _contexts = new();

		public void SetContexts(params IContext[] contexts)
		{
			_contexts.AddRange(contexts);
		}

		[ContextMenu("Print")]
		private void PrintInfo()
		{
			int i = 1;
			StringBuilder logBuilder = new();
			foreach (IContext context in _contexts)
			{
				logBuilder.AppendLine($"Context {i}.");
				foreach (Entity entity in context.GetEntities())
				{
					logBuilder.AppendLine($"Entity:");
					foreach (IComponent component in entity.GetComponents())
					{
						logBuilder.AppendLine($"\t-{component.GetType().Name}");
					}
				}
				i++;
			}
			Debug.Log(logBuilder);
		}
	}
}