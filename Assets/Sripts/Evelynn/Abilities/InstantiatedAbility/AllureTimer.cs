using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllureTimer : MonoBehaviour
{
    public Image Allure;
    public Image AllureProcH;

    public Allure allure;
    public GameObject Evalyn;

    public bool AllureActive;
    public bool AllureReady;
    bool AllureCharmed = false;


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

        AllureProc();
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
                if (!AllureCharmed)
                {
                    GetComponentInParent<Enemy>().health -= allure.damage;
                    AllureCharmed = true;
                    AllureProcH.fillAmount = 1;
                    GetComponentInParent<Enemy>().CharmedTarget = Evalyn.gameObject;
                    GetComponentInParent<Enemy>().Charmed();
                    
                }
            }
        }
        if (AllureProcH.fillAmount == 1)
        {
            StartCoroutine(AllureProcHTimer());
        }
    }

    IEnumerator AllureProcHTimer()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
