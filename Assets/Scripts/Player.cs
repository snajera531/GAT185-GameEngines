using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        transform.position += direction * Time.deltaTime * speed;
    }
}
