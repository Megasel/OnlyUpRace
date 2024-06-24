using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class losezone : MonoBehaviour
{
    public bool onetm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "car" && !onetm)
        {
            onetm = true;
            StartCoroutine(losegm());
        }
    }

    IEnumerator losegm()
    {
        FindObjectOfType<RCC_CarControllerV3>().gameObject.GetComponent<RCC_CarControllerV3>().SetEngine(false);
        SoundManager.instance.Play("fail");
        //YandexGame.FullscreenShow();
        //Advertisements.Instance.ShowInterstitial();
        yield return new WaitForSeconds(1f);
        UiManager.instance.losepanel.SetActive(true);
    }
}
