using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Highlighted;
    public GameObject Player;

    private void OnMouseEnter()
    {
        Debug.Log("mouse enter");
        Highlighted.SetActive(true);
    }

    private void OnMouseExit()
    {
        Debug.Log("mouse exit");
        Highlighted.SetActive(false);
    }
}
