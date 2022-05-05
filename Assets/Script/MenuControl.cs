using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    Star Star;
    public Text StarText1;
    public List<Text> StarValues;
    public int StarValue;
    public List<GameObject> Canvass;
  //  public GameObject CanvasSelection;

    [Header("Loading")]
    public GameObject LoadingCanvas;
    public Slider LoadingSlider;

    public AudioSource ClickSound;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Page")==1)
        {
            for (int i = 0; i < Canvass.Count; i++)
            {
                Canvass[i].SetActive(false);
                Canvass[0].SetActive(true);
            }
        }

        if (PlayerPrefs.GetInt("Page") == 2)
        {
            for (int i = 0; i < Canvass.Count; i++)
            {
                Canvass[i].SetActive(false);
                Canvass[1].SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Page") == 3)
        {
            for (int i = 0; i < Canvass.Count; i++)
            {
                Canvass[i].SetActive(false);
                Canvass[2].SetActive(true);
            }
        }

        for (int i = 0; i < StarValues.Count; i++)
        {
            StarValues[i].text= PlayerPrefs.GetInt("StarValue").ToString();
        }
     // PlayerPrefs.SetInt("Level", 81);
        // PlayerPrefs.SetInt("StarValue",0);
        if (!PlayerPrefs.HasKey("StarValue"))
        {
            PlayerPrefs.SetInt("StarValue", 0);

        }
        Debug.Log(PlayerPrefs.GetInt("StarValue"));
        StarText1.text = PlayerPrefs.GetInt("StarValue").ToString();
    }

    public void DifficultyLevel(int Value)
    {
        if (Value==1)
        {
            PlayerPrefs.SetInt("Difficulty", 1);
        }
        if (Value==2)
        {

            PlayerPrefs.SetInt("Difficulty", 2);
        }
        if (Value == 3)
        {

            PlayerPrefs.SetInt("Difficulty", 3);
        }
    }

    IEnumerator SahneYuklemeAsamasi(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        LoadingCanvas.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadingSlider.value = progress;
            yield return null;

        }


    }
    public void Level(int Value)
    {
        ClickSound.Play();
      
            StartCoroutine(SahneYuklemeAsamasi(Value));
        
       // SceneManager.LoadScene(Value);


    }

  public void LevelMenus(int Value)
    {
        
        if (Value==0)
        {
            SceneManager.LoadScene(31);
            PlayerPrefs.SetInt("Page", 1);
        }
        if (Value == 1)
        {
            SceneManager.LoadScene(31);
            PlayerPrefs.SetInt("Page", 2);
        }
        if (Value == 2)
        {
            SceneManager.LoadScene(31);
            PlayerPrefs.SetInt("Page", 3);
        }

    }

    public void LevelNoDif(int LevelNoDifficulty)
    {
  
        PlayerPrefs.SetInt("LevelNoDifficulty", LevelNoDifficulty);

    }

    public void LevelMenusBack()
    {
        ClickSound.Play();
        SceneManager.LoadScene(0);
    }

    public void CanvasBack()
    {
        ClickSound.Play();
        SceneManager.LoadScene(34);
        PlayerPrefs.SetInt("Page", 0);

    }


    public void StartBack()
    {
        SceneManager.LoadScene(0);
    }

    public void CanvasValue(int value)
    {
       
        if (value==0)
        {
            PlayerPrefs.SetInt("Page", 1);
            SceneManager.LoadScene(31);
        }
        else if (value == 1)
        {
            PlayerPrefs.SetInt("Page", 1);
            SceneManager.LoadScene(32);
        }
        else if (value == 2)
        {
            PlayerPrefs.SetInt("Page", 1);
            SceneManager.LoadScene(33);
        }


        else if (value == 3)
        {
            PlayerPrefs.SetInt("Page", 2);
            SceneManager.LoadScene(31);
        }
        else if (value == 4)
        {
            PlayerPrefs.SetInt("Page", 2);
            SceneManager.LoadScene(32);
        }
        else if (value == 5)
        {
            PlayerPrefs.SetInt("Page", 2);
            SceneManager.LoadScene(33);
        }


        else if (value == 6)
        {
            PlayerPrefs.SetInt("Page", 3);
            SceneManager.LoadScene(31);
        }
        else if (value == 7)
        {
            PlayerPrefs.SetInt("Page",3);
            SceneManager.LoadScene(32);
        }
        else if (value == 8)
        {
            PlayerPrefs.SetInt("Page", 3);
            SceneManager.LoadScene(33);
        }


    }
}
