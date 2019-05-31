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

        [SerializeField]
        private IInteractable currentlyTargetedInteractable;
        private Camera mainCamera;
        private float currentPickupTimerElapsed = 0f;

        #endregion VARIABLES

        #region PROPERTIES

        public static PlayerController Instance
        {
            get;
            private set;
        }

        public Ray InteractionRay
        {
            get 
            {
                return mainCamera.ViewportPointToRay(Vector3.one * 0.5f);
            }
        }

        public bool CanMove
        {
            get 
            {
                return Time.timeScale != 0;
            }
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
            if (CanMove == false)
                return;

            base.Update();

            InteractableRay();

            if (HasItemTargeted())
            {
                UIManager.Instance.Cursor.SetPickupProgressImage(true);
                UIManager.Instance.Cursor.CursorText = currentlyTargetedInteractable.ToString();

                if (InputManager.Instance.GetKey_Interaction)
                {
                    IncrementPickupProgressAndTryComplete();               
                }
                else
                {
                    currentPickupTimerElapsed = 0f;
                }

                if (currentlyTargetedInteractable == null)
                    return;

                var percent = currentPickupTimerElapsed / currentlyTargetedInteractable._PickupTime;
                UIManager.Instance.Cursor.UpdatePickupProgressImage(percent);
            }          
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private bool HasItemTargeted()
        {
            return currentlyTargetedInteractable != null;
        }

        private void IncrementPickupProgressAndTryComplete()
        {
            currentPickupTimerElapsed += Time.deltaTime;

            if(currentPickupTimerElapsed >= currentlyTargetedInteractable._PickupTime)
            {
                MoveItemToInventory();
            }
        }

        private void MoveItemToInventory()
        {
            currentlyTargetedInteractable.OnInteract();
            currentlyTargetedInteractable = null;

            UIManager.Instance.Cursor.SetPickupProgressImage(false);
        }

        private void InteractableRay()
        {
            if (Physics.Raycast(InteractionRay, out RaycastHit hitInfo, InteractRange, interactableLayerMask))
            {
                var interactable = hitInfo.collider.GetComponent<IInteractable>();

                if (interactable != null && interactable != currentlyTargetedInteractable)
                {
                    currentlyTargetedInteractable = interactable;
                }
            }
            else
            {
                if (currentlyTargetedInteractable != null)
                {
                    currentlyTargetedInteractable = null;
                    currentPickupTimerElapsed = 0f;
                    UIManager.Instance.Cursor.SetPickupProgressImage(false);
                }
            }
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
