using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class finishline : MonoBehaviour
{
    public bool onetm;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="car" && !onetm)
        {
            onetm = true;
            StartCoroutine(wingm());
        }
    }

    IEnumerator wingm()
    {
        UiManager.instance.confiti.transform.parent = transform.parent;
        UiManager.instance.confiti.transform.localPosition = new Vector3(0, 0, 0);
        UiManager.instance.confiti.SetActive(true);
        
        SoundManager.instance.Play("clap");
        SoundManager.instance.Play("win");
        yield return new WaitForSeconds(4f);
        YandexGame.FullscreenShow();
        //Advertisements.Instance.ShowInterstitial();
        yield return new WaitForSeconds(1f);
        UiManager.instance.winpanel.SetActive(true);
    }
}
