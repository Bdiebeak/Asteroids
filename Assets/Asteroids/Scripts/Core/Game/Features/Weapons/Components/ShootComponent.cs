using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Components
{
	/// <summary>
	/// This component could be an event, but I decided not to use it.
	/// It's more convenient to handle filtering in systems with a component than events.
	/// </summary>
	public class ShootComponent : IComponent { }
}