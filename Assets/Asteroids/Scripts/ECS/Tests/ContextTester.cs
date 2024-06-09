using System.Collections.Generic;
using System.Linq;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using NUnit.Framework;

namespace Asteroids.Scripts.ECS.Tests
{
	public class ContextTester
	{
		[Test]
		public void TestEntityCreation()
		{
			Context context = new();
			Entity first = context.CreateEntity();
			Entity second = context.CreateEntity();

			Assert.AreNotEqual(first, null);
			Assert.AreNotEqual(second, null);
			Assert.AreNotEqual(first, second);
		}

		[Test]
		public void TestGetEntities()
		{
			Context context = new();
			Entity first = context.CreateEntity();
			Entity second = context.CreateEntity();
			Entity third = context.CreateEntity();

			IReadOnlyCollection<Entity> entities = context.GetEntities();
			Assert.IsTrue(entities.Contains(first));
			Assert.IsTrue(entities.Contains(second));
			Assert.IsTrue(entities.Contains(third));
		}
	}
}