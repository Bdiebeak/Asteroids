namespace Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider
{
	public interface IAssetProvider
	{
		TAsset Load<TAsset>(string key) where TAsset : class;
	}
}