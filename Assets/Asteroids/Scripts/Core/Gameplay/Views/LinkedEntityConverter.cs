using Asteroids.Scripts.Core.Gameplay.Converters;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Gameplay.Views
{
	public class LinkedEntityConverter : MonoConverter
	{
		[SerializeField]
		private bool destroyObjectWithEntity = true;

		protected override void OnConvert(IContext context, Entity entity)
		{
			if (gameObject.TryGetComponent(out LinkedEntityReference linkedEntity) == false)
			{
				linkedEntity = gameObject.AddComponent<LinkedEntityReference>();
			}
			linkedEntity.Initialize(entity, destroyObjectWithEntity);
		}
	}
}