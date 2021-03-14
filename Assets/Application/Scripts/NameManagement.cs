using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NameManagement : MonoBehaviour
{
    public InputField nameField;
    public Text       errorText;
    public Button     submitButton;
    public UnityEvent whenConditionTrue;

    public delegate void NameEntered();
    public static event NameEntered nameEntered;

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
            whenConditionTrue.Invoke();
        }

        nameEntered();
    }
}
