using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Components
{
	public class FollowPosition : IComponent
	{
		public Entity target;
	}
}