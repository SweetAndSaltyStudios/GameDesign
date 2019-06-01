using UnityEngine;
using UnityEngine.UI;

namespace Sweet_And_Salty_Studios
{
    public class ItemSlot : MonoBehaviour
    {
        public bool ContainsItem;
        public Text ItemName { get; set; }
        public Image ItemIcon { get; set; }

        private void Awake()
        {
            ItemIcon = transform.GetChild(0).GetComponent<Image>();
            ItemName = transform.GetChild(1).GetComponent<Text>();
        }

        private void OnEnable()
        {
            ItemIcon.enabled = ItemName.enabled = ContainsItem;          
        }
    }
}
