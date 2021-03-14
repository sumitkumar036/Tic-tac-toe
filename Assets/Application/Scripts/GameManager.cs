using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Text> buttonText = new List<Text>();
    private string playerString,computerString;
    private int counter;

    [Header("PlayerMove")]
    public bool playerMove;

    public GameObject winPanal;

    [Header("Player")]
    public Player playerX;
    public Player player0;

    [Header("Player color")]
    public PlayerColor playerActiveColor;
    public PlayerColor playerInActiveColor;

    public Text ActivePlayerName;
    public Button[] option;


   [Header("computer side")]
    public float delay;
    public int value;
  

    void Awake()
    {
       NameManagement.nameEntered += SetData;
    }

    public void SetData()
    {
        ActivePlayerName.text = "select X or 0 to start";
        SetButtonCondition(false);
        playerMove = true;

        for (int i = 0; i < buttonText.Count; i++)
        {
            buttonText[i].GetComponentInParent<OptionManager>().GameManagerRef(this);
        }
    }

    /// <summary>
    /// This is for getting playerside string i.e which player is active
    /// </summary>
    /// <returns></returns>
    public string ChooseOption()
    {
        return playerString;
    }

    public string ComputerSide()
    {
        return computerString;
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

        //=================================================================================

        if (buttonText[0].text.Equals(computerString) && buttonText[1].text.Equals(computerString) && buttonText[2].text.Equals(computerString))
        {
            GameOver();
        }

        if (buttonText[0].text.Equals(computerString) && buttonText[4].text.Equals(computerString) && buttonText[8].text.Equals(computerString))
        {
            GameOver();
        }

        if (buttonText[0].text.Equals(computerString) && buttonText[3].text.Equals(computerString) && buttonText[6].text.Equals(computerString))
        {
            GameOver();
        }
        if (buttonText[1].text.Equals(computerString) && buttonText[4].text.Equals(computerString) && buttonText[7].text.Equals(computerString))
        {
            GameOver();
        }
        if (buttonText[2].text.Equals(computerString) && buttonText[5].text.Equals(computerString) && buttonText[8].text.Equals(computerString))
        {
            GameOver();
        }

        if (buttonText[3].text.Equals(computerString) && buttonText[4].text.Equals(computerString) && buttonText[5].text.Equals(computerString))
        {
            GameOver();
        }

        if (buttonText[6].text.Equals(computerString) && buttonText[7].text.Equals(computerString) && buttonText[8].text.Equals(computerString))
        {
            GameOver();
        }
        
        //=================================================================================
        MatchDraw();
    }

    void Update()
    {
        if(!playerMove)
        {
            delay += delay * Time.deltaTime;
            if(delay >= 100)
            {
                value = Random.Range(0, 8);
                if(buttonText[value].GetComponentInParent<Button>().interactable)
                {
                    buttonText[value].text = ComputerSide();
                    buttonText[value].GetComponentInParent<Button>().interactable = false;
                   Compeleted();
                }
            }
        }
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
       // playerString = (playerString == "X") ? "0" : "X";
        playerMove = (playerMove == true) ? false : true;

       // if(playerString.Equals("X"))
       if(playerMove)
       {
            SetPlayerColor(playerX, player0, true);          
         ActivePlayerName.text = playerString + " Turn";
       }

        else
        {
             SetPlayerColor(player0, playerX, true);
        
         ActivePlayerName.text = computerString + " Turn";
        }

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

        else
        {
            ChangeTurn();
            delay = 10;
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

        delay = 10;

        playerMove = true;
    }

    public void StartGame(string playerOption)
    {
         playerString = playerOption;
         ActivePlayerName.text = playerString + " Turn";

         SetButtonCondition(true);

        if(playerString.Equals("X"))
        {
         SetPlayerColor(playerX, player0, true);
            computerString = "0";
        }

        if(playerString.Equals("0"))
        {
            SetPlayerColor(player0, playerX, true);
            computerString = "X";
        }

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
