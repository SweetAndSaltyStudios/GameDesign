using UnityEngine;
using UnityEngine.UI;

namespace Sweet_And_Salty_Studios
{
    public class CutsceneTextBox_UI : MonoBehaviour
    {
        #region VARIABLES

        public Image CutsceneImage;
        public Text InfoText;

        [Header("Cutscene Sprites")]
        public Sprite[] CutsceneSprites;

        private string triggerInfoText;
        private readonly string defaultInfoText = "DefaultText";

        #endregion VARIABLES

        #region  UNITY_FUNCTIONS

        private void Awake()
        {
            if (CutsceneImage != null)
            {
                CutsceneImage.gameObject.SetActive(false);
            }
        }

        private void Start()
        {
            triggerInfoText = "Press '" + InputManager.Instance.Interaction.ToString() + "' to continue";
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void ShowCutscene(Sprite cutsceneSprite, bool showInfoText)
        {
            for (int i = 0; i < CutsceneSprites.Length; i++)
            {
                if (CutsceneSprites[i] == cutsceneSprite)
                {
                    CutsceneImage.sprite = CutsceneSprites[i];

                    InfoText.text = showInfoText ? triggerInfoText : defaultInfoText;
    
                    CutsceneImage.gameObject.SetActive(true);
                    return;
                }
            }
        }

        public void HideCutscene()
        {
            CutsceneImage.gameObject.SetActive(false);
        }

        #endregion CUSTOM_FUNCTIONS
    }
}