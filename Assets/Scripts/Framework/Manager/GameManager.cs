using System.Collections.Generic;
using Framework.Types;
using UnityEngine;
using UnityEngine.UI;

namespace Framework.Manager
{
	public class GameManager : Singleton<GameManager> {
		[SerializeField] private Text antCounterText;
		[SerializeField] private int antsPerSecond = 3;
		[SerializeField] private int maxAnts = 100;
		[SerializeField] private List<GameObject> antPrefabs;

		private int antCounter;
		private bool isGameOver = false;
		
		
		/// <summary>
		/// private constructor because singleton
		/// </summary>
		private GameManager() { }

		/// <summary>
		/// Used for initializion.
		/// Start is only called if the script component is enabled.
		/// It is also called after Awake
		/// </summary>
		protected void Start() {
			antCounter = 0;
			antCounterText.text = antCounter.ToString();
			GameObject gameover = GameObject.Find("GameOverScreen");
			GameObject gameoverText = GameObject.Find("GameOverText");
			gameover.transform.localScale = new Vector3(0, 0, 0);
			gameoverText.transform.localScale = new Vector3(0, 0, 0);
		}

		public List<GameObject> GetAntPrefabs()
		{
			return antPrefabs;
		}

		public int GetMaxAnts()
		{
			return maxAnts;
		}

		public int GetAntCounter()
		{
			return antCounter;
		}

		public int GetAntsPerSecond()
		{
			return antsPerSecond;
		}
		
		public void addAnts(int value) {
			antCounter = antCounter + value <= maxAnts ? antCounter + value : maxAnts;
			antCounterText.text = antCounter.ToString();

			float percent = 1.0f - (float) antCounter / maxAnts;
			
			antCounterText.color = new Color(0.762f, percent, 0.0f);
		}

		public void removeAnts(int value)
		{
			antCounter = antCounter - value >= 0 ? antCounter - value : 0;
			antCounterText.text = antCounter.ToString();
			float percent = 1.0f - (float) antCounter / maxAnts;
			antCounterText.color = new Color(0.762f, percent, 0.0f);
		}

		private void Update()
		{
			if (maxAnts <= antCounter && !isGameOver)
			{
				GameObject gameover = GameObject.Find("GameOverScreen");
				GameObject gameoverText = GameObject.Find("GameOverText");
				gameover.transform.localScale = new Vector3(5.88f, 3f, 1f);
				gameoverText.transform.localScale = new Vector3(0.18f, 0.33f, 1);
				isGameOver = true;
			}
		}
	}
}
