using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject gO = Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gO, 2);
        }
    }
}
