using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartScene()
    {
        int thisSceneNumber = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(thisSceneNumber);
    }

}
