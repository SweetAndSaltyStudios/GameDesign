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
        public AudioClip AudioClip;
        public Transform TargetPosition;

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
            if (TargetPosition != null && doorInteraction_Coroutine == null && CanInteract)
            {
                meshRenderer.material.color = CanNotInvoke_Color;
                doorInteraction_Coroutine = StartCoroutine(IDoorInteraction());
            }
        }

        public void OnEndHover()
        {
            UIManager.Instance.Cursor.SetPickupProgressImage(false);
        }     

        private IEnumerator IDoorInteraction()
        {
            CanInteract = false;

            if (IsLocked)
            {
                Debug.LogError("DOOR IS LOCKED!");
                AudioSource.PlayClipAtPoint(DoorIsLocked_Clip, transform.position);
            }
            else
            {
                Debug.Log("DOOR IS UNLOCKED!");
                AudioSource.PlayClipAtPoint(DoorIsOpen_Clip, transform.position);
            }

            yield return new WaitForSeconds(InteractionDelay);

            meshRenderer.material.color = CanInvoke_Color;
            doorInteraction_Coroutine = null;
            CanInteract = true;
        }
    }
}
