using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public GameObject Highlighted;
    public GameObject Player;
    public bool highlighted;

    public int health;

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


        }
    }

    public void lostHealth()
    {

    }
}
