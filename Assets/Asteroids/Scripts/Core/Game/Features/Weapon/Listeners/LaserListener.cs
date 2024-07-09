using Asteroids.Scripts.Core.Game.Views;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Listeners
{
	public class LaserListener : EcsListener
	{
		[SerializeField]
		private BoxCollider2D boxCollider;
		[SerializeField]
		private GameObject view;

		public override void Initialize(Entity entity)
		{
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