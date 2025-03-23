using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject calpistol;    // Reference to the 22calpistol GameObject
    [SerializeField] private GameObject shotgun;      // Reference to the shotgun GameObject
    [SerializeField] private ParticleSystem pistolMuzzleFlash;  // Reference to the Pistol's particle system
    [SerializeField] private ParticleSystem shotgunMuzzleFlash; // Reference to the Shotgun's particle system
    [SerializeField] private GameObject bulletTrailPrefab;  // Reference to the Bullet Trail prefab
    [SerializeField] private ParticleSystem bulletImpact; // Reference to the Bullet Impact particle system

    private GameObject currentWeapon; // Keeps track of the active weapon

    void Start()
    {
        // Ensure weapons are initially disabled
        calpistol.SetActive(false);
        shotgun.SetActive(false);

        // Equip the calpistol by default
        EquipWeapon(calpistol);
    }

    void Update()
    {
        // Switch to calpistol if '1' is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(calpistol);  // Equip 22calpistol
        }
        // Switch to shotgun if '2' is pressed
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(shotgun);  // Equip shotgun
        }

        // Fire the current weapon when the fire button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }
    }

    // Equip a specific weapon by disabling the other
    void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != weapon)
        {
            if (currentWeapon != null)
            {
                currentWeapon.SetActive(false);
            }

            currentWeapon = weapon;
            currentWeapon.SetActive(true);
        }
    }

    // Fire the current weapon and trigger the corresponding particle systems
    void FireWeapon()
    {
        if (currentWeapon == calpistol)
        {
            // Trigger pistol muzzle flash
            if (pistolMuzzleFlash != null)
            {
                pistolMuzzleFlash.Play();  // Activate the muzzle flash for the pistol
            }

            // Spawn bullet trail
            SpawnBulletTrail();
            Debug.Log("Firing pistol");
        }
        else if (currentWeapon == shotgun)
        {
            // Trigger shotgun muzzle flash
            if (shotgunMuzzleFlash != null)
            {
                shotgunMuzzleFlash.Play();  // Activate the muzzle flash for the shotgun
            }

            // Spawn bullet trail
            SpawnBulletTrail();
            Debug.Log("Firing shotgun");
        }
    }

    // Spawn a bullet trail effect
    void SpawnBulletTrail()
    {
        // Instantiate the bullet trail particle system and make it follow the bullet's trajectory
        GameObject bulletTrail = Instantiate(bulletTrailPrefab, transform.position, Quaternion.identity);
        bulletTrail.transform.SetParent(currentWeapon.transform);  // Attach to the weapon's muzzle position

        // Destroy the trail after a set duration
        Destroy(bulletTrail, 2f);
    }

    // Call this method when the bullet hits something (e.g., enemy or wall)
    public void BulletImpact(Vector3 impactPosition)
    {
        // Instantiate the impact particle effect at the impact position
        ParticleSystem impact = Instantiate(bulletImpact, impactPosition, Quaternion.identity);
        Destroy(impact.gameObject, 1f); // Destroy impact effect after it's played
    }
}
