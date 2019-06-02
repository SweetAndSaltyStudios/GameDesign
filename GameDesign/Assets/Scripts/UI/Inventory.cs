using System.Collections.Generic;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Inventory : MonoBehaviour
    {
        private const int MAX_ITEM_SLOTS = 16;

        [Space]
        [Header("REFERENCES")]
        public GameObject ItemSlotPrefab;

        public List<Item> Items = new List<Item>();
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
            inventoryPanel.SetActive(isActive);
        }

        public bool AddItem(Item item)
        {
            if (Items.Contains(item))
            {
                Debug.LogWarning("We already have a '" + item.name + "' in inventory!");
                return true;
            }

            Debug.Log("Item '" + item.name + "' added in inventory!");
            Items.Add(item);
            return false;
        }

        public bool RemoveItem(Item item)
        {
            return Items.Remove(item);
        }

        private void UpdateItemSlot(Sprite newItemSprite)
        {
           
        }
    }
}
