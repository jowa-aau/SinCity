using Framework.Types;
using UnityEngine;
using UnityEngine.UIElements;

namespace Framework.Manager
{
	/// <summary>
	/// This class is handles all user input and delegates it to registered listeners
	/// </summary>
	public class InputManager : Singleton<InputManager>
	{
		public delegate void OnButton0Event(InputManagerEventType type);
		public delegate void OnButton1Event(InputManagerEventType type);

		public static event OnButton0Event OnButton0;
		public static event OnButton1Event OnButton1;

		private static bool allowInput = true;

		/// <summary>
		/// private constructor because singleton
		/// </summary>
		private InputManager() { }

		/// <summary>
		/// Update is called once per frame.
		/// Catches "Jump" input and fires OnJump() event to all listeners
		/// </summary>
		private void Update() {
			if (allowInput) {
#if UNITY_STANDALONE
				if (Input.GetMouseButtonDown(0))  {
					OnButton0?.Invoke(InputManagerEventType.ButtonDown);
				}
				if (Input.GetMouseButtonDown(1)) {
					OnButton1?.Invoke(InputManagerEventType.ButtonDown);
				}
				if (Input.GetMouseButtonUp(0)) {
					OnButton0?.Invoke(InputManagerEventType.ButtonUp);
				}
				if (Input.GetMouseButtonUp(1)) {
					OnButton1?.Invoke(InputManagerEventType.ButtonUp);
				}
#elif UNITY_IOS || UNITY_ANDROID
				if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
					OnButton0Down?.Invoke();
				}
#endif
			}
		}

		/// <summary>
		/// Catches and retunrs current cursor postion.
		/// </summary>
		/// <returns>Returns a Vector3 with the current position of the cursor</returns>
		public static Vector3 GetCursorPosition()
		{
#if UNITY_STANDALONE
			return Input.mousePosition;
#endif
		}
	
		/// <summary>
		/// Catches and retunrs user input for specified axis.
		/// </summary>
		/// <param name="axis">The name of the axis as string. [Horizontal|Vertical]</param>
		/// <returns>Returns a float value of the axis</returns>
		/// <exception cref="System.ArgumentException">Raised when an axis does not exist.</exception>
		public static float GetAxis(string axis) {
			//TODO: implement Controller RT/LT movement
			if (allowInput) {
#if UNITY_STANDALONE
				if (axis == "Horizontal") {
					return Input.GetAxis("Mouse X");
				} else if (axis == "Vertical") {
					return Input.GetAxis("Mouse Y");
				}
#elif UNITY_IOS || UNITY_ANDROID
				if (axis == "Horizontal") {
					return Input.acceleration.x;
				} else if (axis == "Vertical") {
					return Input.acceleration.y;
				}
#endif
				throw new System.ArgumentException("Input axis \"" + axis + "\" does not exist!");
			}
			return 0;
		}

		/// <summary>
		/// Catches and retunrs user input for specified axis as raw [-1|0|1].
		/// </summary>
		/// <param name="axis">The name of the axis as string. [Horizontal|Vertical]</param>
		/// <returns>Returns a float value of the axis, althoug output will be [-1|0|1]</returns>
		/// <exception cref="System.ArgumentException">Raised when an axis does not exist.</exception>
		public static float GetAxisRaw(string axis) {
			if (allowInput) {
#if UNITY_STANDALONE
				return Input.GetAxisRaw(axis);
#elif UNITY_IOS || UNITY_ANDROID
			if (axis == "Horizontal") {
				if (Input.acceleration.x != 0) {
					return Input.acceleration.x > 0 ? 1 : -1;
				}
				return 0;
			} else if (axis == "Vertical") {
				if (Input.acceleration.y != 0) {
					return Input.acceleration.y > 0 ? 1 : -1;
				}
				return 0;
			}
			throw new System.ArgumentException("Input axis \"" + axis + "\" does not exist!");
#endif
			}
			return 0;
		}

		/// <summary>
		/// Disables all user input
		/// </summary>
		public static void disableInput() {
			allowInput = false;
		}

		/// <summary>
		/// Enables all user input
		/// </summary>
		public static void enableInput() {
			allowInput = true;
		}
	}
}
