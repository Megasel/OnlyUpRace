using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using HomaGames.HomaBelly;
using YG;
using static RCC_Settings;
public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;
    public GameObject startpanel, gamePlaypanel, winpanel, losepanel,messagepanel,win,lose;
    public GameObject effect1, effect2,enemydieEffect,obstacleEffect,wineffect;
    public Text playerCounterGameplay, plauerCounterWin, newbestTxt, goalsizetxt;
    public GameObject[] LevelsContenu;
    public GameObject[] PlayersList;
    public Text playerNum, enemyNum;
    public GameObject enemVsPlayer;
    public int sizegoal;
    //public Transform[] checkpoints;
    //Yandex Save Variables
    public int count;
    public int coin;
    public int level;
    public int playerCounter;
    public int firstTime;
    public int pourcentage;
    public int activSkin;
    public int skin0;
    public int skin;
    public int main;
    public int skin1;
    public int skin2;
    public int skin3;
    public int skin4;
    public int skin5;
    public int skin6;
    public int skin7;
    public int skin8;
    public int skin9;
    public float checkpointPositionX;
    public float checkpointPositionY;
    public float checkpointPositionZ;
    public float checkpointRotationX;
    public float checkpointRotationY;
    public float checkpointRotationZ;
    void Awake()
    {
        instance = this;
        onstartfirsttime();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        if (YandexGame.SDKEnabled)
        {
            LoadYandexSaves();
        }
        instantiateLevel();
        Debug.Log("УРОВЕНЬ: " + YandexGame.savesData.level);
        //print(getLevel());
        //// game analytics
        //GmAnManager.instance.GA_game_start(getLevel() + 1);
        //// fb analytics
        //FbManager.instance.LogLevelStartedEvent(getLevel() + 1);
        ////homa games
        //HomaBelly.Instance.TrackProgressionEvent(ProgressionStatus.Start, "start level number " + (gamemanager.instance.getLevel() + 1));
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    resetall();
        //}
        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    setLevel(getLevel() + 1);
        //    if (LevelsContenu.Length <= getLevel())
        //        return;
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
    }
    public void LevelToLoad()
    {
        if (YandexGame.savesData.level != 0)
        {
            SceneManager.LoadScene(YandexGame.savesData.level);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void onstartfirsttime()
    {
        if (YandexGame.savesData.firstTime == 1)
        {
            //PlayerPrefs.SetInt("count", 1);
            YandexGame.savesData.count = 1;
            //PlayerPrefs.SetInt("coin", 0);
            YandexGame.savesData.coin = 0;
            //PlayerPrefs.SetInt("level", 0);
            //YandexGame.savesData.level = 0;
            //PlayerPrefs.SetInt("playerCounter", 0);
            YandexGame.savesData.playerCounter = 0;
            //PlayerPrefs.SetInt("firsttime", 0);
            YandexGame.savesData.firstTime = 0;
            //PlayerPrefs.SetInt("pourcentage", 0);
            YandexGame.savesData.pourcentage = 0;
            //PlayerPrefs.SetInt("activSkin", 0);
            YandexGame.savesData.activSkin = 0;
            //PlayerPrefs.SetInt("skin0", 1);
            YandexGame.savesData.skin0 = 1;
            for (int i = 1; i < 9; i++)
            {
                switch (i)
                {
                    case 0:
                        YandexGame.savesData.skin0 = 0;
                        break;
                    case 1:
                        YandexGame.savesData.skin1 = 0;
                        break;
                    case 2:
                        YandexGame.savesData.skin2 = 0;
                        break;
                    case 3:
                        YandexGame.savesData.skin3 = 0;
                        break;
                    case 4:
                        YandexGame.savesData.skin4 = 0;
                        break;
                    case 5:
                        YandexGame.savesData.skin5 = 0;
                        break;
                    case 6:
                        YandexGame.savesData.skin6 = 0;
                        break;
                    case 7:
                        YandexGame.savesData.skin7 = 0;
                        break;
                    case 8:
                        YandexGame.savesData.skin8 = 0;
                        break;
                }
               //PlayerPrefs.SetInt("skin" + i, 0);
            }
            YandexGame.SaveProgress();
        }
    }
    // count Active skin
    public int getcountActive()
    {
        //return PlayerPrefs.GetInt("count");
        return YandexGame.savesData.count;
    }
    public void setcountActive(int nbr)
    {
       // PlayerPrefs.SetInt("count", nbr);
        YandexGame.savesData.count = nbr;
        YandexGame.SaveProgress();
    }
    // player counter
    public int getplayerCounter()
    {
        //return PlayerPrefs.GetInt("playerCounter");
        return YandexGame.savesData.playerCounter;
    }
    public void setplayerCounter(int nbr)
    {
        //PlayerPrefs.SetInt("playerCounter", nbr);
        YandexGame.savesData.playerCounter = nbr;
        YandexGame.SaveProgress();
    }
    // coin
    public int getcoin()
    {
        //return PlayerPrefs.GetInt("coin");
        return YandexGame.savesData.coin;
    }
    public void setcoin(int nbr)
    {
        //PlayerPrefs.SetInt("coin", nbr);
        YandexGame.savesData.coin = nbr;
        YandexGame.SaveProgress();
    }
    // menu active
    public int getMenuActive()
    {
        //return PlayerPrefs.GetInt("menu");
        return YandexGame.savesData.menu;
    }
    public void setMenuActive(int nbr)
    {
        //PlayerPrefs.SetInt("menu", nbr);
        YandexGame.savesData.menu = nbr;
        YandexGame.SaveProgress();
    }
    //pourcentage get set
    public void setpourcentage(int pourcentage)
    {
        //PlayerPrefs.SetInt("pourcentage", pourcentage);
        YandexGame.savesData.pourcentage = pourcentage;
        YandexGame.SaveProgress();
    }
    public int getpourcentage()
    {
        //return PlayerPrefs.GetInt("pourcentage");
        return YandexGame.savesData.pourcentage;
    }
    //skin variables
    public void setskin(int numSkin, int active)
    {
        //PlayerPrefs.SetInt("skin" + numSkin, active);
        switch (numSkin)
        {
            case 0:
                YandexGame.savesData.skin0 = active;
                break;
            case 1:
                YandexGame.savesData.skin1 = active;
                break;
            case 2:
                YandexGame.savesData.skin2 = active;
                break;
            case 3:
                YandexGame.savesData.skin3 = active;
                break;
            case 4:
                YandexGame.savesData.skin4 = active;
                break;
            case 5:
                YandexGame.savesData.skin5 = active;
                break;
            case 6:
                YandexGame.savesData.skin6 = active;
                break;
            case 7:
                YandexGame.savesData.skin7 = active;
                break;
            case 8:
                YandexGame.savesData.skin8 = active;
                break;
        }
        YandexGame.SaveProgress();
    }
    public int getskin(int numSkin)
    {
        //return PlayerPrefs.GetInt("skin" + numSkin);
        switch (numSkin)
        {
            case 0:
                return YandexGame.savesData.skin0;
            case 1:
                return YandexGame.savesData.skin1;
            case 2:
                return YandexGame.savesData.skin2;
            case 3:
                return YandexGame.savesData.skin3;
            case 4:
                return YandexGame.savesData.skin4;
            case 5:
                return YandexGame.savesData.skin5;
            case 6:
                return YandexGame.savesData.skin6;
            case 7:
                return YandexGame.savesData.skin7;
            case 8:
                return YandexGame.savesData.skin8;
            default:
                return 0;
        }
    }
    // active skin
    public void setactivSkin(int activSkin)
    {
        //PlayerPrefs.SetInt("activSkin", activSkin);
        YandexGame.savesData.activSkin = activSkin;
        YandexGame.SaveProgress();
    }
    public int getactivSkin()
    {
        //return PlayerPrefs.GetInt("activSkin");
        return YandexGame.savesData.activSkin;
    }
    // level number
    public void setLevel(int nbr)
    {
        //PlayerPrefs.SetInt("level", nbr);
        YandexGame.savesData.level = nbr;
        YandexGame.SaveProgress();
    }
    public int getLevel()
    {
        //return PlayerPrefs.GetInt("level");
        return YandexGame.savesData.level;
    }
    // reset
    public void resetall()
    {
        //PlayerPrefs.SetInt("count", 1);
        count = 1;
        //PlayerPrefs.SetInt("coin", 0);
        coin = 0;
        //PlayerPrefs.DeleteKey("firsttime");
        pourcentage = 0;
        //PlayerPrefs.SetInt("pourcentage", 0);
        level = 0;
        //PlayerPrefs.SetInt("level", 0);
        skin0 = 1;
        //PlayerPrefs.SetInt("skin0", 1);
        activSkin = 0;
        //PlayerPrefs.SetInt("activSkin", 0);
        skin1 = 0;
        skin2 = 0;
        skin3 = 0;
        skin4 = 0;
        skin5 = 0;
        skin6 = 0;
        skin7 = 0;
        skin8 = 0;
        //for (int i = 1; i < 9; i++)
        //{
        //    PlayerPrefs.SetInt("skin" + i, 0);
        //}
        SaveYandexSaves();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //public void activetedSkin()
    //{
    //    Destroy(player);
    //    GameObject go = Instantiate(PlayersList[getactivSkin()], Origin_player_Position, Quaternion.identity) as GameObject;
    //    go.transform.localScale = origin_player_Scale;
    //    if (helmetln != null)
    //        helmetln.transform.SetParent(go.transform);
    //}
    public void instantiateLevel()
    {
        if (LevelsContenu.Length > getLevel())
            //Instantiate(LevelsContenu[getLevel()]);
            LevelsContenu[getLevel()].SetActive(true);
        print(LevelsContenu.Length);
        print(getLevel());
    }
    private void LoadYandexSaves()
    {
        count = YandexGame.savesData.count;
        coin = YandexGame.savesData.coin;
        level = YandexGame.savesData.level;
        playerCounter = YandexGame.savesData.playerCounter;
        firstTime = YandexGame.savesData.firstTime;
        pourcentage = YandexGame.savesData.pourcentage;
        activSkin = YandexGame.savesData.activSkin;
        skin0 = YandexGame.savesData.skin0;
        skin = YandexGame.savesData.skin;
        main = YandexGame.savesData.main;
        checkpointPositionX = YandexGame.savesData.checkpointPositionX;
        checkpointPositionY = YandexGame.savesData.checkpointPositionY;
        checkpointPositionZ = YandexGame.savesData.checkpointPositionZ;
        checkpointRotationX = YandexGame.savesData.checkpointRotationX;
        checkpointRotationY = YandexGame.savesData.checkpointRotationY;
        checkpointRotationZ = YandexGame.savesData.checkpointRotationZ;
    }
    private void SaveYandexSaves()
    {
        YandexGame.savesData.count = count;
        YandexGame.savesData.coin = coin;
        YandexGame.savesData.level = level;
        YandexGame.savesData.playerCounter = playerCounter;
        YandexGame.savesData.firstTime = firstTime;
        YandexGame.savesData.pourcentage = pourcentage;
        YandexGame.savesData.activSkin = activSkin;
        YandexGame.savesData.skin0 = skin0;
        YandexGame.savesData.skin = skin;
        YandexGame.savesData.main = main;
        YandexGame.savesData.checkpointPositionX = checkpointPositionX;
        YandexGame.savesData.checkpointPositionY = checkpointPositionY;
        YandexGame.savesData.checkpointPositionZ = checkpointPositionZ;
        YandexGame.savesData.checkpointRotationX = checkpointRotationX;
        YandexGame.savesData.checkpointRotationY = checkpointRotationY;
        YandexGame.savesData.checkpointRotationZ = checkpointRotationZ;
        YandexGame.SaveProgress();
    }
}
