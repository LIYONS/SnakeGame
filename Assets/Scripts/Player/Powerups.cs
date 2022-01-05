using UnityEngine;
using TMPro;

public class Powerups : MonoBehaviour
{
    [SerializeField] float powerupTime;
    [SerializeField] TextMeshProUGUI powerupText;
    float speed;
    int score;
    Movement movement;
    ScoreController scoreController;
    SoundManager soundManager;
    private void Start()
    {
        movement = GetComponent<Movement>();
        soundManager = SoundManager.instance;
        scoreController = GetComponent<ScoreController>();
        score = scoreController.GetScoreForGainer();
        powerupText.color = new Color(0f, 0f, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer== LayerMask.NameToLayer("Powerup"))
        {
            if (soundManager)
            {
                soundManager.PlaySfx(Sounds.FoodPickup);
            }
            if (collision.gameObject.tag=="Speed")
            {
                speed = movement.GetSpeed();
                movement.SetSpeed(speed * .5f);
                Invoke("SetNormalSpeed", powerupTime);

            }
            else if(collision.gameObject.tag=="ScoreBoost")
            {
                scoreController.SetScoreForGainer(score*2);
                Invoke("SetScore", powerupTime);
            }
            else if(collision.gameObject.tag=="Shield")
            {
                movement.SetCanDie(true);
                Invoke("SetCanDie", powerupTime);
            }
            powerupText.text = gameObject.tag + "  Achieved  " + collision.gameObject.tag;
            powerupText.color = Color.black;
            Invoke("SetText", 2f);
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
    void SetScore()
    {
        scoreController.SetScoreForGainer(score);
    }
    void SetText()
    {
        powerupText.color = new Color(0f, 0f, 0f, 0f);
    }
}
