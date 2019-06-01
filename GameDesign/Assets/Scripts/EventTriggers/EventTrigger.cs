using System;
using System.Collections;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public abstract class EventTrigger : MonoBehaviour
    {
        #region VARIABLES

        [Space]
        [Header("EVENT VARIABLES")]
        public bool SingleInvoke;
        public bool FreezeGame;

        [Space]
        [Header("TRIGGER VISUALS")]
        public bool ShowVisuals = false;
        public Color CanInvoke_Color = Color.green;
        public Color CanNotInvoke_Color = Color.red;

        protected int invokeCounter;
        protected Coroutine iFreezeGame_Coroutine;

        protected MeshRenderer meshRenderer;

        #endregion VARIABLES

        #region UNITY_FUNCTIONS

        private void Start()
        {
            SetVisuals();
        }

        private void OnValidate()
        {
            SetVisuals();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {      
            meshRenderer.material.color = CanNotInvoke_Color;            
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (iFreezeGame_Coroutine != null)
            {
                StopCoroutine(IFreezeGame());
                iFreezeGame_Coroutine = null;
            }

            if (SingleInvoke && invokeCounter > 0)
            {
                return;
            }

            meshRenderer.material.color = CanInvoke_Color;
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private void SetVisuals()
        {
            if (meshRenderer == null)
            {
                meshRenderer = GetComponent<MeshRenderer>();
            }

            meshRenderer.enabled = ShowVisuals;
        }

        protected IEnumerator IFreezeGame(Action eventAction = null)
        {
            Time.timeScale = 0;
            yield return new WaitUntil(() => InputManager.Instance.GetKeyDown_Interaction);
            Time.timeScale = 1;

            if (eventAction != null)
            {
                eventAction.Invoke();
            }
        }

        #endregion CUSTOM_FUNCTIONS      
    }
}