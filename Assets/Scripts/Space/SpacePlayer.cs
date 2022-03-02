using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayer : MonoBehaviour, IDestructable
{
    [Range(0, 100)] [Tooltip("speed of the player")] public float speed = 40;
    [SerializeField] Weapon[] weapons;
    [SerializeField] Damage damage;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        //applying movement
        transform.Translate(direction * speed * Time.deltaTime);

        if (Input.GetButton("Fire2"))
        {
            //weapons[1].Fire();
        }
        else if(Input.GetButton("Fire1"))
        {
            //weapons[0].Fire();
        }

        GameManager.Instance.PlayerHealth = GetComponent<Health>().health;
    }

    public void Destroyed()
    {
        GameManager.Instance.PlayerHealth = 0;
        GameManager.Instance.OnPlayerDeath();
    }
}
