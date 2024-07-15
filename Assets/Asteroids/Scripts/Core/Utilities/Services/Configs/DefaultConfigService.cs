namespace Asteroids.Scripts.Core.Utilities.Services.Configs
{
	public class DefaultConfigService : IConfigService
	{
		public PlayerConfig PlayerConfig { get; }
		public AsteroidConfig AsteroidConfig { get; }
		public AsteroidPieceConfig AsteroidPieceConfig { get; }
		public UfoConfig UfoConfig { get; }
		public BulletWeaponConfig BulletWeaponConfig { get; }
		public LaserWeaponConfig LaserWeaponConfig { get; }

		public DefaultConfigService()
		{
			PlayerConfig = new PlayerConfig();
			AsteroidConfig = new AsteroidConfig();
			AsteroidPieceConfig = new AsteroidPieceConfig();
			UfoConfig = new UfoConfig();
			BulletWeaponConfig = new BulletWeaponConfig();
			LaserWeaponConfig = new LaserWeaponConfig();
		}
	}
}