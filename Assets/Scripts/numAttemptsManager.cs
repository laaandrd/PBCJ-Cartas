using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numAttemptsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Pega a quantidade de tentativas anterior e mostra na tela
        int numAttempts= PlayerPrefs.GetInt("numAttempts");
        GameObject.Find("numAttempts").GetComponent<Text>().text = "Tentativas: " + numAttempts;
        
        int record = FindObjectOfType<scoreList>().GetRecord();
        GameObject.Find("record").GetComponent<Text>().text = "Recorde: " + record;

        if (numAttempts == record) FindObjectOfType<AudioManager>().Play("Victory");
    }
}
