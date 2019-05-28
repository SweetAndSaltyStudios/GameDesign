using UnityEngine;
using UnityEngine.UI;

public class CutsceneTextBox_UI : MonoBehaviour
{
    [SerializeField] Image cutsceneTextBoxImage;

    [Header("CUTSCENE IMAGES")]
    [SerializeField] private Image[] cutsceneImages;

    private void Awake()
    {
        if(cutsceneTextBoxImage != null)
        {
            cutsceneTextBoxImage.gameObject.SetActive(false);
        }
    }

    public void ShowCutscene(Image cutsceneImage)
    {
        for (int i = 0; i < cutsceneImages.Length; i++)
        {
            if(cutsceneImages[i] == cutsceneImage)
            {
                cutsceneTextBoxImage = cutsceneImages[i];
                cutsceneTextBoxImage.gameObject.SetActive(true);
                return;
            }
        }
    }
}
