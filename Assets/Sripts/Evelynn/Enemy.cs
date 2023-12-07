using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public GameObject Highlighted;
    public GameObject Player;
    public bool highlighted;
    public int speed;
    public int maxHealth;
    public int health;
    public float percentHealth;
    public float charmTimer = 2.5f;
    public GameObject slider;

    public bool isCharmed;

    public GameObject CharmedTarget;

    private void Start()
    {
        health = maxHealth;
        
    }
    private void Update()
    {

        percentHealth = (health / maxHealth) * 100;
        slider.GetComponent<Slider>().value = percentHealth;

        if (isCharmed == true)
        {
            CharmedTarget = Player;
            transform.position = Vector3.MoveTowards(transform.position, CharmedTarget.transform.position, speed * Time.deltaTime);
        }
        
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Enemy found!");
            return;
        }
        instance = this;
    }
    private void OnMouseEnter()
    {
        if (highlighted == false)
        {
            highlighted = true;
            highlight();
        }
        else
        {

        }
    }
    private void OnMouseExit()
    {
        if (highlighted == true)
        {
            highlighted = false;
            highlight();
        }
        else
        {
            
        }
    }
    

    void highlight()
    {
        if (highlighted == true)
        {
            Highlighted.SetActive(true);
        }
        else
        {
            Highlighted.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Charmed();

        }
    }

    public void Charmed()
    {
        isCharmed = true;
        //max verstapin this code like he did for lewis hamilton in the 2021 spanish grand prix
        if (isCharmed == true)
        {
            charmTimer = 2.5f;
            if (charmTimer > 0)
            {
                charmTimer -= 1 / Time.deltaTime;
            }
        }
    }
}
