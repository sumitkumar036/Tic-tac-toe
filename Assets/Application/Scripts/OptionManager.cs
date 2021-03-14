using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    public GameManager gameManager;
    
    void Start()
    {
        button.onClick.AddListener(delegate { SetValue(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetValue()
    {
        if(gameManager.playerMove)
        {
            buttonText.text = gameManager.ChooseOption();
            button.interactable = false;
            gameManager.Compeleted();
        }
    }


    public void GameManagerRef(GameManager manager)
    {
        gameManager = manager;
    }
}
