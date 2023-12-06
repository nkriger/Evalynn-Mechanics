using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllureTimer : MonoBehaviour
{
    public Image Allure;
    public Image AllureProcH;

    public GameObject Evalyn;

    public bool AllureActive;
    public bool AllureReady;

    public float AllureTime;

    public int currentHp;

    public void Start()
    {
        currentHp = GetComponentInParent<Enemy>().health;
    }

    private void Update()
    {
        if (AllureActive == true)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("abilityDamage"))
        {
            if (AllureReady == false)
            {
                Allure.fillAmount = 0;
                
            }
        }
        
    }
    private void AllureProc()
    {
        int previousHp = currentHp;
       
        
        currentHp = GetComponentInParent<Enemy>().health;
        if (previousHp > currentHp)
        {
            
            if (!AllureReady)
            {
                GetComponentInParent<Enemy>().speed = GetComponentInParent<Enemy>().speed - 5;
                Destroy(gameObject);
                previousHp = currentHp;
            }
            else
            {
                GetComponentInParent<Enemy>().health = GetComponentInParent<Enemy>().health - 140;
                AllureProcH.fillAmount = 1;
                GetComponentInParent<Enemy>().CharmedTarget = Evalyn;
                
            }
        }
       
    }
}
