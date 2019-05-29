using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Sweet_And_Salty_Studios
{
    public class PlayerController : FirstPersonController
    {
        [SerializeField] private float interactRange = 2f;
        [SerializeField] LayerMask interactableLayerMask;

        private IInteractable targetInteractable;

        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        protected override void Update()
        {
            base.Update();

            InteractableRay();

            if (Input.GetKeyDown(interaction))
            {
                if (targetInteractable != null)
                {
                    targetInteractable.OnInteract();
                }
            }
        }

        private void InteractableRay()
        {
            var mouseRay = mainCamera.ViewportPointToRay(Vector3.one * 0.5f);

            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, interactRange, interactableLayerMask))
            {
                var interactable = hitInfo.collider.GetComponent<IInteractable>();

             
            }
            else
            {
                
            }
        }
    }
}
