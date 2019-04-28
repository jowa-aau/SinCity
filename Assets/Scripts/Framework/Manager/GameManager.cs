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
			InputManager.OnButton0 += HandleButton0Event;
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

		private void HandleButton0Event(InputManagerEventType type)
		{
			if (type == InputManagerEventType.ButtonDown) {
				removeAnts(5);
			}
		}
		
	}
}
