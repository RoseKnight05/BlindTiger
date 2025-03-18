using UnityEngine;

interface IInteractable
{
    /// <summary>
    /// Makes a record in World.interactables, makes the object interactable
    /// </summary>
    void Record();
    /// <summary>
    /// Removes from World.interactables, makes the object non-interactable
    /// </summary>
    void Unrecord();

    void Interact();
}
