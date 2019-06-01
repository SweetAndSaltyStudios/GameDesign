using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class CutsceneTrigger : EventTrigger
    {
        #region VARIABLES

        [Space]
        [Header("REFERENCES")]
        public Sprite CutsceneImageToShow;

        #endregion VARIABLES

        #region UNITY_FUNCTIONS

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (SingleInvoke && invokeCounter > 0)
            {
                return;
            }

            if (FreezeGame)
            {
                if (iFreezeGame_Coroutine == null)
                {
                    iFreezeGame_Coroutine = StartCoroutine(IFreezeGame(() => UIManager.Instance.CutsceneTextBox_UI.HideCutscene()));
                }
            }

            UIManager.Instance.CutsceneTextBox_UI.ShowCutscene(CutsceneImageToShow, FreezeGame);

            invokeCounter++;

        }

        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);

            UIManager.Instance.CutsceneTextBox_UI.HideCutscene();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS


        #endregion CUSTOM_FUNCTIONS
    }
}
