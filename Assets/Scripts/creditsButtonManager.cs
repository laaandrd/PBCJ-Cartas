using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsButtonManager : MonoBehaviour
{
    public void StartCreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
