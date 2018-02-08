using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 7;

    [SerializeField]
    int isJumping = 0;

    Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        gameObject.transform.position = new Vector3(-6, 3, -2.0f);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = 20;
        }

    }
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (isJumping < 5)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 6.7f * speed, 0), 0);
                //transform.position += ;
                //gameObject.GetComponent<Rigidbody>().isKinematic = true;
                //gameObject.GetComponent<Rigidbody>().isKinematic = false;
                isJumping++;
            }

        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;


    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "mapFloor")
        {

            isJumping = 0;
        }
    }
}
