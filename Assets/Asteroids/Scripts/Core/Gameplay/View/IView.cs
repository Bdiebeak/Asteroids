using System.Numerics;

namespace Asteroids.Scripts.Core.Gameplay.View
{
	public interface IView
	{
		void SetPosition(Vector2 position);
		void SetRotation(float angle);
		void Destroy();
	}
}