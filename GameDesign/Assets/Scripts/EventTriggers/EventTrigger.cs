using UnityEngine;
using UnityEngine.Events;

public abstract class EventTrigger : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent[] unityEvents;

    [Header("Object Visuals")]
    [SerializeField] private bool showVisuals = false;
    [SerializeField] private GameObject visualsGameObject;

    private void Start()
    {
        SetVisuals();
    }

    private void OnValidate()
    {
        SetVisuals();
    }

    private void SetVisuals()
    {
        if (visualsGameObject == null)
            visualsGameObject = transform.GetChild(0).gameObject;

        visualsGameObject.SetActive(showVisuals);
    }

    void OnTriggerEnter(Collider other)
    {

    }
}
