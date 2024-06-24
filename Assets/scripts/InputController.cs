using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class InputController : MonoBehaviour
{
    public GameObject mobileController;
    // Start is called before the first frame update
    void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            if (YandexGame.EnvironmentData.deviceType == "desktop")
            {
                Debug.Log("DESKTOPCONTROL");
                mobileController.SetActive(false);
                RCC_SceneManager.SetController(0);
            }

            if (YandexGame.EnvironmentData.deviceType == "mobile")
            {
                Debug.Log("MOBILECONTROL");
                mobileController.SetActive(true);
                RCC_SceneManager.SetController(1);
            }

        }
    }

    
}
