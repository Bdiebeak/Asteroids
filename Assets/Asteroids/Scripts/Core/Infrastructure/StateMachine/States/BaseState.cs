namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public abstract class BaseState
	{
		public virtual void Enter() { }
		public virtual void Update() { }
		public virtual void Exit() { }
	}
}