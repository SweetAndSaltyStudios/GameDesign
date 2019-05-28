using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private Sprite cutsceneImage;
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
}
