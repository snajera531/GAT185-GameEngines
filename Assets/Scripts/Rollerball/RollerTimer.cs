using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerTimer : Pickup, IDestructable
{
    [SerializeField] int seconds;

    public void Destroyed()
    {
        RollerGameManager.Instance.GameTime += seconds;
    }
}
