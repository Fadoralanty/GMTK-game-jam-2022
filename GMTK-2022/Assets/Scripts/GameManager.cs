using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public Transform playerTransform;
    public static GameManager instance;
    public List<GameObject> EnemiesOnLevel = new List<GameObject>();
    public GameObject Victory_Screen;
    public GameObject Game_Over_Screen;
    public string NextLevelName;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        Victory_Screen.SetActive(false);
        Game_Over_Screen.SetActive(false);
    }

    private void Update()
    {
        if (EnemiesOnLevel.Count == 0)
        {
            StartCoroutine(LoadNextLevel(NextLevelName));
        }
    }
    
    IEnumerator LoadNextLevel(string levelName)
    {
        Victory_Screen.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(levelName);
    }
    
    public void GameOver()
    {
        Game_Over_Screen.SetActive(true);
    }


}
