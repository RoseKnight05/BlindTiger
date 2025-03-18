using UnityEngine;

interface IInteractable
{
    /// <summary>
    /// Makes a record in World.interactables
    /// </summary>
    void Record();
    /// <summary>
    /// Removes from World.interactables
    /// </summary>
    void Unrecord();

    void Interact();
}
