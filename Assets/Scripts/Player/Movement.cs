using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] float nextStepDelay;
    [SerializeField] SpriteRenderer backGround;
    float timeDelay;

    private void Start()
    {
        timeDelay = nextStepDelay;
        direction = Vector2.right;
    }
    private void Update()
    {
        GetDirection();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void GetDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))         direction = Vector2.up;

        else if (Input.GetKeyDown(KeyCode.DownArrow))  direction = Vector2.down;

        else if (Input.GetKeyDown(KeyCode.LeftArrow))  direction = Vector2.left;

        else if (Input.GetKeyDown(KeyCode.RightArrow)) direction = Vector2.right;
    }

    public void Move()
    {
        if (Time.time > timeDelay)
        {
            transform.position = new Vector3(transform.position.x + direction.x, transform.position.y + direction.y, transform.position.z);
            timeDelay = Time.time + nextStepDelay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            transform.position = new Vector3(0f, 0f, 0f);
        }
    }
}
