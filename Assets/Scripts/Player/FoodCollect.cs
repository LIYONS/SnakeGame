using UnityEngine;

public class FoodCollect : MonoBehaviour
{
    Movement moveMent;
    [SerializeField] GameObject gainerPS;
    [SerializeField] GameObject burnerPS;
    private void Start()
    {
        moveMent = GetComponent<Movement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Gainer")
        {
            moveMent.Grow();
            Instantiate(gainerPS, transform);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag=="Burner")
        {
            moveMent.Burn();
            Instantiate(burnerPS, transform);
            Destroy(collision.gameObject);
        }
        
    }
}
