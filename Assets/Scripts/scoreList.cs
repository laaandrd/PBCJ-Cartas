using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class scoreList : MonoBehaviour
{
    private List<int> easyScores; // lista de pontuações
    private List<int> mediumScores; // lista de pontuações
    private List<int> hardScores; // lista de pontuações
    public static scoreList instance; // Instancia da lista de pontuações

    void Awake()
    {
        /*Instancia o Gerenciador de pontuações e o destroi caso j� exista*/
        if (instance == null) instance = this;
        else 
        {
            Destroy(gameObject);
            return;
        }

        /*Evita que o Gerenciador de pontuações seja destruido ao abrir outra cena*/
        DontDestroyOnLoad(gameObject);

        // Salva a lista de pontuações
        easyScores = GetRecords("easyScores");
        mediumScores = GetRecords("mediumScores");
        hardScores = GetRecords("hardScores");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Pega a melhor pontuação, ou seja, o record    
    public int GetRecord(int gamemode)
    {
        switch (gamemode)
        {
            case 1:
                return easyScores != null ? easyScores.First() : 0;
            case 2:
                return easyScores != null ? easyScores.First() : 0;
            case 3:
                return easyScores != null ? easyScores.First() : 0;
        }

        return 0;
    }

    // Método para adicionar uma nova pontuação a lista
    public void AddScore(int record, int gameMode) 
    {
        string recordList;
        switch (gameMode)
        {
            case 1:
                easyScores = AddScore(easyScores, record);
                recordList = string.Join(" ", easyScores);
                PlayerPrefs.SetString("easyScores", recordList);
            break;
            case 2:
                mediumScores = AddScore(mediumScores, record);
                recordList = string.Join(" ", mediumScores);
                PlayerPrefs.SetString("mediumScores", recordList);
            break;
            case 3:
                hardScores = AddScore(hardScores, record);
                recordList = string.Join(" ", hardScores);
                PlayerPrefs.SetString("hardScores", recordList);
            break;
        }
    }
    
    public List<int> AddScore(List<int> scores, int record) 
    {
        if (scores == null) scores = new List<int>();
        
        // Adiciona a pontuação e ordena as pontuações
        scores.Add(record);
        scores.Sort();

        // Remove o 6ª pontuação, uma vez que apenas 20 pontuações são mostradas na tela
        if (scores.Count > 5) scores.RemoveAt(scores.Count - 1);

        return scores;
    }

    // Retorna um array com a lista de pontuações
    public int[] ReadList(int gameMode) 
    {
        switch (gameMode)
        {
            case 1:
                return easyScores.ToArray();
            case 2:
                return mediumScores.ToArray();
            case 3:
                return hardScores.ToArray();
        }

        return null;
    }

    public void DeleteList() {
        PlayerPrefs.SetString("RecordList", "");
    }

    public List<int> GetRecords(string name) {
        // Lê a lista de pontuações salva na memória
        string recordList = PlayerPrefs.GetString(name);
        return new List<int>(Array.ConvertAll(recordList.Split(' '), int.Parse));
    }
}
