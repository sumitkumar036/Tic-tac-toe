using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Text> buttonText = new List<Text>();
    private string playerString;
    private int counter;
    public GameObject winPanal;

    [Header("Player")]
    public Player playerX;
    public Player player0;

    [Header("Player color")]
    public PlayerColor playerActiveColor;
    public PlayerColor playerInActiveColor;

    public Text ActivePlayerName;
    public Button[] option;
  

    void Awake()
    {
        for (int i = 0; i < buttonText.Count; i++)
        {
            buttonText[i].GetComponentInParent<OptionManager>().GameManagerRef(this);
        }
    //    SetPlayerColor(playerX, player0);
    //    playerString = "X";

        ActivePlayerName.text = "select X or 0 to start";
        SetButtonCondition(false);
    }

    /// <summary>
    /// This is for getting playerside string i.e which player is active
    /// </summary>
    /// <returns></returns>
    public string ChooseOption()
    {
        return playerString;
    }

    /// <summary>
    /// This is for checking all the possibilities of win condition
    /// </summary>
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


    /// <summary>
    /// Tihs is for checking either game is draw, win or loss
    /// </summary>
    void GameOver()
    {
        SetButtonCondition(false);
        winPanal.SetActive(true);
        winPanal.GetComponentInChildren<Text>().text = playerString + " win";
    }

    /// <summary>
    /// This is for changing the side of player one after another
    /// </summary>
    void ChangeTurn()
    {
        playerString = (playerString == "X") ? "0" : "X";

        if(playerString.Equals("X"))
            SetPlayerColor(playerX, player0, true);

        else if(playerString.Equals("0"))
             SetPlayerColor(player0, playerX, true);
        
         ActivePlayerName.text = playerString + " Turn";
    }

    /// <summary>
    /// This is for checking condition if game is draw
    /// </summary>

    public void MatchDraw()
    {
        counter += 1;
        if (counter >= 9)
        {
            winPanal.SetActive(true);
            winPanal.GetComponentInChildren<Text>().text = "It's draw, play again";
        }
    }

    /// <summary>
    /// This is for resetting the gameplay
    /// </summary>
    public void Retry()
    {
        counter = 0;
        SetButtonCondition(false);
        playerString = "X";
        for (int i = 0; i < buttonText.Count; i++)
        {
            buttonText[i].text = null;
        }
        winPanal.SetActive(false);

        SetPlayerColor(playerX, player0, false);
        ActivePlayerName.text = playerString + " Turn";

        for (int i = 0; i < option.Length; i++){option[i].enabled = true;}
    }

    public void StartGame(string playerOption)
    {
         playerString = playerOption;
         ActivePlayerName.text = playerString + " Turn";

         SetButtonCondition(true);

        if(playerString.Equals("X"))
         SetPlayerColor(playerX, player0, true);

             if(playerString.Equals("0"))
         SetPlayerColor(player0, playerX, true);

        for (int i = 0; i < option.Length; i++){option[i].enabled = false;}
    }

    /// <summary>
    /// This i for making the button active or Inactive based on the condition
    /// </summary>
    /// <param name="state"></param>
    void SetButtonCondition(bool state)
    {
        for (int i = 0; i < buttonText.Count; i++)
        {
            buttonText[i].GetComponentInParent<Button>().interactable = state;
        }

    }

    /// <summary>
    /// This is for setting the player color
    /// </summary>
    /// <param name="active">Active player</param>
    /// <param name="Inactive">Inactive player</param>
    public void SetPlayerColor(Player active, Player Inactive, bool setcolor)
    {
        if(setcolor)
        {
            active.BG.color = playerActiveColor.BgColor;
            active.playerText.color = playerActiveColor.playerTextColor;
        }
        else
        {
            
           active.BG.color = playerInActiveColor.BgColor;
            active.playerText.color = playerInActiveColor.playerTextColor;
        }
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
