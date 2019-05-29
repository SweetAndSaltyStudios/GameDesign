using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Sweet_And_Salty_Studios
{
    public class PlayerController : FirstPersonController
    {
        #region VARIABLES

        [Space]
        [Header("INTERACTION VARIABLES")]
        public float InteractRange = 2f;

        private LayerMask interactableLayerMask;

        private IInteractable targetInteractable;
        private Camera mainCamera;

        #endregion VARIABLES

        #region PROPERTIES

        public static PlayerController Instance
        {
            get;
            private set;
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            mainCamera = Camera.main;
            interactableLayerMask = LayerMask.GetMask("Interactable");
        }

        protected override void Update()
        {
            base.Update();

            InteractableRay();

            if (InputManager.Instance.GetKeyDown_Interaction)
            {
                if (targetInteractable != null)
                {
                    targetInteractable.OnInteract();
                }
            }
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private void InteractableRay()
        {
            var mouseRay = mainCamera.ViewportPointToRay(Vector3.one * 0.5f);

            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, InteractRange, interactableLayerMask))
            {
                var interactable = hitInfo.collider.GetComponent<IInteractable>();

             
            }
            else
            {
                
            }
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
