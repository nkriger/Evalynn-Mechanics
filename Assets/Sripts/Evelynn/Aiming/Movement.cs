using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{

    [SerializeField] public GameObject Player;

    public Vector3 currentMoveTarget;
    [SerializeField] public GameObject moveTarget;
    [SerializeField] public Vector3 mousePos;
    [SerializeField] public Vector3 worldPosition;

    [SerializeField] public LayerMask layersToHit;

    [SerializeField]public List<Vector3> movePoints = new List<Vector3>();
    [SerializeField] public List<GameObject> moveTargetList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        currentMoveTarget = transform.position;

    }
    

    // Update is called once per frame
    void Update()
    {
        mouseTracking();
        SetLocation();
    }

    private void FixedUpdate()
    {
        //moveToTarget();

    }
    private void mouseTracking()
    {
        mousePos = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out RaycastHit hitData, 100, layersToHit))
        {
              mousePos = hitData.point;
        }

        transform.position = mousePos;
    }
    
    private void SetLocation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Destroy(moveTargetList[0]);
            movePoints.Clear();
            moveTargetList.Clear();
            Debug.Log("moveto point");
            
            Instantiate(moveTarget, mousePos, Quaternion.identity);
            movePoints.Add(mousePos);
            moveTargetList.Add(moveTarget);
            currentMoveTarget = movePoints[0];
            if (currentMoveTarget != null)
            {
                //Destroy(currentMoveTarget); // Destroy the existing object
            }
            //generate a list to ad
        }
    }
    public void MovePlayerToTarget(float duration)
    {
        StartCoroutine(MoveCoroutine(duration));
    }

    private IEnumerator MoveCoroutine(float duration)
    {
        Vector3 startPosition = Player.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            Player.transform.position = Vector3.Lerp(startPosition, currentMoveTarget, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Ensure the player reaches the exact target position
        Player.transform.position = currentMoveTarget;
    }

    
}
