public interface IInteractable
{
    bool CanInteract { get; set; }

    float InteractionTime { get; }

    void OnStartHover();

    void OnInteract();

    void OnEndHover();
}
