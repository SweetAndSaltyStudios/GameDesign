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

            Debug.DrawRay(mouseRay.origin, mouseRay.direction * interactRange, Color.red);

            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, interactRange, interactableLayerMask))
            {
                var interactable = hitInfo.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    
                        if (interactable == targetInteractable)
                        {
                            return;
                        }

                        if (targetInteractable != null)
                        {
                            targetInteractable.OnEndHover();
                            targetInteractable = interactable;
                            targetInteractable.OnStartHover();
                            return;
                        }

                        targetInteractable = interactable;
                        targetInteractable.OnStartHover();
                    
                }
                else
                {
                    StopInteracting();
                }
            }
            else
            {
                StopInteracting();
            }
        }

        private void StopInteracting()
        {
            if (targetInteractable != null)
            {
                targetInteractable.OnEndHover();
                targetInteractable = null;
            }
        }
    }
}
