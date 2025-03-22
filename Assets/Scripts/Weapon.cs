using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData data;
    public AudioClip onUseSound;
    public event System.Action onPickedUpEvent;

    public float LastTimeUsed { get; protected set; }
    public virtual bool IsReady { get; }

    public virtual bool TryUse()
    {
        if (!IsReady) return false;
        LastTimeUsed = Time.time;
        return true;
    }
    public abstract void Select();
    public abstract void Deselect();
}