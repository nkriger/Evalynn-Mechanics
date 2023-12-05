using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HSpikeMovement : MonoBehaviour
{
    public float SpikeSpeed;
    public GameObject deathsKissMarks;
    public bool plantedMark;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * SpikeSpeed * Time.deltaTime);
        if (transform.position.z >= 10)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
         if (collision.gameObject.tag == "Enemy")
         {
            Debug.Log("Hit Enemy");
            if (plantedMark == false)
            {
                GameObject childObject = Instantiate(deathsKissMarks, collision.transform.position, Quaternion.identity, collision.transform);
                plantedMark = true;
            }
            
         }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Qrange")
        {
            gameObject.SetActive(false);
            Debug.Log("Out of range");
        }
    }
}
