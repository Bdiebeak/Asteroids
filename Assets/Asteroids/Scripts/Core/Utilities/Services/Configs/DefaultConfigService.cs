namespace Asteroids.Scripts.Core.Utilities.Services.Configs
{
	public class DefaultConfigService : IConfigService
	{
		public PlayerConfig PlayerConfig { get; } = new();
		public AsteroidConfig AsteroidConfig { get; } = new();
		public AsteroidPieceConfig AsteroidPieceConfig { get; } = new();
		public UfoConfig UfoConfig { get; } = new();
		public BulletWeaponConfig BulletWeaponConfig { get; } = new();
		public LaserWeaponConfig LaserWeaponConfig { get; } = new();
	}
}