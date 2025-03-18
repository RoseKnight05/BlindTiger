using UnityEngine;

class PickUpComponent : MonoBehaviour, IInteractable
{
    public event System.Action onPickedUpEvent;

    private void Start() => Init();
    public void Init()
    {
        Record();
    }

    private void OnDestroy()
    {
        Unrecord();
    }

    public void Interact()
    {
        gameObject.SetActive(false);
        onPickedUpEvent?.Invoke();
    }

    public void Record()
    {
        World.interactables.Add(this);
    }

    public void Unrecord()
    {
        World.interactables.Remove(this);
    }
}