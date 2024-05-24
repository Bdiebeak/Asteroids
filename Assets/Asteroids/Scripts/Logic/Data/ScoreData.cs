namespace Asteroids.Scripts.Logic.Data
{
	public class ScoreData
	{
		public int Score { get; private set; }

		public void AddScore(int score)
		{
			Score += score;
		}

		public void ResetScore()
		{
			Score = 0;
		}
	}
}