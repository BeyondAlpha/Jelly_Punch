using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public PlayerMove player;
    public void NextStage()
    {
        stageIndex++;

        totalPoint += stagePoint;
        stagePoint = 0;
    }
    
    public void HealthDown()
    {
        if (health > 0)
            health--;
        else {
            //Player Die Effect
            player.OnDie();

            //Result UI
            Debug.Log("Game Over!");
            // Restart button UI            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            HealthDown();

            //Falling speed == 0
            collision.attachedRigidbody.velocity = Vector2.zero;
    }
}
