using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int No;
  

    List<int> Levels1;
    MenuControl MenuControl;
   public int difficult;

    void Start()
    {
      
        Debug.Log(PlayerPrefs.GetInt("Level"));

        if (No == 1)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetInt("Level") >= No)
            {
                GetComponent<Button>().interactable = true;
            }


        }

     





    }

}
