namespace Asteroids.Scripts.Core.Utilities.Services.Assets
{
	public interface IAssetProvider
	{
		TAsset Load<TAsset>(string path) where TAsset : class;
	}
}