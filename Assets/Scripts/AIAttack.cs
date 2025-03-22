using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(AIBotChase))]
public class AIAttack : MonoBehaviour
{
    private AIBotChase bot;
    public Weapon weapon;

    private void Start()
    {
        bot = GetComponent<AIBotChase>();
    }

    private void Update()
    {
        if (bot.DistanceToPlayer < weapon.data.range)
        {
            weapon.TryUse();
        }
    }

    public void Attack()
    {
        weapon.TryUse();
        // animations etc
    }
}