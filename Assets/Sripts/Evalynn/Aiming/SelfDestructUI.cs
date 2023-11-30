using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = transform.localScale * .87f;
        if (transform.localScale.x < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
