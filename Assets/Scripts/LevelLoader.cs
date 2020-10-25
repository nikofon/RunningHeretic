using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject audiomanagerprefab;
    public int currentLevel = 3;
    public static LevelLoader instance;
    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("levelLoaded " + currentLevel);
        if (SceneManager.GetActiveScene().name == "WinScreen")
        { 
            if(AudioManager.instance == null)
            {
                Instantiate(audiomanagerprefab);
            }
            AudioManager.instance.PlaySound("Win");
            Button[] bs = FindObjectsOfType<Button>();
            foreach(Button b in bs)
            {
                switch (b.gameObject.name)
                {
                    case "MainMenu": b.onClick.AddListener(delegate { LoadMainMenu(); });
                        break;
                    case "NextLevel": b.onClick.AddListener(delegate { LoadLevel(currentLevel); });
                        Debug.Log("vur level: " + currentLevel);
                        break;
                }
            }
            
        }
        else if (SceneManager.GetActiveScene().name == "LooseScreen")
        {
            Button[] bs = FindObjectsOfType<Button>();
            foreach (Button b in bs)
            {
                switch (b.gameObject.name)
                {
                    case "MainMenu":
                        b.onClick.AddListener(delegate { LoadMainMenu(); });
                        break;
                    case "Restart":
                        b.onClick.AddListener(delegate { LoadLevel(currentLevel); });
                        break;
                }
            }
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }
    void Start()
    {
        AudioManager.instance.PlayMusic("spookylost");
    }

   public void LoadWinScreen()
   {
        if(currentLevel == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene("FinalScreen");
        }
        Debug.Log("win screen " + currentLevel);
        SceneManager.LoadScene("WinScreen");
        currentLevel += 1;
   }
    public void LoadLooseScreen()
    {
        SceneManager.LoadScene("LooseScreen");
    }
    public void LoadSameLevel()
    {
        LoadLevel(currentLevel);
    }
    
   public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
