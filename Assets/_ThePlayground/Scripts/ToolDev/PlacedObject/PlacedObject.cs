using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ExoDev.ThePlayground.ToolDev
{
    [ExecuteAlways]
    public class PlacedObject : MonoBehaviour
    {
        #region Variables

        [SerializeField, Range(1f, 10f)]
        private float radius = 1f;

        public Color color = Color.red;

        static readonly int shPropColor = Shader.PropertyToID("_Color");

        private MaterialPropertyBlock mpb;
        private MaterialPropertyBlock Mpb 
        {
            get 
            {
                if (mpb == null) 
                {
                    mpb = new();
                }
                return mpb;
            }
        }

        #endregion
        #region Unity Methods

        private void OnValidate()
        {
            ApplyColor();
        }

        private void OnEnable()
        {
            ApplyColor();
            PlacedObjectManager.allPlacedObjects.Add(this);
        }

        private void OnDisable()
        {
            PlacedObjectManager.allPlacedObjects.Remove(this);
        }

        #if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Handles.color = color;
            Handles.DrawWireDisc(transform.position, transform.up, radius);
            //Gizmos.DrawWireSphere(transform.position, radius);
            Handles.color = Color.white;
        }
        #endif

        #endregion
        #region Public Methods
        #endregion
        #region Private Methods

        private void ApplyColor()
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            Mpb.SetColor(shPropColor, color);
            render.SetPropertyBlock(Mpb);
        }

        #endregion
    }
}
