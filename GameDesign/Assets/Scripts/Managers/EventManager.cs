using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class EventManager : MonoBehaviour
    {
        #region VARIABLES

        #endregion VARIABLES

        #region PROPERTIES

        public static EventManager Instance
        {
            get;
            private set;
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS


        #endregion CUSTOM_FUNCTIONS
    }
}
