using System.Collections.Generic;
using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Converters.Base;
using Asteroids.Scripts.DI.Attributes;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Converters
{
	[DisallowMultipleComponent]
	public class MonoConvertersContainer : MonoBehaviour, IConvertersContainer
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