using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollect : MonoBehaviour
{
    public int gemCnt = 0;
    public static bool startCollect = false;
    public static bool finishCollect = false;
    [SerializeField] private GameObject bodyguard; 
    [SerializeField] private GameObject stoptape;
    public DieScript dieScript;


    // Метод для увеличения счётчика монет
    public void AddGem()
    {
        gemCnt++;
        startCollect = false;
        finishCollect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gemCnt == 3)
        {
            dieScript.Die();
            gemCnt = 0;
        }

    }

    public void StartCollect()
    {
        startCollect = true;
    }

    public void FinishCollect()
    {
        finishCollect = true;
    }

    public void DeleteObstacles()
    {
        Debug.Log("deleted");
        Destroy(bodyguard);
        Destroy(stoptape);
    }
}
