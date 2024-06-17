namespace Asteroids.Scripts.Core.Infrastructure.Services.Assets
{
	public interface IAssetProvider
	{
		TAsset Load<TAsset>(string path) where TAsset : class;
	}
}