using UnityEngine;
using UnityEngine.UI;

namespace Framework.Manager
{
	public class GameManager : Singleton<GameManager> {
		private int energy;
		[SerializeField] private Text energyText;

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
			energy = 0;
			energyText.text = energy.ToString();
		}

		public void addEnergy(int value) {
			energy += value;
			energyText.text = energy.ToString();
		}
	}
}
