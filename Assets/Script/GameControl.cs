using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameControl : MonoBehaviour
{

    public GameObject Sound;

    [Header("GENERAL SETTÝNGS")]
    public GameObject SettingCanvas;
    public AudioSource ClickSound;
    public List<GameObject> Cameras;
    public List<GameObject> MapCameras;
    public GameObject MiniMap;
    public GameObject MiniMapButton;
    public GameObject MiniMapGeneralButton;
    public GameObject SettingButton2;
    public GameObject SettingButton;
    public GameObject MiniMapCanvas;
    public GameObject MiniMap2;
    public GameObject Canvas;
    public Camera CharacterCamera;
    Player player;
    GameSound GameSound;

    [Header("Loading")]
    public GameObject LoadingCanvas;
    public Slider LoadingSlider;

    [Header("GoogleAds")]
    private RewardedAd OdulluReklamim;
    public GameObject AdsButton;
    string AndroidOdulluReklamKimligi;
    string Reklamid;
    
    public GameObject AdsCanvasPrize;


    private InterstitialAd InterVideoTransitionAds;
    public string AdsVideoId;

    [Header("Star")]
    public int StarValue;
    public Text ClueText;
    public List<float> StarList;
    public List<int> ClueTimeList;
    public List<int> ClueList;
    public int TotalClueValue;

    [Header("Sayac")]
    public float ToplamZaman;
    public Text Sayac;
    float dakika;
    float saniye;
    public bool zamanlayici;
    float gecenzaman;

    [Header("Canvas")]
    public GameObject WinCanvas;
    public GameObject WinCanvas1;
    public GameObject WinCanvas2;
    public GameObject WinCanvas3;
    int MiniMapValue;

    [Header("Sound")]
    public AudioSource BonusSound;
    Complete Complete;
    float SoundVolValue;
    
    void Start()
    {
        Time.timeScale = 1;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        GameSound = GameObject.FindWithTag("Sound").GetComponent<GameSound>();
         SoundVolValue= GameSound.GetComponent<AudioSource>().volume ;
        TotalClueValue = 6;
        Debug.Log(PlayerPrefs.GetInt("LevelNoDifficulty"));
        Complete = GameObject.FindWithTag("Complete").GetComponent<Complete>();

        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {

            if (Complete.Level > 1 && Complete.Level <= 11)
            {
                for (int i = 0; i < ClueTimeList.Count; i++)
                {
                    ClueTimeList[i] = ClueTimeList[i] + 10;
                }
                Debug.Log("Dif 2 2");
                PlayerPrefs.SetInt("LevelNoDifficulty", Complete.Level + 39);
            }

            if (Complete.Level > 11 && Complete.Level <= 21)
            {
                for (int i = 0; i < ClueTimeList.Count; i++)
                {
                    ClueTimeList[i] = ClueTimeList[i] + 15;
                }
                Debug.Log("Dif 2 2");
                PlayerPrefs.SetInt("LevelNoDifficulty", Complete.Level + 39);
            }

            if (Complete.Level > 21 && Complete.Level <= 31)
            {
                PlayerPrefs.SetInt("LevelNoDifficulty", Complete.Level + 49);
                for (int i = 0; i < ClueTimeList.Count; i++)
                {
                    ClueTimeList[i] = ClueTimeList[i] + 25;
                }
            }


        }





        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
          
            if (Complete.Level>=1&& Complete.Level<=11/*|| Complete.Level >= 1 && Complete.Level==11*/)
            {
                Debug.Log("Dif 2");
                PlayerPrefs.SetInt("LevelNoDifficulty", Complete.Level + 29);
                for (int i = 0; i < ClueTimeList.Count; i++)
                {
                    ClueTimeList[i] = ClueTimeList[i] + 15;
                }
            }

            if (Complete.Level > 11 && Complete.Level <= 21)
            {
                Debug.Log("Dif 2 2");
                PlayerPrefs.SetInt("LevelNoDifficulty", Complete.Level + 39);
                for (int i = 0; i < ClueTimeList.Count; i++)
                {
                    ClueTimeList[i] = ClueTimeList[i] + 20;
                }
            }

            if (Complete.Level > 21 && Complete.Level <= 31)
            {
                for (int i = 0; i < ClueTimeList.Count; i++)
                {
                    ClueTimeList[i] = ClueTimeList[i] + 30;
                }
                PlayerPrefs.SetInt("LevelNoDifficulty", Complete.Level + 49);
            }


        }

        if (PlayerPrefs.GetInt("Difficulty") == 3)
        {
            gameObject.AddComponent(typeof(AudioListener));
            if (Complete.Level >= 1 && Complete.Level <= 11)
            {
                for (int i = 0; i < ClueTimeList.Count; i++)
                {
                    ClueTimeList[i] = ClueTimeList[i] + 25;
                }
             
                PlayerPrefs.SetInt("LevelNoDifficulty", Complete.Level + 39);
              
            }
           else if (Complete.Level >= 11 && Complete.Level <= 21)
            {
                PlayerPrefs.SetInt("LevelNoDifficulty", Complete.Level + 49);
                for (int i = 0; i < ClueTimeList.Count; i++)
                {
                    ClueTimeList[i] = ClueTimeList[i] + 35;
                }
            }

            else if(Complete.Level >= 21 && Complete.Level <= 31)
            {
                
                PlayerPrefs.SetInt("LevelNoDifficulty", Complete.Level + 59);
                for (int i = 0; i < ClueTimeList.Count; i++)
                {
                    ClueTimeList[i] = ClueTimeList[i] + 45;
                }
            }

        }


     
        if (!PlayerPrefs.HasKey("NextLevelAds"))
        {
            PlayerPrefs.SetInt("NextLevelAds", 1);
        }

        if (!PlayerPrefs.HasKey("AgainLevelAds"))
        {
            PlayerPrefs.SetInt("AgainLevelAds", 1);
        }

        RequestOdulluReklam();
        RequestVideoTransition();
        AndroidOdulluReklamKimligi = "ca-app-pub-3940256099942544/5224354917";
      
        if (!PlayerPrefs.HasKey("TotalClue"))
        {
            PlayerPrefs.SetInt("TotalClue", 0);

        }

        ClueText.text = (PlayerPrefs.GetInt("TotalClue").ToString() + "/"+TotalClueValue);
        if (PlayerPrefs.GetInt("StarValue")>=2)
        {
            MiniMapButton.GetComponent<Image>().raycastTarget = true ;
        }
        else
        {
            MiniMapButton.GetComponent<Image>().raycastTarget = false ;
        }

        for (int i = 0; i < Cameras.Count; i++)
        {
            Cameras[i].SetActive(false);
        }
        Difficult();
        zamanlayici = false;
        gecenzaman = 0;
        MiniMapValue = 0;

        if (PlayerPrefs.GetInt("TotalClue") < TotalClueValue)
        {
            MiniMapButton.GetComponent<Image>().raycastTarget = false;
        }
        else if (PlayerPrefs.GetInt("TotalClue") > TotalClueValue)
        {
            MiniMapButton.GetComponent<Image>().raycastTarget = true;

        }
        else
        {
            MiniMapButton.GetComponent<Image>().raycastTarget = true;
        }


        if (OdulluReklamim.IsLoaded())
        {
            if (PlayerPrefs.GetInt("TotalClue") < 6)
            {

                AdsButton.SetActive(true);
            }
            if (PlayerPrefs.GetInt("TotalClue") >= 6)
            {

                AdsButton.SetActive(false);
            }
           
        }

        
    }


    private void Update()
    {
           
        if (zamanlayici)
        {
            ToplamZaman += Time.deltaTime;
            dakika = Mathf.FloorToInt(ToplamZaman / 60); //  119 / 2 = 1       
            saniye = Mathf.FloorToInt(ToplamZaman % 60); // 119 / 2 = 1 *****  => 59     

            Sayac.text = Mathf.FloorToInt(ToplamZaman).ToString();
            Sayac.text = string.Format("{0:00}:{1:00}", dakika, saniye);
        }

        if (PlayerPrefs.GetInt("TotalClue") < 6)
        {
            AdsButton.SetActive(true);

        }
        if (PlayerPrefs.GetInt("TotalClue") > 6)
            {

                AdsButton.SetActive(false);
            }
        
        

    }

    public void Win()
    {
        Time.timeScale =0;
        zamanlayici = false;
        //WinCanvas.SetActive(true);
        GameSound.GetComponent<AudioSource>().volume = 0;
        for (int i = 0; i < StarList.Count; i++)
        {
            if (ToplamZaman <= ClueTimeList[0])
            {
                WinCanvas3.SetActive(true);
                if (!PlayerPrefs.HasKey("Star"+ StarList[0]))
                {
                    PlayerPrefs.SetInt("Star" + StarList[0], 1);
                    PlayerPrefs.SetInt("StarValue", PlayerPrefs.GetInt("StarValue")+1);

                }
                if (!PlayerPrefs.HasKey("Star" + StarList[1]))
                {
                    PlayerPrefs.SetInt("Star" + StarList[1], 1);
                    PlayerPrefs.SetInt("StarValue", PlayerPrefs.GetInt("StarValue") + 1);
                }
                if (!PlayerPrefs.HasKey("Star" + StarList[2]))
                {
                    PlayerPrefs.SetInt("Star" + StarList[2], 1);
                    PlayerPrefs.SetInt("StarValue", PlayerPrefs.GetInt("StarValue") + 1);
                }

                

                if (!PlayerPrefs.HasKey("Clue"+ClueList[0]))
                {
                    PlayerPrefs.SetInt("Clue" + ClueList[0], 1);

                    PlayerPrefs.SetInt("TotalClue",PlayerPrefs.GetInt("TotalClue")+1);

                }
                if (!PlayerPrefs.HasKey("Clue" + ClueList[1]))
                {
                    PlayerPrefs.SetInt("Clue" + ClueList[1], 1);
                    PlayerPrefs.SetInt("TotalClue", PlayerPrefs.GetInt("TotalClue") + 1);
                }
                if (!PlayerPrefs.HasKey("Clue" + ClueList[2]))
                {
                    PlayerPrefs.SetInt("Clue" + ClueList[2], 1);
                    PlayerPrefs.SetInt("TotalClue", PlayerPrefs.GetInt("TotalClue") + 1);
                }


                Debug.Log("Star1");
            }
            if (ToplamZaman >= ClueTimeList[0] && ToplamZaman <= ClueTimeList[1])
            {
                WinCanvas2.SetActive(true);
                if (!PlayerPrefs.HasKey("Star" + StarList[0]))
                {
                    PlayerPrefs.SetInt("Star" + StarList[0], 1);
                    PlayerPrefs.SetInt("StarValue", PlayerPrefs.GetInt("StarValue") + 1);

                }
                if (!PlayerPrefs.HasKey("Star" + StarList[1]))
                {
                    PlayerPrefs.SetInt("Star" + StarList[1], 1);
                    PlayerPrefs.SetInt("StarValue", PlayerPrefs.GetInt("StarValue") + 1);
                }

                Debug.Log("Star2");

                if (!PlayerPrefs.HasKey("Clue" + ClueList[0]))
                {
                    PlayerPrefs.SetInt("Clue" + ClueList[0], 1);
                    PlayerPrefs.SetInt("TotalClue", PlayerPrefs.GetInt("TotalClue") + 1);
                }
                if (!PlayerPrefs.HasKey("Clue" + ClueList[1]))
                {
                    PlayerPrefs.SetInt("Clue" + ClueList[1], 1);
                    PlayerPrefs.SetInt("TotalClue", PlayerPrefs.GetInt("TotalClue") + 1);
                }
            }
            if (ToplamZaman >= ClueTimeList[1]&& ToplamZaman <= ClueTimeList[2]|| ToplamZaman >= ClueTimeList[2])
            {
                WinCanvas1.SetActive(true);
                if (!PlayerPrefs.HasKey("Star" + StarList[0]))
                {
                    PlayerPrefs.SetInt("Star" + StarList[0], 1);
                    PlayerPrefs.SetInt("StarValue", PlayerPrefs.GetInt("StarValue") + 1);

                }

                PlayerPrefs.SetInt("Star" + StarList[0], 1);
                if (!PlayerPrefs.HasKey("Clue" + ClueList[0]))
                {
                    PlayerPrefs.SetInt("Clue" + ClueList[0], 1);
                    PlayerPrefs.SetInt("TotalClue", PlayerPrefs.GetInt("TotalClue") + 1);
                }
                Debug.Log("Star3");
            }
          

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
    public void MiniMapIsActive()
    {
        zamanlayici = false;
        ClickSound.Play();
        if (PlayerPrefs.GetInt("TotalClue") >=6)
        {
            PlayerPrefs.SetInt("TotalClue", PlayerPrefs.GetInt("TotalClue") - 6);
            MiniMapButton.GetComponent<Image>().raycastTarget = true;
            MiniMapCanvas.SetActive(true);
            MapCameras[0].SetActive(true);
            Canvas.SetActive(false);
            ClueText.text = (PlayerPrefs.GetInt("TotalClue").ToString() + "/" + TotalClueValue);

        }
        if (PlayerPrefs.GetInt("TotalClue") == 6)
        {
            PlayerPrefs.SetInt("TotalClue", PlayerPrefs.GetInt("TotalClue") - 6);
            MiniMapButton.GetComponent<Image>().raycastTarget = true;
            MiniMapCanvas.SetActive(true);
            MapCameras[0].SetActive(true);
            Canvas.SetActive(false);
            ClueText.text = (PlayerPrefs.GetInt("TotalClue").ToString() + "/" + TotalClueValue);

        }

        if (PlayerPrefs.GetInt("TotalClue") < 6)
        {
            MiniMapButton.GetComponent<Image>().raycastTarget = false ;
            MiniMapCanvas.SetActive(true);
            MapCameras[0].SetActive(true);
            Canvas.SetActive(false);

        }
        if (PlayerPrefs.GetInt("TotalClue") < 6)
        {

            MiniMapButton.GetComponent<Image>().raycastTarget = false;
        }


    }

    public void MiniMapClose()
    {
        RequestOdulluReklam();
        zamanlayici = true;
        ClickSound.Play();
        MiniMapCanvas.SetActive(false);
        MapCameras[0].SetActive(false);
        Canvas.SetActive(true);
        ClueText.text = (PlayerPrefs.GetInt("TotalClue").ToString() + "/" + TotalClueValue);
        if (PlayerPrefs.GetInt("TotalClue") < 6)
        {
         
            AdsButton.SetActive(true);
        }
        if (PlayerPrefs.GetInt("TotalClue") >= 6)
        {
         
            AdsButton.SetActive(false);
        }

    }

    public void MenuSettings()
    {
        GameSound.GetComponent<AudioSource>().volume=0;
        ClickSound.Play();
      
        SettingCanvas.SetActive(true);
        zamanlayici = false;

    }
    public void MainMenu(int Value)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(34);
        ClickSound.Play();
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        ClickSound.Play();
        if (PlayerPrefs.GetInt("NextLevelAds")==3)
        {
            GameOverVideoAds();
            PlayerPrefs.SetInt("NextLevelAds", 1);

            PlayerPrefs.SetInt("AgainLevelAds", 1);
            Debug.Log("geçiþ gird");
        }
        else
        {
            RequestVideoTransition();
            PlayerPrefs.SetInt("NextLevelAds", PlayerPrefs.GetInt("NextLevelAds")+1);
        }

        if (Complete.Level>=31)
        {
            StartCoroutine(SahneYuklemeAsamasi(34));
        }
        else
        {
            StartCoroutine(SahneYuklemeAsamasi(SceneManager.GetActiveScene().buildIndex + 1));
        }
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Again()
    {
        Time.timeScale = 1;
        ClickSound.Play();
        if (PlayerPrefs.GetInt("AgainLevelAds") == 3)
        {
            GameOverVideoAds();
            PlayerPrefs.SetInt("NextLevelAds", 1);
            PlayerPrefs.SetInt("AgainLevelAds", 1);
            Debug.Log("geçiþ gird");
        }
        else
        {
            RequestVideoTransition();
            PlayerPrefs.SetInt("AgainLevelAds", PlayerPrefs.GetInt("AgainLevelAds") + 1);
        }


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Difficult()
    {
        zamanlayici = false;
        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {

            if (PlayerPrefs.GetInt("LevelNoDifficulty") >= 1 && PlayerPrefs.GetInt("LevelNoDifficulty") <= 10)
            {
                //------------1 / 10 arasý bölüm zorluk derecesi 1
                for (int i = 0; i < StarList.Count; i++)
                {
                    StarList[i] = StarList[i] + 0;
                }
                Complete.Level = Complete.Level + 0;
                Debug.Log("girdimi");


            }
            MiniMap.SetActive(true);
            MiniMap2.SetActive(false);
            Cameras[0].SetActive(true);
            for (int i = 0; i < MapCameras.Count; i++)
            {
                MapCameras[i].SetActive(false);
            }
            MapCameras[0].SetActive(true);
            SettingButton2.SetActive(false);
            SettingButton2.SetActive(false);
         
            
        }

        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
            if (PlayerPrefs.GetInt("LevelNoDifficulty") >= 31 && PlayerPrefs.GetInt("LevelNoDifficulty") <= 40)
            {
                //------------1 / 10 arasý bölüm zorluk derecesi 2
                for (int i = 0; i < StarList.Count; i++)
                {
                    StarList[i] = StarList[i] + 90;
                    Debug.Log(StarList[i]);
                }

                for (int i = 0; i < ClueList.Count; i++)
                {
                    ClueList[i] = ClueList[i] + 90;
                }
              
                Debug.Log("girdimi");


            }

            if (PlayerPrefs.GetInt("LevelNoDifficulty") >= 51 && PlayerPrefs.GetInt("LevelNoDifficulty") <= 60)
            {
                //------------11 / 20 arasý bölüm zorluk derecesi 2 --------------//
                for (int i = 0; i < StarList.Count; i++)
                {
                    StarList[i] = StarList[i] + 120;

                }
                for (int i = 0; i < ClueList.Count; i++)
                {
                    ClueList[i] = ClueList[i] + 120;
                }
               
                Debug.Log(Complete.Level);


            }

            if (PlayerPrefs.GetInt("LevelNoDifficulty") >= 71 && PlayerPrefs.GetInt("LevelNoDifficulty") <= 80)
            {
                //------------21 / 30 arasý bölüm zorluk derecesi 3 --------------//
                for (int i = 0; i < StarList.Count; i++)
                {
                    StarList[i] = StarList[i] + 150;

                }
                for (int i = 0; i < ClueList.Count; i++)
                {
                    ClueList[i] = ClueList[i] + 150;
                }
              
                Debug.Log(Complete.Level);


            }
            zamanlayici = false;
            for (int i = 0; i < MapCameras.Count; i++)
            {
                MapCameras[i].SetActive(false);
            }

            for (int i = 0; i < Cameras.Count; i++)
            {
                Cameras[i].SetActive(false);
                Cameras[0].SetActive(true);
            }


           
            MapCameras[0].SetActive(true);
            MiniMap2.SetActive(false);
            MiniMap.SetActive(false);
            Canvas.SetActive(false);
            MiniMapCanvas.SetActive(true);
            SettingButton.SetActive(false);
            SettingButton2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Difficulty") == 3)
        {
            if (PlayerPrefs.GetInt("LevelNoDifficulty") >= 41 && PlayerPrefs.GetInt("LevelNoDifficulty") <= 50)
            {
                //------------1 / 10 arasý bölüm zorluk derecesi 3 --------------//
                for (int i = 0; i < StarList.Count; i++)
                {
                    StarList[i] = StarList[i] + 120;

                }
                for (int i = 0; i < ClueList.Count; i++)
                {
                    ClueList[i] = ClueList[i] + 120;
                }
                
                Debug.Log(Complete.Level);


            }

            if (PlayerPrefs.GetInt("LevelNoDifficulty") >= 61 && PlayerPrefs.GetInt("LevelNoDifficulty") <=70)
            {
                //------------11 / 20 arasý bölüm zorluk derecesi 3 --------------//
                for (int i = 0; i < StarList.Count; i++)
                {
                    StarList[i] = StarList[i] + 150;

                }
                for (int i = 0; i < ClueList.Count; i++)
                {
                    ClueList[i] = ClueList[i] + 150;
                }
               
                Debug.Log(Complete.Level);


            }

            if (PlayerPrefs.GetInt("LevelNoDifficulty") >= 81 && PlayerPrefs.GetInt("LevelNoDifficulty") <= 90)
            {
                //------------21 /30 arasý bölüm zorluk derecesi 3 --------------//
                for (int i = 0; i < StarList.Count; i++)
                {
                    StarList[i] = StarList[i] + 180;
                    Debug.Log(StarList[i]);
                }
                for (int i = 0; i < ClueList.Count; i++)
                {
                    ClueList[i] = ClueList[i] + 180;
                }
               
               


            }
            zamanlayici = false;
            for (int i = 0; i < MapCameras.Count; i++)
            {
                MapCameras[i].SetActive(false);
            }

            for (int i = 0; i < Cameras.Count; i++)
            {
                Cameras[i].SetActive(false);
            }
         
            Cameras[1].SetActive(true);
            MapCameras[0].SetActive(true);
            MiniMap2.SetActive(false);
            MiniMap.SetActive(false);
            Canvas.SetActive(false);
            MiniMapCanvas.SetActive(true);
            SettingButton.SetActive(false);
            SettingButton2.SetActive(true);


        }
    }

    //------------------------------------GoogleAdsÖdüllü------------------------------------------//

    void RequestOdulluReklam()
    {

#if UNITY_ANDROID
        Reklamid = "ca-app-pub-9344611202433050/6227317292";
#elif UNITY_IPHONE
                                Reklamid="Tanýmsýz Platform";
#else
                                Reklamid = "Tanýmsýz Platform";
#endif

        OdulluReklamim = new RewardedAd(Reklamid);

        OdulluReklamim.OnAdLoaded += yuklendimi;
        OdulluReklamim.OnAdFailedToLoad += yuklemedesorunvar;
        OdulluReklamim.OnAdOpening += acildi;
        OdulluReklamim.OnAdFailedToShow += acildimi;
        OdulluReklamim.OnUserEarnedReward += videoyuizlediOduluHaketti;

        OdulluReklamim.OnAdClosed += kapatildi;


        AdRequest request = new AdRequest.Builder().Build();
        OdulluReklamim.LoadAd(request);
    }
    public void yuklendimi(object sender, EventArgs args)
    {
      
        if (PlayerPrefs.GetInt("TotalClue") < 6)
        {
        
            AdsButton.SetActive(true);
         
          
        }
        if (PlayerPrefs.GetInt("TotalClue") >= 6)
        {

            AdsButton.SetActive(false);
        }
    }
    public void yuklemedesorunvar(object sender, AdErrorEventArgs args)
    {

        RequestOdulluReklam();

    }
    public void acildi(object sender, EventArgs args)
    {

        zamanlayici = false;
    }
    public void kapatildi(object sender, EventArgs args)
    {
     
        
        if (PlayerPrefs.GetInt("TotalClue") < 6)
        {

            AdsButton.SetActive(true);
          
        }
        if (PlayerPrefs.GetInt("TotalClue") >= 6)
        {
            MiniMapButton.GetComponent<Image>().raycastTarget = true;
            AdsButton.SetActive(false);
        }

    }
    public void acildimi(object sender, AdErrorEventArgs args)
    {
      
    }
    public void videoyuizlediOduluHaketti(object sender, Reward args)
    {
        zamanlayici = false;
        AdsCanvasPrize.SetActive(true);
        BonusSound.Play();   
        PlayerPrefs.SetInt("TotalClue", PlayerPrefs.GetInt("TotalClue") + 6);
        ClueText.text = (PlayerPrefs.GetInt("TotalClue").ToString() + "/" + TotalClueValue);
        MiniMapButton.GetComponent<Image>().raycastTarget = true; 

        if (PlayerPrefs.GetInt("TotalClue") < 6)
        {

            AdsButton.SetActive(true);
            RequestOdulluReklam();
        }
        if (PlayerPrefs.GetInt("TotalClue") >= 6)
        {
            MiniMapButton.GetComponent<Image>().raycastTarget = true;
            AdsButton.SetActive(false);
        }
    }

    public void Ads()
    {
        ClickSound.Play();
        if (OdulluReklamim.IsLoaded())
        {
            if (PlayerPrefs.GetInt("TotalClue") < 6)
            {

                AdsButton.SetActive(true);
            }
            if (PlayerPrefs.GetInt("TotalClue") >= 6)
            {

                AdsButton.SetActive(false);
            }
            OdulluReklamim.Show();
        }
    }


    //--------------------------------------------GoogleAdsIntersitial----------------------------------------------//
     void GameOverVideoAds()
    {
        if (InterVideoTransitionAds.IsLoaded())
        {
            InterVideoTransitionAds.Show();
        }
        else
        {
            RequestVideoTransition();
        }
    }
    void RequestVideoTransition()
    {
#if UNITY_ANDROID
        AdsVideoId = "ca-app-pub-9344611202433050/6313456515";
#elif UNITY_IPHONE
string AdsVideoId="";
#else
         AdsVideoId = "NULL";
#endif
        InterVideoTransitionAds = new InterstitialAd(AdsVideoId);

        InterVideoTransitionAds.OnAdLoaded += yuklendimiTransition;
        InterVideoTransitionAds.OnAdFailedToLoad += yuklemedesorunvarTransition;
        InterVideoTransitionAds.OnAdOpening += acildiTransition;
        InterVideoTransitionAds.OnAdClosed += kapatildiTransition;
        InterVideoTransitionAds.OnAdLeavingApplication += arkaplanaatildimiTransition;


        InterVideoTransitionAds = new InterstitialAd(AdsVideoId);
        AdRequest request = new AdRequest.Builder().Build();
        InterVideoTransitionAds.LoadAd(request);
    }

    public void yuklendimiTransition(object sender, EventArgs args)
    {



    }
    public void yuklemedesorunvarTransition(object sender, AdFailedToLoadEventArgs args)
    {

        RequestVideoTransition();

    }
    public void acildiTransition(object sender, EventArgs args)
    {


    }
    public void kapatildiTransition(object sender, EventArgs args)
    {

        RequestVideoTransition();
    }
    public void arkaplanaatildimiTransition(object sender, EventArgs args)
    {


    }


    public void SettingsQuit()
    {
        GameSound.GetComponent<AudioSource>().volume = SoundVolValue ;
        if (player.CountrIsActice==true)
        {
            zamanlayici = true;
        }
        else if (ToplamZaman>0)
        {
            zamanlayici = true;
        }
        else
        {
            zamanlayici= false;
        }
        ClickSound.Play();
       
        SettingCanvas.SetActive(false);
      
        Time.timeScale = 1;
    }

    public void NoAdsPanel()
    {
        zamanlayici = true;
       
        AdsCanvasPrize.SetActive(false);
    }

    public void AdsPanelPrize()
    {
        zamanlayici = true;
        AdsCanvasPrize.SetActive(false);
    }
}
