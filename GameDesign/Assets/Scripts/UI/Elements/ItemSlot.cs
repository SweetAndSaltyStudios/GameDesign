using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sweet_And_Salty_Studios
{
    public class ItemSlot : UIElement
    {
        private Image backgroundImage;
        private Image itemIcon;

        public Item Item
        {
            get;
            private set;
        }

        private void Awake()
        {
            backgroundImage = transform.GetChild(0).GetComponent<Image>();
            itemIcon = transform.GetChild(1).GetComponent<Image>();
            itemIcon.enabled = false;
        }

        private void OnEnable()
        {
            backgroundImage.enabled = Item == null;        
        }

        public void UpdateSlot(Item item)
        {
            Item = item;
            itemIcon.sprite = item.InventorySprite;
            itemIcon.enabled = true;
        }

        public void ClearSlot()
        {
            Item = null;
            itemIcon.sprite = null;
            itemIcon.enabled = false;
            backgroundImage.enabled = true;
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);

            UIManager.Instance.UI_ItemToolTip.Show(Item);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);

            UIManager.Instance.UI_ItemToolTip.Hide();
        }
    }
}
