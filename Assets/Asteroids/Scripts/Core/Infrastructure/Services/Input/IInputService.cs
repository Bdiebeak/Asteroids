namespace Asteroids.Scripts.Core.Infrastructure.Services.Input
{
	public interface IInputService
	{
		bool BulletAttack { get; }
		bool LaserAttack { get; }
		float MoveForward { get; }
		float Rotate { get; }
		bool StartLevel { get; }
	}
}