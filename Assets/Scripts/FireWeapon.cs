using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireWeapon : Weapon
{
    public ParticleSystem gunfireEffect;
    private AudioSource audioSource;

    public override bool IsReady => Time.time - LastTimeUsed > data.delay;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            var copy = Instantiate(gunfireEffect);
            copy.transform.SetParent(null);
            copy.transform.position = gunfireEffect.transform.position;
            copy.transform.rotation = gunfireEffect.transform.rotation;
            copy.Play();  // Plays the shooting effect (optional)
            Destroy(copy, 3);
        }

        if (onUseSound != null)
        {
            audioSource.PlayOneShot(onUseSound);  // Plays the firing sound (optional)
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, data.range, LayerMask.NameToLayer("default"), QueryTriggerInteraction.Collide))
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