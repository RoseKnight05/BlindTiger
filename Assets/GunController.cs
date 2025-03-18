using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Weapon[] weaponInstances;
    private Dictionary<WeaponData, Weapon> data2weapon = new Dictionary<WeaponData, Weapon>();
    public Weapon currentWeapon;

    private new Camera camera;

    private void Start()
    {
        camera = Camera.main;
        foreach (var weapon in weaponInstances)
        {
            data2weapon.Add(weapon.data, weapon);
        }
        WeaponItem.onAnyPickedUpEvent += SelectWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon?.Use();
        }
    }

    public void SelectWeapon(WeaponItem item)
    {
        print(item.weaponData.name + " is now selected!");
        item.Record(); // make last weapon interactable again
        currentWeapon?.Deselect();
        currentWeapon = data2weapon[item.weaponData]; // select weapon
        currentWeapon.Select();
        item.Unrecord(); // make the new weapon non-interactable
    }
}
