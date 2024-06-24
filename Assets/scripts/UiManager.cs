using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public Text LevelText,secondmessage;
    public bool skinEnter;
    public GameObject ingamepanel;
    public GameObject playerSelectionPanel;
    public GameObject startpanel,gameplaypanel,losepanel,winpanel,confiti;

    public static bool checksky;

    public Material sky1, sky2;

    public static Vector3 v1, r1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        print(v1);
        //Advertisements.Instance.Initialize();
        //Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM);
        if(YandexGame.EnvironmentData.language == "ru")
        {
            LevelText.text = "Уровень " + (gamemanager.instance.getLevel() + 1);
        }
        else if (YandexGame.EnvironmentData.language == "en")
        {
            LevelText.text = "Level " + (gamemanager.instance.getLevel() + 1);
        }
        else if (YandexGame.EnvironmentData.language == "tr")
        {
            LevelText.text = "MÜKEMMEL " + (gamemanager.instance.getLevel() + 1);
        }
        
    }

    

    //public void skinmenu()
    //{
    //    // sound
    //    SoundManager.instance.Play("click");
    //    skinEnter = true;
    //    playerSelectionPanel.SetActive(true);
    //    ingamepanel.SetActive(false);
    //}

    public void btn_retry()
    {
        // sound
        //SoundManager.instance.Play("click");
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextlvl()
    {
        YandexGame.FullscreenShow();
        YandexGame.savesData.checkpointPositionX = 0;
        YandexGame.savesData.checkpointPositionY = 0;
        YandexGame.savesData.checkpointPositionZ = 0;
        YandexGame.savesData.checkpointRotationX = 0;
        YandexGame.savesData.checkpointRotationY = 0;
        YandexGame.savesData.checkpointRotationZ = 0;
        YandexGame.SaveProgress();
        v1 = new Vector3(0, 0, 0);
        r1 = new Vector3(0, 0, 0);
        if (gamemanager.instance.getLevel()+1>=10)
        {
            gamemanager.instance.setLevel(0);
        }
        else
        {
            gamemanager.instance.setLevel(gamemanager.instance.getLevel() + 1);
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void showrestart()
    {
       // YandexGame.FullscreenShow();
        //Advertisements.Instance.ShowInterstitial();
        gameplaypanel.SetActive(true);
    }

    public void continuegm()
    {
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }

    public void restartgm()
    {
        YandexGame.savesData.checkpointPositionX = 0;
        YandexGame.savesData.checkpointPositionY = 0;
        YandexGame.savesData.checkpointPositionZ = 0;
        YandexGame.savesData.checkpointRotationX = 0;
        YandexGame.savesData.checkpointRotationY = 0;
        YandexGame.savesData.checkpointRotationZ = 0;
        YandexGame.SaveProgress();
        v1 = new Vector3(0, 0, 0);
        r1 = new Vector3(0, 0, 0);
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void changecar()
    {
        v1 = new Vector3(0, 0, 0);
        r1 = new Vector3(0, 0, 0);
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(0);
    }
}
