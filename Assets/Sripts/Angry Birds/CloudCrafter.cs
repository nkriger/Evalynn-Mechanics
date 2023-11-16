using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{

    /// <summary>
    /// Will generate as many cloud prefabs as we want and move the scale accordingly
    /// </summary>
    /// 

    public int numClouds = 40;

    public GameObject[] cloudPrefabs;

    public Vector3 cloudPosMin, cloudPosMax;

    public float cloudScaleMin, cloudScaleMax;

    public float cloudSpeedMult = 0.5f;

    public GameObject[] cloudInstance;



    private void Awake()
    {
        cloudInstance = new GameObject[numClouds];

        GameObject anchor = GameObject.Find("cloudAnchor");

        GameObject cloud;

        for (int index = 0; index < numClouds; index++)
        {
            //pivk an int between 0 and numClouds
            int prefabNum = Random.Range(0, cloudPrefabs.Length);
            cloud = Instantiate(cloudPrefabs[prefabNum]);
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);

            //sclae
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

            cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);

            cPos.z = 100 - 90 * scaleU;

            cloud.transform.position = cPos;
            cloud.transform.localScale = Vector3.one * scaleVal;

            cloud.transform.parent = anchor.transform;

            cloud.transform.parent = anchor.transform;

            cloudInstance[index] = cloud;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject cloud in cloudPrefabs)
        {
            float scaleVal = cloud.transform.localScale.x;

            Vector3 cPos = cloud.transform.localPosition;

            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            if  (cPos.x <= cloudPosMax.x)
            {
                cPos.x = cloudPosMax.x;
            }

            cloud.transform.position = cPos;
        }
    }
}
