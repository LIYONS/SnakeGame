using UnityEngine;

public class FoodCollect : MonoBehaviour
{
    Movement moveMent;
    [SerializeField] GameObject gainerPS;
    [SerializeField] GameObject burnerPS;
    ScoreController scoreController;

    private void Start()
    {
        moveMent = GetComponent<Movement>();
        scoreController = GetComponent<ScoreController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Gainer")
        {
            SoundManager soundManager = SoundManager.instance;
            if (soundManager)
            {
                soundManager.PlaySfx(Sounds.FoodPickup);
            }
            moveMent.Grow();
            Instantiate(gainerPS, transform);
            scoreController.IncreaseScore();
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag=="Burner")
        {
            moveMent.Burn();
            Instantiate(burnerPS, transform);
            scoreController.IncreaseScore();
            Destroy(collision.gameObject);
        }
        
    }
}
