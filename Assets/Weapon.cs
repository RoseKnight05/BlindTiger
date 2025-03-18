using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData data;
    public AudioClip onUseSound;
    public event System.Action onPickedUpEvent;

    public abstract void Use();
    public abstract void Select();
    public abstract void Deselect();
}