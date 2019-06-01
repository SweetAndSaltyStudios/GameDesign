using UnityEngine;
using UnityEngine.UI;

namespace Sweet_And_Salty_Studios
{
    public class CutsceneTextBox_UI : MonoBehaviour
    {
        #region VARIABLES

        [Space]
        [Header("References")]
        public Image CutsceneImage;
        public Text InfoText;

        [Space]
        [Header("Cutscene Sprites")]
        public Sprite[] CutsceneSprites;

        private Animator animator;

        private string triggerInfoText;
        private readonly string defaultInfoText = "";

        #endregion VARIABLES

        #region  UNITY_FUNCTIONS

        private void Awake()
        {
            animator = GetComponent<Animator>();          
        }

        private void Start()
        {
            if (CutsceneImage != null)
            {
                CutsceneImage.gameObject.SetActive(false);
            }

            animator.updateMode = AnimatorUpdateMode.UnscaledTime;

            triggerInfoText = "Press '" + InputManager.Instance.Interaction.ToString() + "' to continue";
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void ShowCutscene(Sprite cutsceneSprite, bool showInfoText)
        {
            UIManager.Instance.Cursor.gameObject.SetActive(false);

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
            UIManager.Instance.Cursor.gameObject.SetActive(true);
        }

        #endregion CUSTOM_FUNCTIONS
    }
}