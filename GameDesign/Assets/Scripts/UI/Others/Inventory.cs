using System.Collections.Generic;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Inventory : MonoBehaviour
    {
        private const int MAX_ITEM_SLOTS = 18;

        [Space]
        [Header("REFERENCES")]
        public GameObject ItemSlotPrefab;

        [SerializeField ]private List<Item> items = new List<Item>();
        private List<ItemSlot> itemSlots = new List<ItemSlot>();
        private GameObject inventoryPanel;
        private Transform itemContainer;

        private void Awake()
        {
            inventoryPanel = transform.GetChild(0).gameObject;
            itemContainer = inventoryPanel.transform.GetChild(1);
        }

        private void Start()
        {
            for (int i = 0; i < MAX_ITEM_SLOTS; i++)
            {
                var itemSlot = Instantiate(ItemSlotPrefab, itemContainer);
                itemSlot.name = ItemSlotPrefab.name;
                itemSlots.Add(itemSlot.GetComponent<ItemSlot>());
            }

            ActivateInventoryPanel(false);
        }

        private void Update()
        {
            if (InputManager.Instance.GetKeyDown_Inventory)
            {
                ActivateInventoryPanel(inventoryPanel.activeSelf == false);
            }
        }

        private void ActivateInventoryPanel(bool isActive)
        {
            if (isActive)
            {
                inventoryPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {

                inventoryPanel.SetActive(false);
                Time.timeScale = 1;

                UIManager.Instance.UI_ItemToolTip.Hide();
            }
        }

        public bool ItemInInventory(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }

            Debug.LogWarning(item.name + " is not in inventory.");
            return false;
        }

        public bool AddItem(Item item)
        {
            if (items.Contains(item))
            {
                Debug.LogWarning("We already have a '" + item.name + "' in inventory!");
                return false;
            }

            Debug.Log("Item '" + item.name + "' added in inventory!");
            items.Add(item);
            UpdateItemSlot(item);
            return true;
        }

        public bool RemoveItem(Item item)
        {
            for (int i = 0; i < itemSlots.Count; i++)
            {
                if (itemSlots[i].Item == item)
                {
                    itemSlots[i].ClearSlot();
                    break;
                }
            }

            return items.Remove(item);
        }

        private void UpdateItemSlot(Item item)
        {
            // Find free item slot
            for (int i = 0; i < itemSlots.Count; i++)
            {
                if(itemSlots[i].Item == null)
                {
                    itemSlots[i].UpdateSlot(item);
                    return;
                }
            }
        }
    }
}
