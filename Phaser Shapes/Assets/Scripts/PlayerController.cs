using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;

    public PlayerNumber playerNumber;

    public float speed;
    public bool phasing = false;
    public float totalStrength = 100f;
    public float strengthDelta = 1f;
    Color color;

    private void Awake() {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        color = sr.color;

    }

    // Update is called once per frame
    void Update() {

        float xAxis = 0f;
        float yAxis = 0f;

        if (Input.GetButtonUp("Back_Pressed") && GameController.gc.gameOver) {
            GameController.gc.RestartGame();
        }

        if (playerNumber == PlayerNumber.Player1) {

            xAxis = Input.GetAxis("Player1_Horizontal");
            yAxis = Input.GetAxis("Player1_Vertical");
            phasing = Input.GetButton("Player1_Phase");
            //print(phasing);

        }
        else if (playerNumber == PlayerNumber.Player2) {

            xAxis = Input.GetAxis("Player2_Horizontal");
            yAxis = Input.GetAxis("Player2_Vertical");
            phasing = Input.GetButton("Player2_Phase");

        }
        else if (playerNumber == PlayerNumber.Player3) {

            xAxis = Input.GetAxis("Player3_Horizontal");
            yAxis = Input.GetAxis("Player3_Vertical");
            phasing = Input.GetButton("Player3_Phase");

        }
        else if (playerNumber == PlayerNumber.Player4) {

            xAxis = Input.GetAxis("Player4_Horizontal");
            yAxis = Input.GetAxis("Player4_Vertical");
            phasing = Input.GetButton("Player4_Phase");

        }

        Vector3 pos = transform.position;
        float newXPos = pos.x + xAxis * speed;
        float newYPos = pos.y + yAxis * speed;

        //transform.position = new Vector3(newXPos, newYPos, 0f);
        rb.MovePosition(new Vector2(newXPos, newYPos));

        if (phasing && totalStrength > 0f) {

            sr.color = new Color(color.r, color.g, color.b, 0.5f);
            totalStrength -= strengthDelta;

            if (totalStrength < 0f) {
                totalStrength = 0f;
            }

            UIController.uic.UpdateStrength(playerNumber, totalStrength);
            gameObject.layer = 10;
            
        }
        else {

            sr.color = color;
            gameObject.layer = 9;
            phasing = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        CollisionCheck(collision);

    }

    private void OnCollisionStay2D(Collision2D collision) {

        CollisionCheck(collision);

    }

    public void Restart() {
        totalStrength = 100f;
    }
    
    void CollisionCheck(Collision2D collision) {

        GameObject colGameObject = collision.gameObject;

        if (colGameObject.tag == "Player") {

            var playerController = colGameObject.GetComponent<PlayerController>();

            if (phasing && !playerController.phasing) {
                GameController.gc.KillPlayer(playerController.playerNumber);
            }

        }

        if (colGameObject.tag == "PhasePickup") {

            totalStrength += 20f;

            if (totalStrength > 100f) {
                totalStrength = 100f;
            }

            Destroy(colGameObject);
            UIController.uic.UpdateStrength(playerNumber, totalStrength);

        }

    }

}
