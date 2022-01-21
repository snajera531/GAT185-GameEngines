using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform spawnTransform;
    [SerializeField] float fireRate;
    [SerializeField] string weaponType;

    float fireTimer = 0;

    private void Update()
    {
        fireTimer -= Time.deltaTime;
        if (Input.GetButtonDown(weaponType) || (Input.GetButton(weaponType) && fireTimer <= 0))
        {
            fireTimer = fireRate;
            Fire();
        }
    }

    public void Fire()
    {
        Instantiate(projectilePrefab, spawnTransform.position, spawnTransform.rotation);
    }
}
