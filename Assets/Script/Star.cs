using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public Sprite StarY;
    public int Value;
  
  
    private void Start()
    { 
        if (PlayerPrefs.HasKey("Star" + Value))
        {

           // PlayerPrefs.SetInt("StarValue", PlayerPrefs.GetInt("StarValue") + 1);
            transform.GetComponent<Image>().sprite = StarY;
        }
    }


}
