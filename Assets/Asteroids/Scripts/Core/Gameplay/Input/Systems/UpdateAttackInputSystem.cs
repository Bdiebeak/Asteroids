﻿using Asteroids.Scripts.Core.Gameplay.Input.Components;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.Input.Systems
{
	public class UpdateAttackInputSystem : IUpdateSystem
	{
		private readonly IContext _inputContext;
		private readonly IInputService _inputService;
		private readonly Mask _mask;

		public UpdateAttackInputSystem(IContext inputContext, IInputService inputService)
		{
			_inputContext = inputContext;
			_inputService = inputService;
			_mask = new Mask().Include<BulletAttackInputComponent>()
							  .Include<LaserAttackInputComponent>();
		}

		public void Update(float deltaTime)
		{
			var inputEntities = _inputContext.GetEntities(_mask);
			foreach (Entity inputEntity in inputEntities)
			{
				BulletAttackInputComponent bulletInput = inputEntity.Get<BulletAttackInputComponent>();
				bulletInput.value = _inputService.BulletAttack;

				LaserAttackInputComponent laserInput = inputEntity.Get<LaserAttackInputComponent>();
				laserInput.value = _inputService.LaserAttack;
			}
		}
	}
}