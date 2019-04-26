using UnityEngine;

namespace Framework.Extensions
{
	/// <summary>
	/// Extends functionality of UnityEngine.Transform
	/// </summary>
	public static class TransformExtension {
		/// <summary>
		/// Resets transform to zero
		/// </summary>
		/// <param name="trans">extension object</param>
		public static void ResetTransform(this Transform trans) {
			trans.position = Vector3.zero;
			trans.localRotation = Quaternion.identity;
			trans.localScale = new Vector3(1, 1, 1);
		}
	}
}
