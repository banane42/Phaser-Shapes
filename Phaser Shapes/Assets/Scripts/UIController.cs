using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController uic;

    public Image player1PhaseStrength;
    public Image player2PhaseStrength;
    public Text gameOverText;

    private void Awake() {
        
        if (uic != null) {
            Destroy(uic);
        }

        uic = this;

    }

    public void UpdateStrength(PlayerNumber pNum, float strength) {

        if (pNum == PlayerNumber.Player1) {

            player1PhaseStrength.rectTransform.sizeDelta = new Vector2(strength, 20);

        }
        else if (pNum == PlayerNumber.Player2) {

            player2PhaseStrength.rectTransform.sizeDelta = new Vector2(strength, 20);

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

    }

    public void HideGameOver() {
        gameOverText.gameObject.SetActive(false);
        player1PhaseStrength.rectTransform.sizeDelta = new Vector2(100, 20);
        player2PhaseStrength.rectTransform.sizeDelta = new Vector2(100, 20);
    }

}

public enum PlayerNumber {
    None, Player1, Player2
}
