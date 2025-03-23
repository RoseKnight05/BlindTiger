using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour, IInteractable
{
    public WeaponData weaponData;
    public event System.Action onPickedUpEvent;
    public static event System.Action<WeaponItem> onAnyPickedUpEvent;

    public static List<WeaponItem> allItems = new List<WeaponItem>();

    private void Start()
    {
        allItems.Add(this);
        Record();
    }

    private void OnDestroy()
    {
        Unrecord();
    }

    public void Interact()
    {
        if (onPickedUpEvent != null) onPickedUpEvent.Invoke();
        if (onAnyPickedUpEvent != null) onAnyPickedUpEvent.Invoke(this);
    }

    public void Record()
    {
        World.interactables.Add(this);
        gameObject.SetActive(true);
    }

    public void Unrecord()
    {
        World.interactables.Remove(this);
        gameObject.SetActive(false);
    }
}