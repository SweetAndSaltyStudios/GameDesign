using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public abstract class EventTrigger : MonoBehaviour
    {
        #region VARIABLES

        [Space]
        [Header("Object Visuals")]
        public bool ShowVisuals = false;

        private GameObject visualsGameObject;

        #endregion VARIABLES

        #region UNITY_FUNCTIONS

        private void Start()
        {
            SetVisuals();
        }

        private void OnValidate()
        {
            SetVisuals();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {         

        }

        protected virtual void OnTriggerExit(Collider other)
        {

        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private void SetVisuals()
        {
            if (visualsGameObject == null)
            {
                visualsGameObject = transform.GetChild(0).gameObject;
            }

            visualsGameObject.SetActive(ShowVisuals);
        }

        #endregion CUSTOM_FUNCTIONS      
    }
}