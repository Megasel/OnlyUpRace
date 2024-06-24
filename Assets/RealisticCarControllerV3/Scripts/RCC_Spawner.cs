//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2014 - 2020 BoneCracker Games
// http://www.bonecrackergames.com
// Buğra Özdoğanlar
//
//----------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class RCC_Spawner : MonoBehaviour {
    [SerializeField] private GameObject gameManager;
    gamemanager gm;
    // Start is called before the first frame update
    private void Awake()
    {
        gm = gameManager.GetComponent<gamemanager>();
    }

    // Use this for initialization
    void Start () {

		int selectedIndex = PlayerPrefs.GetInt ("SelectedRCCVehicle", 0);
        Debug.Log("ROTATION: " + YandexGame.savesData.checkpointRotationX + ", " + YandexGame.savesData.checkpointRotationY + ", " + YandexGame.savesData.checkpointRotationZ);
		RCC.SpawnRCC (RCC_DemoVehicles.Instance.vehicles [selectedIndex], new Vector3(YandexGame.savesData.checkpointPositionX, YandexGame.savesData.checkpointPositionY, YandexGame.savesData.checkpointPositionZ), Quaternion.Euler(YandexGame.savesData.checkpointRotationX, YandexGame.savesData.checkpointRotationY, YandexGame.savesData.checkpointRotationZ), true, true, true);
		
	}

}
