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
		[SerializeField] private BoxCollider2D bounds;
		
		private new UnityEngine.Camera camera;
		private bool isMovementEnabled;
		private Vector3 cursorWorldPositionOrigin;
		
		private Vector3
			min,
			max;
		
		// <summary>
		/// Used for initializion.
		/// Start is only called if the script component is enabled.
		/// It is also called after Awake
		/// </summary>
		protected void Start()
		{
			if (bounds) {
				min = bounds.bounds.min;
				max = bounds.bounds.max;
			}
			
			camera = GetComponent<UnityEngine.Camera>();
			InputManager.OnButton1 += HandleButton1Event;
		}

		/// <summary>
		/// Update is called once per frame.
		/// Moves the camera on button2
		/// </summary>
		private void LateUpdate() {
#if UNITY_STANDALONE
			if (!isMovementEnabled) return;
			
			Vector3 currentCameraPosition = camera.transform.position;
			Vector3 currentCursorWorldPosition = camera.ScreenToWorldPoint(InputManager.GetCursorPosition());
			
			float x = currentCameraPosition.x - (currentCursorWorldPosition.x - cursorWorldPositionOrigin.x);
			float y = currentCameraPosition.y - (currentCursorWorldPosition.y - cursorWorldPositionOrigin.y);
			
			float cameraHalfWidth = camera.orthographicSize * ((float) Screen.width / Screen.height);
			
			if (bounds) {
				x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
				y = Mathf.Clamp(y, min.y + camera.orthographicSize, max.y - camera.orthographicSize);
			}
			
			camera.transform.position = new Vector3(x, y, currentCameraPosition.z);
#endif
		}

		protected virtual void HandleButton1Event(InputManagerEventType type) {
			if (type == InputManagerEventType.ButtonDown) {
				cursorWorldPositionOrigin = camera.ScreenToWorldPoint(InputManager.GetCursorPosition());
				isMovementEnabled = true;
			}
			else if(type == InputManagerEventType.ButtonUp) {
				isMovementEnabled = false;
			}
		}
	}
}
