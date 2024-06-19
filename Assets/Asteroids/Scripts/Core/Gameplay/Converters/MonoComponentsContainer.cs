using System.Collections.Generic;
using Asteroids.Scripts.Core.Gameplay.Contexts;
using Asteroids.Scripts.DI.Resolver;
using Asteroids.Scripts.ECS.Converters;
using UnityEngine;

namespace Asteroids.Scripts.Core.Gameplay.Converters
{
	[DisallowMultipleComponent]
	public class MonoComponentsContainer : MonoBehaviour, IComponentsContainer
	{
		[SerializeField]
		private List<MonoConverter> converters = new();

		public IReadOnlyList<IConverter> Converters => converters;

		[Inject]
		public void Construct(GameplayContext context)
		{
			context.ConvertContainer(this);
			Destroy(this);
		}
	}
}