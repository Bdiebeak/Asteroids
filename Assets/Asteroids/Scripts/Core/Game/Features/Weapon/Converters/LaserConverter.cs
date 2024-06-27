using System.Linq;
using Asteroids.Scripts.Core.Game.Converters;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.DI.Attributes;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Converters
{
	public class LaserConverter : MonoConverter
	{
		[SerializeField]
		private BoxCollider2D boxCollider;
		[SerializeField]
		private GameObject view;

		private ITimeService _timeService;

		[Inject]
		public void Construct(ITimeService timeService)
		{
			_timeService = timeService;
		}

		protected override void OnConvert(IContext context, Entity entity)
		{
			var playerEntities = context.GetEntities(new Mask().Include<PlayerMarker>());
			if (playerEntities.Count == 0)
			{
				Debug.LogError("Can't find player entity to follow.");
				return;
			}

			Entity player = playerEntities.First();
			entity.Add(new LaserMarker());
			entity.Add(new Position()).value = transform.position;
			entity.Add(new Rotation());
			entity.Add(new CopyTargetPosition()).target = player;
			entity.Add(new CopyTargetRotation()).target = player;
			// TODO: this is logic in monobeh isn't it?
			entity.Add(new DestroyAtTime()).value = _timeService.Time + WeaponsConfig.laserActiveTime;
			ConfigureViewSize();
		}

		private void ConfigureViewSize()
		{
			float thickness = WeaponsConfig.laserThickness;
			float length = WeaponsConfig.laserLength;
			Vector3 size = new(thickness, length, 1);
			Vector2 position = new(0, length / 2);
			boxCollider.offset = position;
			boxCollider.size = size;
			view.transform.localPosition = position;
			view.transform.localScale = size;
		}
	}
}