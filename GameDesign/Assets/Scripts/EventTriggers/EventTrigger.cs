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
        [Header("Object Visuals")]
        public bool ShowVisuals = false;

        protected int invokeCounter;
        protected Coroutine iFreezeGame_Coroutine;

        private GameObject visualsGameObject;
        protected MeshRenderer meshRenderer;

        #endregion VARIABLES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

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
            meshRenderer.material.color = Color.red;            
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

            meshRenderer.material.color = Color.green;
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private void SetVisuals()
        {
            if (visualsGameObject == null)
            {
                visualsGameObject = transform.GetChild(0).gameObject;
            }

            visualsGameObject.SetActive(ShowVisuals);
        }

        protected IEnumerator IFreezeGame(Action foo = null)
        {
            Time.timeScale = 0;
            yield return new WaitUntil(() => InputManager.Instance.GetKeyDown_Interaction);
            Time.timeScale = 1;

            if (foo != null)
            {
                foo.Invoke();
            }
        }

        #endregion CUSTOM_FUNCTIONS      
    }
}