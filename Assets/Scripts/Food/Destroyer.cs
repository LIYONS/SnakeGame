using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float lifetime;

    private void Start()
    {
        Invoke("DestroyFood", lifetime);
    }
    void DestroyFood()
    {
        Destroy(gameObject);
    }
}
