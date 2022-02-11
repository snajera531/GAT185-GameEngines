using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerHealth : Pickup, IDestructable
{
    [SerializeField] int health;

    public void Destroyed()
    {
        GameObject gO = GameObject.FindGameObjectWithTag("Player");
        gO.GetComponent<Health>().health += health;
    }
}
