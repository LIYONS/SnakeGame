using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject food;
    [SerializeField] float nextSpawnDelay;
    BoxCollider2D bgCollider;
    float timer;

    private void Start()
    {
        timer = nextSpawnDelay;
        bgCollider = GetComponent<BoxCollider2D>();

    }
    private void Update()
    {
        if (Time.time > timer)
        {
            SpawnFood();
            timer = Time.time + nextSpawnDelay;
        }
        
    }
    public void SpawnFood()
    {
        float x = Random.Range(bgCollider.bounds.min.x, bgCollider.bounds.max.x);
        float y = Random.Range(bgCollider.bounds.min.y, bgCollider.bounds.max.y);
        GameObject spawnPos = Instantiate(food);
        spawnPos.transform.position= new Vector3(Mathf.Round( x),Mathf.Round( y), 0f);
    }
}
