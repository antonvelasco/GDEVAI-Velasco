using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] carCameras;

    private float yaw;
    private float pitch;

    private Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switchCamera();
        if (gameObject.GetComponent<Camera>().enabled == true)
        {
            moveCamera();
            rotateCamera();
        }

    }

    void switchCamera()
    {
        if (Input.GetKeyDown("space"))
        {
            if (gameObject.GetComponent<Camera>().enabled == true)
            {
                gameObject.GetComponent<Camera>().enabled = false;
                foreach (GameObject camera in carCameras)
                {
                    camera.GetComponent<Camera>().enabled = true;
                }
            }
            else
            {
                gameObject.GetComponent<Camera>().enabled = true;
                foreach (GameObject camera in carCameras)
                {
                    camera.GetComponent<Camera>().enabled = false;
                }
            }
            print("space is pressed");

        }
    }

    void moveCamera()
    {
        float xAxisMove = 10.0f * Input.GetAxis("Horizontal");
        float zAxisMove = 10.0f * Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xAxisMove, 0.0f, zAxisMove));
    }

    void rotateCamera()
    {
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += 5.0f * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        }
    }   
}
