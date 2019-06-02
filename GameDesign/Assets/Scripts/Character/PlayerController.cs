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
                if(Time.timeScale == 0)
                {
                    m_MouseLook.SetCursorLock(false);
                    return false;
                }
                else
                {
                    m_MouseLook.SetCursorLock(true);
                    return true;
                }
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
                if (InputManager.Instance.GetKey_Interaction && currentlyTargetedInteractable.CanInteract)
                {
                    IncrementPickupProgressAndTryComplete();               
                }
                else
                {
                    currentPickupTimerElapsed = 0f;
                }

                if (currentlyTargetedInteractable == null)
                    return;

                var percent = currentPickupTimerElapsed / currentlyTargetedInteractable.InteractionTime;
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

            if(currentPickupTimerElapsed >= currentlyTargetedInteractable.InteractionTime)
            {
                currentlyTargetedInteractable.OnInteract();
                currentlyTargetedInteractable.OnEndHover();
                currentlyTargetedInteractable = null;
                currentPickupTimerElapsed = 0f;
            }
        }

        private void InteractableRay()
        {
            if (Physics.Raycast(InteractionRay, out RaycastHit hitInfo, InteractRange, interactableLayerMask))
            {
                var interactable = hitInfo.collider.GetComponent<IInteractable>();

                if (interactable != null && interactable != currentlyTargetedInteractable)
                {
                    if(currentlyTargetedInteractable != null)
                    {
                        currentlyTargetedInteractable.OnEndHover();
                    }

                    currentlyTargetedInteractable = interactable;
                    currentlyTargetedInteractable.OnStartHover();
                }
            }
            else
            {
                if (currentlyTargetedInteractable != null)
                {                
                    currentPickupTimerElapsed = 0f;
                    currentlyTargetedInteractable.OnEndHover();
                    currentlyTargetedInteractable = null;
                }
            }
        }

        public void SetNewPosition(Vector3 newPosition)
        {
            m_CharacterController.enabled = false;

            transform.position = newPosition;

            m_CharacterController.enabled = true;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
