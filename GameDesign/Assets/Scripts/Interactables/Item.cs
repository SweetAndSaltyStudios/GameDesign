using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Item : MonoBehaviour, IInteractable
    {
        [Space]
        [Header("VARIABLES")]
        public string InteractionPopupText;
        public float PickupTime = 0;
        public AudioClip PickUpSound;
        public Color OnHoverColor = Color.yellow;
        private Color normalColor = Color.white;

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
                meshRenderers[i].material.color = OnHoverColor;
            }

            UIManager.Instance.Cursor.SetPickupProgressImage(true);
            UIManager.Instance.Cursor.CursorText = InteractionPopupText;
        }

        public void OnInteract()
        {
            if(PickUpSound != null)
            {
                AudioSource.PlayClipAtPoint(PickUpSound, transform.position);
            }

            CanInteract = false;

            gameObject.SetActive(false);

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
