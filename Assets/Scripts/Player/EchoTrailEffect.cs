using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoTrailEffect : MonoBehaviour
{
    [SerializeField] float timeBtwSpawns;
    [SerializeField] GameObject echoBody;

    Movement movement;
    List<Transform> segments;
    float timer;
    private void Start()
    {
        timer = timeBtwSpawns;
        movement = GetComponent<Movement>();
        segments = movement.GetSegments();

    }
    private void Update()
    {
        if(timer <Time.time)
        {
            GameObject echo=(GameObject) Instantiate(echoBody,segments[segments.Count-1].position,Quaternion.identity);
            timer = Time.time + timeBtwSpawns;
        }
    }
}
