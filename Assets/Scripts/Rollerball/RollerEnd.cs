using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerEnd : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RollerGameManager.Instance.OnPlayerWin();
        }
    }

}
