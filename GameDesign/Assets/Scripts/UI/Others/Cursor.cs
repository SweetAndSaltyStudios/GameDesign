using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sweet_And_Salty_Studios
{
    public class Cursor : MonoBehaviour
    {
        private Image cursorIcon;
        private TextMeshProUGUI cursorText;

        private Image pickupProgressImage;

        public string CursorText
        {
            get 
            {
                return cursorText.text;
            }
            set 
            {
                cursorText.text = value;
            }
        }

        private void Awake()
        {
            cursorIcon = transform.GetChild(0).GetComponent<Image>();

            pickupProgressImage = transform.GetChild(1).GetComponent<Image>();
            cursorText = pickupProgressImage.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            pickupProgressImage.fillAmount = 0f;
            SetPickupProgressImage(false);
        }

        public void SetPickupProgressImage(bool isActive)
        {
            pickupProgressImage.gameObject.SetActive(isActive);       
        }

        public void UpdatePickupProgressImage(float percent)
        {
            pickupProgressImage.fillAmount = float.IsNaN(percent) ? 0f : percent;
        }
    }
}