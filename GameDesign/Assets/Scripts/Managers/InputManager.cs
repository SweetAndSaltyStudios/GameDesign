using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class InputManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("KEY BINDINGS")]

        [Space]

        [Header("PLAYER")]
        public KeyCode Move_Forward;
        public KeyCode Move_Right;
        public KeyCode Move_Left;
        public KeyCode Move_Back;
        public KeyCode Jump;
        public KeyCode Interaction;
        public KeyCode Run;

        [Header("OTHERS")]
        public KeyCode Pause;

        #endregion VARIABLES

        #region PROPERTIES

        public static InputManager Instance
        {
            get;
            private set;
        }

        public bool GetKeyDown_Move_Forward
        {
            get 
            {
                return Input.GetKeyDown(Move_Forward);
            }
        }
        public bool GetKeyDown_Move_Right
        {
            get 
            {
                return Input.GetKeyDown(Move_Right);
            }
        }
        public bool GetKeyDown_Move_Left
        {
            get 
            {
                return Input.GetKeyDown(Move_Left);
            }
        }
        public bool GetKeyDown_Move_Back
        {
            get 
            {
                return Input.GetKeyDown(Move_Back);
            }
        }
        public bool GetKeyDown_Jump
        {
            get 
            {
                return Input.GetKeyDown(Jump);
            }
        }
        public bool GetKeyDown_Interaction
        {
            get 
            {
                return Input.GetKeyDown(Interaction);
            }
        }
        public bool GetKeyDown_Run
        {
            get 
            {
                return Input.GetKeyDown(Run);
            }
        }
        public bool GetKeyDown_Pause
        {
            get 
            {
                return Input.GetKeyDown(Pause);
            }
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
