using System.Collections;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class DoorTrigger : EventTrigger, IInteractable
    {
        [Space]
        [Header("VARIABLES")]
        public string InteractionPopupText;
        public float _InteractionTime;
        public float InteractionDelay;
        public bool IsLocked;
        public Item Key;
        public AudioClip DoorIsOpen_Clip;
        public AudioClip DoorIsLocked_Clip;

        [Space]
        [Header("PLAY CLIP AT TARGET POINT")]
        public AudioClip targetPoint_Clip;
        public Transform TargetPoint;

        [Space]
        [Header("TELEPORT PLAYER TO TARGET POINT")]
        public Transform TargetTeleportPoint;

        public float InteractionTime => _InteractionTime;

        public bool CanInteract
        {
            get;
            set;
        } = true;

        private Coroutine doorInteraction_Coroutine;

        public void OnStartHover()
        {
            UIManager.Instance.Cursor.SetPickupProgressImage(true);
            UIManager.Instance.Cursor.CursorText = InteractionPopupText;
        }

        public void OnInteract()
        {
            if (doorInteraction_Coroutine == null && CanInteract)
            {
                meshRenderer.material.color = CanNotInvoke_Color;
                doorInteraction_Coroutine = StartCoroutine(IDoorInteraction());
            }
        }

        public void OnEndHover()
        {
            UIManager.Instance.Cursor.SetPickupProgressImage(false);
        }     

        private void OnDoorLocked(string debugText)
        {
            Debug.Log(debugText);

            AudioSource.PlayClipAtPoint(DoorIsLocked_Clip, transform.position);
        }

        public void OnDoorUnlocked(string debugText)
        {
            Debug.Log(debugText);

            if(TargetTeleportPoint != null)
            {
                PlayerController.Instance.SetNewPosition(TargetTeleportPoint.position);
            }

            AudioSource.PlayClipAtPoint(DoorIsOpen_Clip, transform.position);
        }

        private IEnumerator IDoorInteraction()
        {
            CanInteract = false;

            if (IsLocked)
            {
                if (UIManager.Instance.Inventory.ItemInInventory(Key))
                {
                    UIManager.Instance.Inventory.RemoveItem(Key);
                    IsLocked = false;

                    OnDoorUnlocked("YOU UNLOCKED THE DOOR!");  
                }
                else
                {
                    OnDoorLocked("DOOR IS LOCKED!");
                }             
            }
            else
            {
                OnDoorUnlocked("DOOR IS UNLOCKED!");
            }

            yield return new WaitForSeconds(InteractionDelay);

            meshRenderer.material.color = CanInvoke_Color;
            doorInteraction_Coroutine = null;
            CanInteract = true;
        }
    }
}
