using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{   
    public GameObject VRcamera;
    public GameObject target;
    public float speed = 0.1f;
    private Vector3 cameraPosition;
    private Vector3 cameraDirection;

    // Start is called before the first frame update
    void Start()
    {
       
        cameraPosition = VRcamera.transform.position;
        cameraDirection = target.transform.position - cameraPosition;
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * speed  * cameraDirection.z * Time.deltaTime);
        transform.Translate(Vector3.right * speed * cameraDirection.x * Time.deltaTime);

        /*cameraPosition.x += cameraDirection.x * speed * Time.deltaTime * 0.1f;
        cameraPosition.z += cameraDirection.z * speed * Time.deltaTime * 0.1f;
        transform.Translate(cameraDirection * Time.deltaTime * Input.GetAxis("Vertical"), Space.Self);
        */
        //this.transform.position = cameraPosition ;
        //Debug.Log

    }
}