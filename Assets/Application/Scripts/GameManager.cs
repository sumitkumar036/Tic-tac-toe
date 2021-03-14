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
    bool IsGameOver = false;

   [Header("computer side")]
    public float delay;
    public int value;
  
    [Header("Score Board")]
    public Text PlayerName;
    public Text scoreText;
    public int playerScore, machineScore;

    [Header("Win/Loose")]
    public Text winLooseText;
    public Text totalMatchText;
    public int win, Loose;


    [Header("Date & Time")]
    public Text date;
    public Text time;


    void Awake()
    {
       NameManagement.nameEntered += SetData;
      date.text = "Date : "+ System.DateTime.Now.ToString("dd/MM/yyyy");
    }

//=====================================================SetData()============================================================
/// <summary>
/// This is for setting required information on Awake
/// </summary>
    public void SetData()
    {
        ActivePlayerName.text = "Select X or 0 to start";
        SetButtonCondition(false);
        playerMove = true;

        for (int i = 0; i < buttonText.Count; i++)
        {
            buttonText[i].GetComponentInParent<OptionManager>().GameManagerRef(this);
        }

        PlayerName.text = PlayerPrefs.GetString("Name");

        //score
        playerScore = 0; machineScore = 0;
        totalMatchText.text = "Total Match : " + "<color=green>"+ (win + Loose).ToString() +"</color>";
        winLooseText.text = win.ToString() +"  /  " + Loose.ToString() +"\n\n" + Loose.ToString() +"  /  "+ win.ToString();
        scoreText.text = playerScore.ToString() + "\n\n" + machineScore.ToString();
    }

//=====================================================ChooseOption()============================================================
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

//=====================================================Compeleted()============================================================
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
        

        MatchCondition();
        SetScore();
    }
//============================================ Update() ====================================================
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

        time.text = "Time : "+  System.DateTime.Now.ToString("hh:mm:ss");
    }

//============================================ SetScore() ====================================================
    /// <summary>
    /// This is for set the score of both player
    /// </summary>
    private void SetScore()
    {
        scoreText.text = playerScore.ToString() + "\n\n" + machineScore.ToString();

        if(IsGameOver)
        {
           
            if(playerScore > machineScore)
            {
                win +=1;
                scoreText.text = "<color=green>"+ playerScore.ToString() + "</color>" + "\n\n" + machineScore.ToString();
                winPanal.GetComponentInChildren<Text>().text = "Congratulation !!"+ "\n" + ""+PlayerPrefs.GetString("Name") + " You won the match !!";            
            }
            else
            {
                Loose +=1;
                scoreText.text = "<color=red>"+ playerScore.ToString() + "</color>" + "\n\n " + machineScore.ToString();
                winPanal.GetComponentInChildren<Text>().text = "Machine won the match";

            }
            winLooseText.text = win.ToString() +"  /  " + Loose.ToString() +"\n\n" + Loose.ToString() +"  /  "+ win.ToString();
            totalMatchText.text = "Total Match :" + "<color=yellow>"+ (win + Loose).ToString() +"</color>";
        }
    }
    
//============================================ GameOver() ====================================================
    /// <summary>
    /// Tihs is for checking either game is draw, win or loss
    /// </summary>
    void GameOver()
    {
        IsGameOver = true;
        SetButtonCondition(false);
        winPanal.SetActive(true);
     //   SetScore();
    }

 //============================================ ChangeTurn() ====================================================
    /// <summary>
    /// This is for changing the side of player one after another
    /// </summary>
    void ChangeTurn()
    {
        playerMove = (playerMove == true) ? false : true;
       if(playerMove)
       {
            SetPlayerColor(playerX, player0, true);          
            ActivePlayerName.text = PlayerPrefs.GetString("Name") + " Turn";
            machineScore += 1;
       }

        else
        {
            SetPlayerColor(player0, playerX, true);
            ActivePlayerName.text = "Machine Turn";
            playerScore +=1;
        }
    }

    //============================================ MatchCondition() ====================================================

    /// <summary>
    /// This is for checking condition if game is draw
    /// </summary>

    public void MatchCondition()
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
    //============================================Retry()====================================================
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
        ActivePlayerName.text = PlayerPrefs.GetString("Name") + " Turn";

        for (int i = 0; i < option.Length; i++){option[i].enabled = true;}

        delay = 10;

        playerMove = true;
        IsGameOver = false;

        playerScore = 0;
        machineScore = 0;
        scoreText.text = "<color=white>"+ playerScore.ToString() + "</color>" + "\n\n" + machineScore.ToString();
    }

//============================================StartGame()========================================================
/// <summary>
/// his is for starting the game
/// </summary>
/// <param name="playerOption"></param>
    private void StartGame(string playerOption)
    {
         playerString = playerOption;
         ActivePlayerName.text = PlayerPrefs.GetString("Name") + " Turn";

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

    //==============================================SetButtonCondition()===========================================
    /// <summary>
    /// This i for making the button active or Inactive based on the condition
    /// </summary>
    /// <param name="state">set tru/false</param>
    void SetButtonCondition(bool state)
    {
        for (int i = 0; i < buttonText.Count; i++)
        {
            buttonText[i].GetComponentInParent<Button>().interactable = state;
        }

    }
//==============================================SetPlayerColor()==================================================
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
