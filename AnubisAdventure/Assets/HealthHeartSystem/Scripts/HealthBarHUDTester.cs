/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;

public class HealthBarHUDTester : MonoBehaviour
{
    public void AddHealth()
    {
        PStats.Instance.AddHealth();
    }

    public void Heal(float health)
    {
        PStats.Instance.Heal(health);
    }

    public void Hurt(float dmg)
    {
        PStats.Instance.TakeDamage(dmg);
    }
}
