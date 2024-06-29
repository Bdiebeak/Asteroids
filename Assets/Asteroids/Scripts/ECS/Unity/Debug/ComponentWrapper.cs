using System;
using Asteroids.Scripts.ECS.Components;
using UnityEngine;

namespace Asteroids.Scripts.ECS.Unity.Debug
{
	[Serializable]
	public class ComponentWrapper
	{
		[SerializeReference]
		public IComponent componentReference;

		public ComponentWrapper(IComponent componentReference)
		{
			this.componentReference = componentReference;
		}
	}
}