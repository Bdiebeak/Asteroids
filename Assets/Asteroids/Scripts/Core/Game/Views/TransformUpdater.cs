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
			if (_entity.Has<Position>())
			{
				Position position = _entity.Get<Position>();
				transform.position = position.value;
			}

			if (_entity.Has<Rotation>())
			{
				Rotation rotation = _entity.Get<Rotation>();
				transform.rotation = Quaternion.Euler(0, 0, rotation.value);
			}
		}
	}
}