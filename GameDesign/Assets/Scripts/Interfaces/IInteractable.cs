public interface IInteractable
{
    float _PickupTime { get; }

    void OnStartHover();

    void OnInteract();

    void OnEndHover();
}
