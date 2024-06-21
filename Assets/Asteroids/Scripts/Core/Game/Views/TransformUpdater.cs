using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Views
{
	public class TransformUpdater : MonoBehaviour
	{
		private Entity _entity;

		public void Initialize(Entity entity)
		{
			_entity = entity;
		}

		private void Update()
		{
			if (_entity.Has<PositionComponent>())
			{
				PositionComponent position = _entity.Get<PositionComponent>();
				transform.position = position.value;
			}

			if (_entity.Has<RotationComponent>())
			{
				RotationComponent rotation = _entity.Get<RotationComponent>();
				transform.rotation = Quaternion.Euler(0, 0, rotation.value);
			}
		}
	}
}