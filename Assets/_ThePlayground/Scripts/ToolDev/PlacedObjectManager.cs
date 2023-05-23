using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;

using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ExoDev.ThePlayground.ToolDev
{
    public class PlacedObjectManager : MonoBehaviour
    {
		#region Variables

		[Title("Variables")]

		[ShowInInspector, ReadOnly]
		public static List<PlacedObject> allPlacedObjects = new();

		#endregion
		#region Unity Methods

		#if UNITY_EDITOR
		private void OnDrawGizmos()
        {
			Handles.zTest = CompareFunction.LessEqual;

			foreach (PlacedObject obj in allPlacedObjects) 
			{
				Vector3 managerPos = transform.position;
				Vector3 objectPos = obj.transform.position;
				float halfHeight = (managerPos.y - objectPos.y) * 0.5f;
				Vector3 offset = Vector3.up * halfHeight;

				Handles.DrawBezier
				(
					managerPos, 
					objectPos, 
					managerPos - offset, 
					objectPos + offset, 
					obj.color, 
					EditorGUIUtility.whiteTexture, 
					1f
				);
			}
        }
		#endif

		#endregion
		#region Public Methods
		#endregion
		#region Private Methods
		#endregion
	}
}

