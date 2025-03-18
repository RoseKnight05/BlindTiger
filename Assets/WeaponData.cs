using UnityEngine;

[CreateAssetMenu(menuName="WeaponData", fileName="Weapon_")]
public class WeaponData : ScriptableObject
{
    public float damagePerUse;
    public float range;
    public float delay;
    public new string name;
    public int index;
}