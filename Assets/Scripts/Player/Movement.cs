using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] float nextStepDelay;
    [SerializeField] GameObject body;
    [SerializeField] float initialSegments;
    Rigidbody2D rb;
    float timeDelay;
    Vector3 currentPos;
    List<Transform> segments=new List<Transform>();


    //Level-wrap
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float minx;
    [SerializeField] float maxX;
    float wrapTimer = 0f;

    //Power-up
    bool canDie = true;
    private void Start()
    {
        timeDelay = nextStepDelay;
        direction = Vector2.right;
        rb = GetComponent<Rigidbody2D>();
        segments.Insert(0,transform);
        for(int i=0;i<initialSegments;i++)
        {
            Grow();
        }
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

    #region Getters
    public List<Transform> GetSegments()
    {
        return segments;
    }
    public float GetSpeed()
    {
        return nextStepDelay;
    }
    public void SetCanDie(bool value)
    {
        canDie = value;
    }
    #endregion
    #region Setters
    public void SetSpeed(float speed)
    {
        nextStepDelay = speed;
    }

    #endregion
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

    public void Grow()
    {
        int listLength = segments.Count;
        GameObject segment = Instantiate(body);
        Vector3 position = segments[listLength - 1].transform.position;
        position.z = 2;
        segment.transform.position = position;
        segments.Insert(segments.Count, segment.transform);
    }

    public void Burn()
    {
        if (segments.Count > 3)
        {
            Destroy(segments[segments.Count - 1].gameObject);
            segments.RemoveAt(segments.Count - 1);
        }
        else
        {
            if (canDie)
            {
                KillPlayer();
            }
        }
    }

    void LevelWrap()
    {
        Vector3 pos = transform.position;
        if (pos.x <= minx)
        {
            pos.x = maxX;
        }
        else if (pos.x >= maxX)
        {
            pos.x = minx;
        }
        else if (pos.y <= minY)
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
        for (int i = 1; i < segments.Count; i++)
        {
            Vector3 position = transform.position;
            if (position.x == segments[i].position.x && position.y == segments[i].position.y && position.z == segments[i].position.z)
            {
                if (canDie)
                {
                    KillPlayer();
                }
            }
        }
    }
    void KillPlayer()
    {
        Debug.Log("Death");
    }
    
}

