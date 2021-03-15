using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstantiateHistory : MonoBehaviour
{

    public GameObject historyObject;
   
    public void InstantiateList()
    {
        GameObject obj1 = Instantiate(historyObject, transform.position, Quaternion.identity);
        obj1.transform.SetParent(this.transform);
    }

  void OnApplicationQuit()
  {
      History history;
      history = historyObject.GetComponent<History>();

      history.playerNameText.text = "";
      history.statusText.text  = "";
      history.scoreText.text  = "";
      history.matchNumberText.text  = "";
      history.timeText.text  = "";
  }
  
}
