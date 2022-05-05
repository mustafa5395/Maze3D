using UnityEngine;
using UnityEngine.UI;

public class LevelHard : MonoBehaviour
{
    public int No;
    void Start()
    {
        
        if (No == 1)
        {

            GetComponent<Button>().interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetInt("LevelHard") >= No)
            {
                GetComponent<Button>().interactable = true;
            }


        }
    }

  
}
