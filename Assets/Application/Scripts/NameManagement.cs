using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManagement : MonoBehaviour
{
    public InputField nameField;
    public Text       errorText;
    public Button     submitButton;


   void Start()
    {
        submitButton.onClick.AddListener(delegate {SetName(nameField);});
    }


    public void SetName(InputField nameField)
    {
        if(string.IsNullOrEmpty(nameField.text)){
            errorText.text = "Namefield can't be empty";
        }
        else
        {
            PlayerPrefs.SetString("Name", nameField.text);
        }
    }
}
