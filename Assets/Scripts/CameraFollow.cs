using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    [SerializeField]
    Transform target;

    [SerializeField]
    float zoomSpeed = 1f;
    [SerializeField]
    float cameraDistance = 6;
    [SerializeField]
    float tmpPos;
    [SerializeField] float smoothSpeed;
    [SerializeField] float cameraDisMax = 10f;
    [SerializeField] float cameraDisMin = 2f;

    // Use this for initialization
    void Start()
    {
        cameraDistance = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x - transform.position.x >= 3 && target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(target.position.x, -target.position.y, 0), 0.5f) + new Vector3(-3, 0, -10);
        }
        else if (target.transform.position.x - transform.position.x <= -3 && target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(target.position.x , -target.position.y, 0), 0.5f) + new Vector3(3, 0, -10);

        }
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, cameraDistance, smoothSpeed * Time.deltaTime);
        //tmpCamPos = transform.position.x;
        //tmpPlayPos = target.transform.position.x;
        tmpPos = Mathf.Abs(target.transform.position.x - transform.position.x);
    }
}


