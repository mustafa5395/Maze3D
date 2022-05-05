using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCont : MonoBehaviour
{
    public GameObject ReplayCanvas;
    public GameObject QuitCanvas;
    public AudioSource ClickSound;
    public void GameStart()
    {
        SceneManager.LoadScene(34);
    }

   
    public void Replay()
    {
        ReplayCanvas.SetActive(true);
        ClickSound.Play();
       
    }

    public void ReplayQuit()
    {
        ReplayCanvas.SetActive(false);
        ClickSound.Play();

    }
    public void ReplayOkey()
    {

        ClickSound.Play();
        ReplayCanvas.SetActive(false);
        PlayerPrefs.DeleteAll();
    }


   
    public void NoQuit()
    {
        ClickSound.Play();
        QuitCanvas.SetActive(false);

    }
    public void Quit()
    {
        Application.Quit();
        ClickSound.Play();
        QuitCanvas.SetActive(false);
    }
    public void QuitCanvasIsactive()
    {
        ClickSound.Play();
        QuitCanvas.SetActive(true);
    }


}

