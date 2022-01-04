using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    [SerializeField] float powerupTime;
    float speed;
    Movement movement;
    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer== LayerMask.NameToLayer("Powerup"))
        {
            if(collision.gameObject.tag=="Speed")
            {
                Debug.Log("speed");
                speed = movement.GetSpeed();
                movement.SetSpeed(speed * 2);
                Invoke("SetNormalSpeed", powerupTime);

            }
            else if(collision.gameObject.tag=="ScoreBoost")
            {
                Debug.Log("ScoreBoost");
            }
            else if(collision.gameObject.tag=="Shield")
            {
                Debug.Log("shield");
                movement.SetCanDie(true);
                Invoke("SetCanDie", powerupTime);

            }
            Destroy(collision.gameObject);
        }
    }

    void SetNormalSpeed()
    {
        movement.SetSpeed(speed);
    }
    void SetCanDie()
    {
        movement.SetCanDie(true);
    }
}
