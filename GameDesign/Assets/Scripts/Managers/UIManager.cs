using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class UIManager : MonoBehaviour
    {
        #region VARIABLES

        [Space]
        [Header("REFERENCES")]
        public UI_ItemToolTip UI_ItemToolTip;
        public UI_CutsceneToolTip CutsceneTextBox_UI;
        public Cursor Cursor;
        public Inventory Inventory;

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
