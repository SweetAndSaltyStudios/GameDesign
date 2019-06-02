using TMPro;

namespace Sweet_And_Salty_Studios
{
    public class UI_ItemToolTip : UI_ToolTip
    {
        private TextMeshProUGUI ItemNameText;
        private TextMeshProUGUI ItemTypeText;
        private TextMeshProUGUI ItemDescriptionText;

        private void Awake()
        {
            var elementContainer = transform.GetChild(0);
            ItemNameText = elementContainer.GetChild(1).GetComponent<TextMeshProUGUI>();
            ItemTypeText = elementContainer.GetChild(2).GetComponent<TextMeshProUGUI>();
            ItemDescriptionText = elementContainer.GetChild(3).GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            Hide();
        }

        public void Show(Item item)
        {
            ItemNameText.text = item.name;
            ItemTypeText.text = item.Type.ToString();
            ItemDescriptionText.text = "DESCRIPTION:\n" + item.Description;

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
