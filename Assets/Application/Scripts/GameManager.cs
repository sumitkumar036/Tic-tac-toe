using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Text> buttonText = new List<Text>();
    public string playerString;
    public int counter;
    public GameObject winPanal;

    [Header("Player")]
    public Player playerX;
     public Player player0;

    [Header("Player color")]
    public PlayerColor playerActiveColor;
    public PlayerColor playerInActiveColor;

    public Text ActivePlayerName;

    void Awake()
    {
        for (int i = 0; i < buttonText.Count; i++)
        {
            buttonText[i].GetComponentInParent<OptionManager>().GameManagerRef(this);
        }
    }

    public string ChooseOption()
    {
        return playerString;
    }

    public void Compeleted()
    {

        if (buttonText[0].text.Equals(playerString) && buttonText[1].text.Equals(playerString) && buttonText[2].text.Equals(playerString))
        {
            GameOver();
        }

        if (buttonText[0].text.Equals(playerString) && buttonText[4].text.Equals(playerString) && buttonText[8].text.Equals(playerString))
        {
            GameOver();
        }

        if (buttonText[0].text.Equals(playerString) && buttonText[3].text.Equals(playerString) && buttonText[6].text.Equals(playerString))
        {
            GameOver();
        }
        if (buttonText[1].text.Equals(playerString) && buttonText[4].text.Equals(playerString) && buttonText[7].text.Equals(playerString))
        {
            GameOver();
        }
        if (buttonText[2].text.Equals(playerString) && buttonText[5].text.Equals(playerString) && buttonText[8].text.Equals(playerString))
        {
            GameOver();
        }

        if (buttonText[3].text.Equals(playerString) && buttonText[4].text.Equals(playerString) && buttonText[5].text.Equals(playerString))
        {
            GameOver();
        }

        if (buttonText[6].text.Equals(playerString) && buttonText[7].text.Equals(playerString) && buttonText[8].text.Equals(playerString))
        {
            GameOver();
        }
        ChangeTurn();
        MatchDraw();
    }


    void GameOver()
    {
        SetButtonCondition(false);
        winPanal.SetActive(true);
        winPanal.GetComponentInChildren<Text>().text = playerString + " win";
    }


    void ChangeTurn()
    {
        playerString = (playerString == "X") ? "0" : "X";

        if(playerString.Equals("X"))
            SetPlayerColor(playerX, player0);

        else if(playerString.Equals("0"))
             SetPlayerColor(player0, playerX);
        
        ActivePlayerName.text = playerString;
    }

    public void MatchDraw()
    {
        counter += 1;
        if (counter >= 9)
        {
            winPanal.SetActive(true);
            winPanal.GetComponentInChildren<Text>().text = "It's draw, try again";
        }
    }

    public void Retry()
    {
        counter = 0;
        SetButtonCondition(true);
        playerString = "X";
        for (int i = 0; i < buttonText.Count; i++)
        {
            buttonText[i].text = null;
        }
        winPanal.SetActive(false);
    }


    void SetButtonCondition(bool state)
    {
        for (int i = 0; i < buttonText.Count; i++)
        {
            buttonText[i].GetComponentInParent<Button>().interactable = state;
        }

    }

    public void SetPlayerColor(Player active, Player Inactive)
    {
        
            active.BG.color = playerActiveColor.BgColor;
            active.playerText.color = playerActiveColor.playerTextColor;

            Inactive.BG.color = playerInActiveColor.BgColor;
            Inactive.playerText.color = playerInActiveColor.playerTextColor;
    }
}

[System.Serializable]
public class Player{
    public Image BG;
    public Text playerText;
}

[System.Serializable]
public class PlayerColor{
    public Color BgColor;
    public Color playerTextColor;

}
