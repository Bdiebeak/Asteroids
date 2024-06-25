namespace Asteroids.Scripts.Core.Utilities.Services.Time
{
	public interface ITimeService
	{
		float Time { get; }
		float DeltaTime { get; }
	}
}