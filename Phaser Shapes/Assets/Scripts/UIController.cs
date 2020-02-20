using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController uic;

    public Image player1PhaseStrength;
    public Image player2PhaseStrength;
    public Image player3PhaseStrength;
    public Image player4PhaseStrength;
    public Text gameOverText;
    public Text player1Text;
    public Text player2Text;
    public Text player3Text;
    public Text player4Text;
    public Text[] playerWins;

    private void Awake() {
        
        if (uic != null) {
            Destroy(uic);
        }

        uic = this;

    }

    public void RestartGame(int playerCount) {

        switch (playerCount) {

            case 2:
                player1Text.gameObject.SetActive(true);
                player2Text.gameObject.SetActive(true);
                player3Text.gameObject.SetActive(false);
                player4Text.gameObject.SetActive(false);
                break;
            case 3:
                player1Text.gameObject.SetActive(true);
                player2Text.gameObject.SetActive(true);
                player3Text.gameObject.SetActive(true);
                player4Text.gameObject.SetActive(false);
                break;
            case 4:
                player1Text.gameObject.SetActive(true);
                player2Text.gameObject.SetActive(true);
                player3Text.gameObject.SetActive(true);
                player4Text.gameObject.SetActive(true);
                break;

        }

        gameOverText.gameObject.SetActive(false);
        player1PhaseStrength.rectTransform.sizeDelta = new Vector2(100, 20);
        player2PhaseStrength.rectTransform.sizeDelta = new Vector2(100, 20);
        player3PhaseStrength.rectTransform.sizeDelta = new Vector2(100, 20);
        player4PhaseStrength.rectTransform.sizeDelta = new Vector2(100, 20);
    }

    public void UpdateStrength(PlayerNumber pNum, float strength) {

        if (pNum == PlayerNumber.Player1) {

            player1PhaseStrength.rectTransform.sizeDelta = new Vector2(strength, 20);

        }
        else if (pNum == PlayerNumber.Player2) {

            player2PhaseStrength.rectTransform.sizeDelta = new Vector2(strength, 20);

        }
        else if (pNum == PlayerNumber.Player3) {

            player3PhaseStrength.rectTransform.sizeDelta = new Vector2(strength, 20);

        }
        else if (pNum == PlayerNumber.Player4) {

            player4PhaseStrength.rectTransform.sizeDelta = new Vector2(strength, 20);

        }

    }

    public void DisplayGameOver(PlayerNumber pNum) {

        gameOverText.gameObject.SetActive(true);

        if (pNum == PlayerNumber.Player1) {
            gameOverText.text = "Player 1 Wins!";
        }
        else if (pNum == PlayerNumber.Player2) {
            gameOverText.text = "Player 2 Wins!";
        }
        else if (pNum == PlayerNumber.Player3) {
            gameOverText.text = "Player 3 Wins!";
        }
        else if (pNum == PlayerNumber.Player4) {
            gameOverText.text = "Player 4 Wins!";
        }

        for (int i = 0; i < playerWins.Length; i++) {
            playerWins[i].text = GameController.gc.playerWins[i].ToString();
        }

    }

}