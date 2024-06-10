namespace Asteroids.Scripts.Core.Infrastructure.Services.Input
{
	public interface IInputService
	{
		float HorizontalInput { get; }
		float VerticalInput { get; }
		bool IsFiringPressed { get; }
		bool IsStartLevelPressed { get; }
	}
}