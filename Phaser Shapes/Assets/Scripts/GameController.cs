using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController gc;

    public PlayerController[] Players;
    public Transform[] walls;
    public int[] playerWins = new int[4];
    public GameObject PhasePickupPrefab;
    public FireCircleController FireCircleController;
    public bool gameOver = false;
    [Range(2, 4)]
    public int playerCount = 4;
    public float spawnTime = 10f;
    float ellapsedTime = 0f;

    LinkedList<GameObject> pickups = new LinkedList<GameObject>();
    Vector3 player1Spawn;
    Vector3 player2Spawn;
    Vector3 player3Spawn;
    Vector3 player4Spawn;
    public int playersKilled = 0;

    private void Awake() {
        
        if (gc != null) {
            Destroy(gc);
        }

        gc = this;

        player1Spawn = Players[0].transform.position;
        player2Spawn = Players[1].transform.position;
        player3Spawn = Players[2].transform.position;
        player4Spawn = Players[3].transform.position;

        foreach (string s in Input.GetJoystickNames()) {
            print(s + Input.GetJoystickNames().Length);
        }

        RestartGame();

    }

    private void Update() {

        ellapsedTime += Time.deltaTime;

        if (!gameOver && ellapsedTime > spawnTime) {
            SpawnPhasePickup();
            ellapsedTime = 0f;
        }

    }

    public void RestartGame() {

        gameOver = false;
        ellapsedTime = 0f;

        foreach (GameObject g in pickups) {
            Destroy(g);
        }

        foreach(PlayerController p in Players) {
            p.gameObject.SetActive(false);
            p.alive = true;
        }

        switch (playerCount) {

            case 2:
                Players[0].transform.position = player1Spawn;
                Players[1].transform.position = player2Spawn;

                Players[0].Restart();
                Players[1].Restart();

                Players[0].gameObject.SetActive(true);
                Players[1].gameObject.SetActive(true);
                break;
            case 3:
                Players[0].transform.position = player1Spawn;
                Players[1].transform.position = player2Spawn;
                Players[2].transform.position = player3Spawn;

                Players[0].Restart();
                Players[1].Restart();
                Players[2].Restart();

                Players[0].gameObject.SetActive(true);
                Players[1].gameObject.SetActive(true);
                Players[2].gameObject.SetActive(true);
                break;
            case 4:
                Players[0].transform.position = player1Spawn;
                Players[1].transform.position = player2Spawn;
                Players[2].transform.position = player3Spawn;
                Players[3].transform.position = player4Spawn;

                Players[0].Restart();
                Players[1].Restart();
                Players[2].Restart();
                Players[3].Restart();

                Players[0].gameObject.SetActive(true);
                Players[1].gameObject.SetActive(true);
                Players[2].gameObject.SetActive(true);
                Players[3].gameObject.SetActive(true);
                break;

        }
        playersKilled = 0;
        UIController.uic.RestartGame(playerCount);
        FireCircleController.Restart();

    }

    public void KillPlayer(PlayerNumber pNum) {

        switch (pNum) {
            case PlayerNumber.Player1:
                Players[0].alive = false;
                Players[0].gameObject.SetActive(false);
                playersKilled += 1;
                break;
            case PlayerNumber.Player2:
                Players[1].alive = false;
                Players[1].gameObject.SetActive(false);
                playersKilled += 1;
                break;
            case PlayerNumber.Player3:
                Players[2].alive = false;
                Players[2].gameObject.SetActive(false);
                playersKilled += 1;
                break;
            case PlayerNumber.Player4:
                Players[3].alive = false;
                Players[3].gameObject.SetActive(false);
                playersKilled += 1;
                break;
        }

        //End game
        if (playersKilled == playerCount - 1) {
            gameOver = true;

            foreach (PlayerController pc in Players) {
                if (pc.gameObject.activeSelf) {
                    playerWins[(int) pc.playerNumber] += 1;
                    UIController.uic.DisplayGameOver(pc.playerNumber);
                    break;
                }
            }
        }

    }

    void SpawnPhasePickup() {
        Transform spawnZone = FireCircleController.MaskTransform;
        float xPos = Random.Range(-spawnZone.localScale.x / 2, spawnZone.localScale.x / 2);//9.6
        float yPos = Random.Range(-spawnZone.localScale.x / 2, spawnZone.localScale.x / 2);

        if (xPos < walls[2].position.x) {
            xPos = walls[2].position.x + 1f;
        }
        else if (xPos > walls[3].position.x) {
            xPos = walls[3].position.x - 1f;
        }

        if (yPos > walls[0].position.y) {
            yPos = walls[0].position.y - 1f;
        }
        else if (yPos < walls[1].position.y) {
            yPos = walls[1].position.y + 1f;
        }

        var pickup = Instantiate(PhasePickupPrefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);
        pickups.AddLast(pickup);
    }

}

public enum PlayerNumber {
    Player1, Player2, Player3, Player4
}