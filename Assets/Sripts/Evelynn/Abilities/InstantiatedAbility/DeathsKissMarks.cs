using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathsKissMarks : MonoBehaviour
{
    public List<GameObject> DeathKissList;

    public GameObject DeathKissParent;
    public float deathKissTimer;
    public bool deathKissMark;
    public int currentHp;
    public int takenDamage;

    // Start is called before the first frame update
    void Start()
    {
        //set the int equal to players current HP
        currentHp = GetComponentInParent<Enemy>().health;
    }

    // Update is called once per frame
    void Update()
    {
        markProcCheck();
        timer();
    }

    public void markProcCheck()
    {
        int previousHp = currentHp;
        for (int i = 0; i < DeathKissList.Count; i++)
        {
            currentHp = GetComponentInParent<Enemy>().health;
            if (previousHp > currentHp)
            {
                GetComponentInParent<Enemy>().health -= 30;
                previousHp = currentHp;
                if (DeathKissList.Count > 0)
                {
                    Destroy(DeathKissList[0]);
                    DeathKissList.RemoveAt(0);
                }
            }
        }
    }

    public void timer()
    {
        if (deathKissMark == true)
        {
            if (deathKissTimer > 0)
            {
                deathKissTimer -= Time.deltaTime;
                if (deathKissTimer <= 0)
                {
                    deathKissMark = false;
                    //deathKissTimer = 5;
                    Destroy(gameObject);
                }
               
            }
        }
    }
}