using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateHistory : MonoBehaviour
{

    public GameObject historyObject;
    void Start()
    {
        // GameManager.gameCompleted += InstantiateList;
    }
    public void InstantiateList()
    {
        GameObject obj1 = Instantiate(historyObject, transform.position, Quaternion.identity);
        obj1.transform.SetParent(this.transform);
    }

    void OnDisable()
    {
        //GameManager.gameCompleted -= InstantiateList;
    }
}
