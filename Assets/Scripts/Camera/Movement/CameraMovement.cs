using Framework.Manager;
using Framework.Types;
using UnityEngine;

namespace Camera.Movement
{
	/// <summary>
	/// Handles the gravity tilt movement and the camera movement around the Z axis
	/// </summary>
	[RequireComponent(typeof(UnityEngine.Camera))]
	public class CameraMovement : MonoBehaviour {
		[SerializeField] private float speed = 2f;

		private Vector3 origin;
		private new UnityEngine.Camera camera;
		private bool isMovementEnabled;
		
		// <summary>
		/// Used for initializion.
		/// Start is only called if the script component is enabled.
		/// It is also called after Awake
		/// </summary>
		protected void Start()
		{
			camera = GetComponent<UnityEngine.Camera>();
			InputManager.OnButton1 += HandleButton1Event;
		}

		/// <summary>
		/// Update is called once per frame.
		/// Tilts the camera around Z axis
		/// </summary>
		private void Update() {
#if UNITY_STANDALONE
			if (!isMovementEnabled) return;
			Debug.Log("moving");
			Vector3 pos = camera.ScreenToViewportPoint(Input.mousePosition - origin);
			Vector3 move = new Vector3(pos.x * speed, pos.y * speed, origin.z);
			transform.Translate(move, Space.World);
#endif
		}

		protected virtual void HandleButton1Event(InputManagerEventType type) {
			if (type == InputManagerEventType.ButtonDown) {
				origin = Input.mousePosition;
				isMovementEnabled = true;
			}
			else if(type == InputManagerEventType.ButtonUp) {
				isMovementEnabled = false;
			}
		}
	}
}
