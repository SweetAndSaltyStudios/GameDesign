using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Item : MonoBehaviour, IInteractable
    {
        public float PickupTime = 0;
        private Color normalColor = Color.white;
        private Color interactableColor = Color.yellow;

        private MeshRenderer[] meshRenderers;

        public float _PickupTime => PickupTime;

        private void Awake()
        {
            meshRenderers = GetComponentsInChildren<MeshRenderer>();
        }

        public void OnStartHover()
        {
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].material.color = interactableColor;
            }
        }

        public void OnInteract()
        {
            gameObject.SetActive(false);
        }

        public void OnEndHover()
        {
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].material.color = normalColor;
            }
        }
    }
}
