using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnerBox : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPrefabs;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] bool active = true;

    public float timeModifier = 1;
    BoxCollider boxCollider;
    float timer;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        timer = Random.Range(minTime, maxTime);

        GameManager.Instance.startGameEvent += OnStartGame;
        GameManager.Instance.stopGameEvent += OnStopGame;
    }

    void Update()
    {
        if (!active) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(minTime, maxTime) * timeModifier;

            Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)], GetRandomInBoxCol(), transform.rotation);
        }
    }

    Vector3 GetRandomInBoxCol()
    {
        Vector3 point = Vector3.zero;
        Vector3 min = boxCollider.bounds.min;
        Vector3 max = boxCollider.bounds.max;

        point.x = Random.Range(min.x, max.x);
        point.y = Random.Range(min.y, max.y);
        point.z = Random.Range(min.z, max.z);

        return point;
    }

    public void OnStartGame()
    {
        active = true;
    }
    
    public void OnStopGame()
    {
        active = false;
    }
}
