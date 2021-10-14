using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numAttemptsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Pega a quantidade de tentativas anterior em mostra na tela
        int numAttempts= PlayerPrefs.GetInt("numAttempts");
        GameObject.Find("numAttempts").GetComponent<Text>().text = "Tentativas: " + numAttempts;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
