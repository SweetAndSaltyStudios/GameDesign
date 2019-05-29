using System.Collections;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class CutsceneTrigger : EventTrigger
    {
        #region VARIABLES

        [Space]
        [Header("REFERENCES")]
        public Sprite CutsceneImageToShow;

        [Space]
        [Header("EVENT VARIABLES")]
        public bool SingleInvoke;
        public bool FreezeGame;

        private int invokeCounter;
        private Coroutine iFreezeGame_Coroutine;

        #endregion VARIABLES

        #region UNITY_FUNCTIONS

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if(SingleInvoke && invokeCounter > 0)
            {
                return;
            }

            if (FreezeGame)
            {
                if (iFreezeGame_Coroutine == null)
                {
                    iFreezeGame_Coroutine = StartCoroutine(IFreezeGame());
                }
            }

            UIManager.Instance.CutsceneTextBox_UI.ShowCutscene(CutsceneImageToShow, FreezeGame);

            invokeCounter++;       
        }

        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);

            if (iFreezeGame_Coroutine != null)
            {
                StopCoroutine(IFreezeGame());
                iFreezeGame_Coroutine = null;
            }

            UIManager.Instance.CutsceneTextBox_UI.HideCutscene();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private IEnumerator IFreezeGame()
        {
            Time.timeScale = 0;
            yield return new WaitUntil(() => InputManager.Instance.GetKeyDown_Interaction);
            Time.timeScale = 1;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
