using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayer : MonoBehaviour
{
    [Range(0, 100)] [Tooltip("speed of the player")] public float speed = 40;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        //applying movement
        transform.Translate(direction * speed * Time.deltaTime);
        //transform.position += direction * Time.deltaTime * speed;
    }
}
