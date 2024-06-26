using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Components
{
	public class DestroyRequestComponent : IComponent
	{
		public Entity target;
	}
}