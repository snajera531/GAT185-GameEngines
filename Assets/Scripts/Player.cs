using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 10)][Tooltip("speed of the player")] public float speed = 5;
    [SerializeField] AudioSource audioSource;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        transform.position += direction * Time.deltaTime * speed;

        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.Play();
            GetComponent<Renderer>().material.color = Color.green;
        }

        GameObject gO = GameObject.Find("Cube");
        if(gO)
        {
            gO.GetComponent<Renderer>().material.color = Color.magenta;
        }
    }
}
