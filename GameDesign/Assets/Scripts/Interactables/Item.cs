using UnityEngine;

public enum ITEM_TYPE
{
    TOOL,
    CONSUMABLE,
    MISCELLANEOUS
}

namespace Sweet_And_Salty_Studios
{
    public class Item : MonoBehaviour, IInteractable
    {
        [Space]
        [Header("VARIABLES")]
        public ITEM_TYPE Type;
        public string InteractionPopupText;   
        public float PickupTime = 0;
        public AudioClip PickUp_Clip;
        public Color HoverColor = Color.yellow;
        private Color normalColor = Color.white;
        [TextArea] public string Description;

        [Space]
        [Header("VISUALS")]
        public Sprite InventorySprite;
        private MeshRenderer[] meshRenderers;

        public float InteractionTime => PickupTime;

        public bool CanInteract
        {
            get;
            set;
        } = true;

        private void Awake()
        {
            meshRenderers = GetComponentsInChildren<MeshRenderer>();
        }

        public void OnStartHover()
        {
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].material.color = HoverColor;
            }

            UIManager.Instance.Cursor.SetPickupProgressImage(true);
            UIManager.Instance.Cursor.CursorText = InteractionPopupText;
        }

        public void OnInteract()
        {
            if(PickUp_Clip != null)
            {
                AudioSource.PlayClipAtPoint(PickUp_Clip, transform.position);
            }

            CanInteract = false;

            gameObject.SetActive(false);

            UIManager.Instance.Inventory.AddItem(this);
        }

        public void OnEndHover()
        {
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].material.color = normalColor;
            }

            UIManager.Instance.Cursor.SetPickupProgressImage(false);
        }
    }
}
