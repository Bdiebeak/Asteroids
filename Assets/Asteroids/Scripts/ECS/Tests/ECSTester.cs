using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Asteroids.Scripts.ECS.Tests
{
	public class ECSTester
	{
		// A Test behaves as an ordinary method
		[Test]
		public void NewTestScriptSimplePasses()
		{
			// Use the Assert class to test conditions
		}

		// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
		// `yield return null;` to skip a frame.
		[UnityTest]
		public IEnumerator NewTestScriptWithEnumeratorPasses()
		{
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
			yield return null;
		}
	}
}
