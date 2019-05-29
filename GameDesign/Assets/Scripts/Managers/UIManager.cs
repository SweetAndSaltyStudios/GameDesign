using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class UIManager : MonoBehaviour
    {
        #region VARIABLES

        public CutsceneTextBox_UI CutsceneTextBox_UI;

        #endregion VARIABLES

        #region PROPERTIES

        public static UIManager Instance
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
    }
}
