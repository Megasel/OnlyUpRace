using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class checkpointsv : MonoBehaviour
{
    public Vector3 v;
    [SerializeField] private GameObject gameManager;
    gamemanager gm;
    [SerializeField] private GameObject pin;
    // Start is called before the first frame update
    private void Awake()
    {
        gm = gameManager.GetComponent<gamemanager>();
    }
    void Start()
    {
        v = transform.rotation.eulerAngles;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="car")
        {
            YandexGame.savesData.checkpointPositionX = transform.position.x;
            YandexGame.savesData.checkpointPositionY = transform.position.y;
            YandexGame.savesData.checkpointPositionZ = transform.position.z;
            YandexGame.savesData.checkpointRotationX = transform.rotation.eulerAngles.x;
            YandexGame.savesData.checkpointRotationY = transform.rotation.eulerAngles.y;
            YandexGame.savesData.checkpointRotationZ = transform.rotation.eulerAngles.z;
            Debug.Log("CHECKPOINT SAVED");
            YandexGame.SaveProgress();
            SoundManager.instance.Play("hit");
            UiManager.v1 = transform.position;
            UiManager.v1.y = transform.position.y + 2;
            UiManager.r1 = transform.rotation.eulerAngles;
            gameObject.SetActive(false);
        }
       
    }
}
