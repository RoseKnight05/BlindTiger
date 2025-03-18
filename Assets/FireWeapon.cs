using UnityEngine;

public class FireWeapon : Weapon
{
    public ParticleSystem gunfireEffect;

    public override void Select()
    {
        gameObject.SetActive(true);
    }

    public override void Deselect()
    {
        gameObject.SetActive(false);
    }

    public override void Use()
    {
        Debug.Log("Shot fired!");
        if (gunfireEffect != null)
        {
            gunfireEffect.Play();  // Plays the shooting effect (optional)
        }

        if (onUseSound != null)
        {
            AudioSource.PlayClipAtPoint(onUseSound, transform.position);  // Plays the firing sound (optional)
        }

        RaycastHit hit;
        if (Physics.Raycast(PlayerController.instance.camera.transform.position, PlayerController.instance.camera.transform.forward, out hit, data.range))
        {
            AIHealth aiHealth = hit.transform.GetComponent<AIHealth>();
            if (aiHealth != null)
            {
                aiHealth.TakeDamage(data.damagePerUse);
            }
        }
    }
}