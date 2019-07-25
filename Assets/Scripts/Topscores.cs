using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Topscores : MonoBehaviour
{
    [SerializeField] public TextMeshPro topscore1;
    [SerializeField] public TextMeshPro topscore2;
    [SerializeField] public TextMeshPro topscore3;
    [SerializeField] public TextMeshPro topscore4;
    [SerializeField] public TextMeshPro topscore5;
    [SerializeField] public TextMeshPro currentscore;
    [SerializeField] public bool endGame;

    void Start()
    {
        if (endGame)
        {
            int cs = PlayerPrefs.GetInt("currentscore");
            int[] arr = { PlayerPrefs.GetInt("topscore1", 0),
                PlayerPrefs.GetInt("topscore2", 0),
                PlayerPrefs.GetInt("topscore3", 0),
                PlayerPrefs.GetInt("topscore4", 0),
                PlayerPrefs.GetInt("topscore5", 0),
                cs };
            bubbleSort(arr);
            topscore1.text = PlayerPrefs.GetInt("topscore1").ToString();
            currentscore.text = cs.ToString();
        }
        else
        {
            Debug.Log("ELSE");
            int[] arr = { PlayerPrefs.GetInt("topscore1", 0), PlayerPrefs.GetInt("topscore2", 0), PlayerPrefs.GetInt("topscore3", 0), PlayerPrefs.GetInt("topscore4", 0), PlayerPrefs.GetInt("topscore5", 0)};
            bubbleSort(arr);
            topscore1.text = PlayerPrefs.GetInt("topscore1").ToString();
            topscore2.text = PlayerPrefs.GetInt("topscore2").ToString();
            topscore3.text = PlayerPrefs.GetInt("topscore3").ToString();
            topscore4.text = PlayerPrefs.GetInt("topscore4").ToString();
            topscore5.text = PlayerPrefs.GetInt("topscore5").ToString();
        }
        Debug.Log("Despues del IF");
    }

    void bubbleSort (int[] arr)
    {
        int temp = 0;
        for (int write = 0; write < arr.Length; write++)
        {
            for (int sort = 0; sort < arr.Length - 1; sort++)
            {
                if (arr[sort] < arr[sort + 1])
                {
                    temp = arr[sort + 1];
                    arr[sort + 1] = arr[sort];
                    arr[sort] = temp;
                }
            }
        }
        PlayerPrefs.SetInt("topscore1", arr[0]);
        PlayerPrefs.SetInt("topscore2", arr[1]);
        PlayerPrefs.SetInt("topscore3", arr[2]);
        PlayerPrefs.SetInt("topscore4", arr[3]);
        PlayerPrefs.SetInt("topscore5", arr[4]);
    }
}