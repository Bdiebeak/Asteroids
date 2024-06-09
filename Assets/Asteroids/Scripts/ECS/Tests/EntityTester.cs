using System.Linq;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using NUnit.Framework;

namespace Asteroids.Scripts.ECS.Tests
{
	public class EntityTester
	{
		[Test]
		public void TestAddComponent()
		{
			Context context = new();
			Entity entity = context.CreateEntity();
			FirstComponent component = entity.Add<FirstComponent>();

			Assert.IsNotNull(component);
			Assert.IsTrue(entity.GetComponents().Contains(component));
			Assert.IsTrue(entity.GetComponents().Count() == 1);
		}

		[Test]
		public void TestGetComponent()
		{
			Context context = new();
			Entity entity = context.CreateEntity();
			FirstComponent component = entity.Add<FirstComponent>();
			FirstComponent getComponent = entity.Get<FirstComponent>();

			Assert.IsNotNull(getComponent);
			Assert.AreEqual(component, getComponent);
		}

		[Test]
		public void TestHasComponent()
		{
			Context context = new();
			Entity entity = context.CreateEntity();
			entity.Add<FirstComponent>();

			Assert.IsTrue(entity.Has<FirstComponent>());
		}

		[Test]
		public void TestRemoveComponent()
		{
			Context context = new();
			Entity entity = context.CreateEntity();
			entity.Add<FirstComponent>();
			entity.Remove<FirstComponent>();

			Assert.IsFalse(entity.Has<FirstComponent>());
		}

		[Test]
		public void TestDestroy()
		{
			Context context = new();
			Entity entity = context.CreateEntity();
			entity.Add<FirstComponent>();
			context.DestroyEntity(entity);

			Assert.IsFalse(entity.Has<FirstComponent>());
		}
	}
}