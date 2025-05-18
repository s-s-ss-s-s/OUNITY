using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCollect : MonoBehaviour
{
    public int gemCnt = 0;
    public static bool startCollect = false;
    public static bool finishCollect = false;
    [SerializeField] private GameObject bodyguard; 
    [SerializeField] private GameObject stoptape;
    public DieScript dieScript;
    [SerializeField] public Text gemCountText;


    void Start()
    {
        startCollect = false;
        finishCollect = false;
        gemCnt = 0;
        UpdateGemCountText();
        gemCountText.gameObject.SetActive(false);
    }
    // Метод для увеличения счётчика монет
    public void AddGem()
    {
        gemCnt++;
        UpdateGemCountText();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gemCnt);
        if (gemCnt == 3)
        {
            if (startCollect && finishCollect)
            {
                Debug.Log("delete");
                //finishCollect = true;
                DeleteObstacles();
                finishCollect = false;
                startCollect = false;
            }
        }

        if (startCollect && !finishCollect)
        {
            gemCountText.gameObject.SetActive(true); // Показываем текст
        }
        else
        {
            gemCountText.gameObject.SetActive(false); // Скрываем текст если не нужно
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
        dieScript.Die();
    }

    private void UpdateGemCountText()
    {
        if (gemCountText != null)
        {
            gemCountText.text = "Gems: " + gemCnt; // Обновляем текст
        }
    }
}
