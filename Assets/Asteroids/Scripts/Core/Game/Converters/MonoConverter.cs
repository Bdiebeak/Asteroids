using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Converters;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Converters
{
	[RequireComponent(typeof(MonoComponentsContainer))]
	public abstract class MonoConverter : MonoBehaviour, IConverter
	{
		public void Convert(IContext context, Entity entity)
		{
			OnConvert(context, entity);
			Destroy(this);
		}

		protected abstract void OnConvert(IContext context, Entity entity);
	}
}