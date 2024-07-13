namespace Asteroids.Scripts.Core.Utilities.Services.Configs
{
	public interface IConfigService
	{
		PlayerConfig PlayerConfig { get; }
		AsteroidConfig AsteroidConfig { get; }
		AsteroidPieceConfig AsteroidPieceConfig { get; }
		UfoConfig UfoConfig { get; }
		BulletWeaponConfig BulletWeaponConfig { get; }
		LaserWeaponConfig LaserWeaponConfig { get; }
	}
}