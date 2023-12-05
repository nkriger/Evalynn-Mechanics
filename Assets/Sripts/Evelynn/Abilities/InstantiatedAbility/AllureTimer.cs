using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllureTimer : MonoBehaviour
{
    public Image Allure;

    public bool AllureReady;

    public float AllureTime;


    private void Update()
    {
        if (AllureReady == false)
        {
            Allure.fillAmount += 1 / AllureTime * Time.deltaTime;

            if (Allure.fillAmount >= 1)
            {
                Allure.fillAmount = 1;
                AllureReady = true;
            }
        }
    }

}
