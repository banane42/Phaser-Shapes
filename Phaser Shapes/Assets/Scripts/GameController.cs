using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController gc;

    public PlayerController Player1;
    public PlayerController Player2;
    public bool gameOver = false;

    Vector3 player1Spawn;
    Vector3 player2Spawn;

    private void Awake() {
        
        if (gc != null) {
            Destroy(gc);
        }

        gc = this;

        player1Spawn = new Vector3(-5, 0, 0);
        player2Spawn = new Vector3(5, 0, 0);

    }

    public void RestartGame() {

        Player1.transform.position = player1Spawn;
        Player2.transform.position = player2Spawn;

        Player1.Restart();
        Player2.Restart();

        Player1.gameObject.SetActive(true);
        Player2.gameObject.SetActive(true);

        UIController.uic.HideGameOver();
        gameOver = false;

    }

}
