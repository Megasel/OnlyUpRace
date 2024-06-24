using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class ResetYGSaves : MonoBehaviour
{
    int countPressings;
    public void ResetSaves() 
    {
        countPressings++;
        if (countPressings == 5)
        {
            YandexGame.ResetSaveProgress();
            countPressings = 0;
        }
    }
}
