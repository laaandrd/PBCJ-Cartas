using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class scoreList : MonoBehaviour
{
    private List<int> scores;
    public static scoreList instance;

    void Awake()
    {
        /*Instancia o Gerenciador de pontuações e o destroi caso j� exista*/
        if (instance == null) instance = this;
        else 
        {
            Destroy(gameObject);
            return;
        }

        /*Evita que o Gerenciador de records seja destruido ao abrir outra cena*/
        DontDestroyOnLoad(gameObject);

        string recordList = PlayerPrefs.GetString("RecordList");
        scores = new List<int>(Array.ConvertAll(recordList.Split(' '), int.Parse));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetBestRecord()
    {
        return scores != null ? scores.First() : 0;
    }

    public void AddRecord(int record) 
    {
        if (scores == null) scores = new List<int>();
        
        scores.Add(record);
        scores.Sort();

        if (scores.Count > 20) scores.RemoveAt(scores.Count - 1);

        string recordList = string.Join(" ", scores);
        PlayerPrefs.SetString("RecordList", recordList);
    }

    public int[] ReadList() 
    {
        return scores.ToArray();
    }
}
