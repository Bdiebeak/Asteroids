using System.Linq;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using NUnit.Framework;

namespace Asteroids.Scripts.ECS.Tests
{
	public class ComponentsTester
	{
		private Context _context;
		private Entity _first;
		private Entity _second;
		private Entity _third;

		public ComponentsTester()
		{
			_context = new Context();

			_first = _context.CreateEntity();
			_first.Add<FirstComponent>();

			_second = _context.CreateEntity();
			_second.Add<FirstComponent>();
			_second.Add<SecondComponent>();

			_third = _context.CreateEntity();
		}

		[Test]
		public void TestInclude()
		{
			var entities = _context.GetEntities(new Mask().Include<FirstComponent>());
			Assert.IsTrue(entities.Contains(_first));
			Assert.IsTrue(entities.Contains(_second));
		}

		[Test]
		public void TestExclude()
		{
			var entities = _context.GetEntities(new Mask().Exclude<SecondComponent>());
			Assert.IsTrue(entities.Contains(_first));
			Assert.IsFalse(entities.Contains(_second));
			Assert.IsTrue(entities.Contains(_third));
		}

		[Test]
		public void TestIncludeAndExclude()
		{
			var entities = _context.GetEntities(new Mask().Include<FirstComponent>()
														 .Exclude<SecondComponent>());
			Assert.IsTrue(entities.Contains(_first));
			Assert.IsFalse(entities.Contains(_second));
		}
	}
}