using UnityEngine;

public class FireWeapon : Weapon
{
    public ParticleSystem gunfireEffect;

    public override bool IsReady => Time.time - LastTimeUsed > data.delay;

    public override void Select()
    {
        gameObject.SetActive(true);
    }

    public override void Deselect()
    {
        gameObject.SetActive(false);
    }

    public override bool TryUse()
    {
        if (!base.TryUse()) return false;

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
        if (Physics.Raycast(transform.position, transform.forward, out hit, data.range))
        {
            HealthComponent healthComp = hit.transform.GetComponent<HealthComponent>();
            if (healthComp != null)
            {
                healthComp.TakeDamage(data.damagePerUse);
            }
        }

        return true;
    }
}