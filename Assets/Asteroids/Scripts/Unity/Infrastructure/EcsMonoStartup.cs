using Asteroids.Scripts.Logic.Infrastructure;
using Asteroids.Scripts.Unity.Infrastructure.Services;
using UnityEngine;

namespace Asteroids.Scripts.Unity.Infrastructure
{
	public class EcsMonoStartup : MonoBehaviour
	{
		public ViewFactory viewFactory;
		public EcsDebugger ecsDebugger;

		private readonly EcsStartup _ecsStartup = new();

		private void Awake()
		{
			UnityInputService inputService = new();
			inputService.Initialize();
			_ecsStartup.Initialize(inputService, viewFactory);
			_ecsStartup.InitializeDebug(ecsDebugger);
		}

		private void Start()
		{
			_ecsStartup.Start();
		}

		private void Update()
		{
			_ecsStartup.Update(Time.deltaTime);
		}

		private void LateUpdate()
		{
			_ecsStartup.CleanUp();
		}

		private void OnDisable()
		{
			_ecsStartup.Stop();
		}
	}
}