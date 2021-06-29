using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixWheelChair : MonoBehaviour
{
    public GameObject Camera;
    private Vector3 cameraPosition;
    private Vector3 correctPosition;
    // Start is called before the first frame update
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < 1)
        {
            cameraPosition = Camera.transform.position;
            correctPosition = new Vector3(cameraPosition.x, this.transform.position.y, cameraPosition.z);
            this.transform.position = correctPosition;
            this.transform.position = correctPosition;
        }
    }
}
