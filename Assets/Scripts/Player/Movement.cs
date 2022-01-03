using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] float nextStepDelay;
    [SerializeField] GameObject body;
    List<Transform> segments=new List<Transform>();
    Rigidbody2D rb;
    float timeDelay;
    Vector3 currentPos;

    //Level-wrap
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float minx;
    [SerializeField] float maxX;
    float wrapTimer = 0f;

    private void Start()
    {
        timeDelay = nextStepDelay;
        direction = Vector2.right;
        rb = GetComponent<Rigidbody2D>();
        segments.Insert(0,transform);
    }
    private void Update()
    {
        GetDirection();
    }
    private void FixedUpdate()
    {
        Move();
        currentPos = transform.position;
        if((currentPos.x < minx || currentPos.x > maxX || currentPos.y < minY || currentPos.y > maxY) && wrapTimer<Time.time)
        {
            LevelWrap();
            wrapTimer = Time.time + .5f;
        }
        DeathCheck();
    }
    void GetDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Vector2.down)
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector2.up)
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector2.left)
        {
            direction = Vector2.right;
        }
    }
    void Move()
    {
       if (Time.time > timeDelay)
       {
            for(int i=segments.Count-1;i>0;i--)
            {
                segments[i].position = segments[i - 1].transform.position;
            }
            transform.position = new Vector3( transform.position.x + direction.x,  transform.position.y + direction.y, transform.position.z);
            timeDelay = Time.time + nextStepDelay;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag=="NormalFood")
        {
            Grow();
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag=="Obstacle")
        {
        }
    }
    void Grow()
    {
        int listLength = segments.Count;
        GameObject segment = Instantiate(body);
        segment.transform.position = segments[listLength - 1].transform.position;
        segments.Insert(segments.Count, segment.transform);
    }

    void LevelWrap()
    {
        Vector3 pos = transform.position;
        if (pos.x <= minx)
        {
            pos.x = maxX;
        }
        else if(pos.x>=maxX)
        {
            pos.x = minx;
        }
        else if(pos.y<=minY)
        {
            pos.y = maxY;
        }
        else if (pos.y >= maxY)
        {
            pos.y = minY;
        }

        transform.position = pos;

    }
    void DeathCheck()
    {
        for(int i=1;i<segments.Count;i++)
        {
            if(transform.position.x==segments[i].position.x && transform.position.y== segments[i].position.y)
            {
                Debug.Log("GameOver");
            }
        }
    }
}
