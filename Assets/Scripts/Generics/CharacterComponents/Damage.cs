using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] bool oneTime = true;

    public float DamageVal {
        get { return damage; }
        set
        {
            damage = value;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!oneTime) return;

        if (other.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.Damage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (oneTime) return;

        if (other.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.Damage(damage);
        }
    }
}
