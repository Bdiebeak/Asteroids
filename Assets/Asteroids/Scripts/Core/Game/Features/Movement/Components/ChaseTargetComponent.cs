using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Components
{
	public class ChaseTargetComponent : IComponent
	{
		public int targetEntityId;
	}
}