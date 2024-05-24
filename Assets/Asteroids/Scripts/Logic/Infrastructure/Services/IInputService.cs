namespace Asteroids.Scripts.Logic.Infrastructure.Services
{
	public interface IInputService
	{
		float HorizontalInput { get; }
		float VerticalInput { get; }
		bool IsFiringPressed { get; }
		bool IsStartLevelPressed { get; }
	}
}