public interface IInteractable
{
    float PickupTime { get; }

    void OnStartHover();

    void OnInteract();

    void OnEndHover();
}
