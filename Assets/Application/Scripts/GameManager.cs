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
        playerString = (playerString == "sumit") ? "0" : "sumit";
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

        winPanal.SetActive(false);
    }


    void SetButtonCondition(bool state)
    {
        for (int i = 0; i < buttonText.Count; i++)
        {
            buttonText[i].GetComponentInParent<Button>().interactable = state;
        }

    }
}
