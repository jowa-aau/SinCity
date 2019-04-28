using Framework.Manager;
using UnityEngine;

namespace Framework
{
	/// <summary>
	/// Bootstrap class for initialization of managers and other important scripts
	/// </summary>
	public class Bootstrap : MonoBehaviour {
		/// <summary>
		/// Used for initializion.
		/// Awake always called in random order.
		/// It is called befor Start
		/// </summary>
		void Awake() {
			InputManager.Instance.Init();
			GameManager.Instance.Init();
			AntManager.Instance.Init();
		}
	}
}