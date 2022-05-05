using UnityEngine;
using UnityEngine.UI;

public class LevelMidle : MonoBehaviour
{
    public int No;
    void Start()
    {

        Debug.Log(PlayerPrefs.GetInt("LevelMiddle"));
        if (No == 1 )
        {

            GetComponent<Button>().interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetInt("LevelMiddle") >= No)
            {
                GetComponent<Button>().interactable = true;
            }


        }
    }

}
