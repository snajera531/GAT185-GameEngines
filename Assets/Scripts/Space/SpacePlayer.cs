using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayer : MonoBehaviour, IDestructable
{
    [Range(0, 100)] [Tooltip("speed of the player")] public float speed = 40;
    [SerializeField] string weaponType;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        //applying movement
        transform.Translate(direction * speed * Time.deltaTime);
        //transform.position += direction * Time.deltaTime * speed;

        if (Input.GetButton(weaponType))
        {
            GetComponent<Weapon>().Fire();
        }

        GameManager.Instance.PlayerHealth = GetComponent<Health>().health;
    }

    public void Destroyed()
    {
        GameManager.Instance.PlayerHealth = 0;
        GameManager.Instance.OnPlayerDeath();
        //GameManager.Instance.OnStopGame();
    }
}
