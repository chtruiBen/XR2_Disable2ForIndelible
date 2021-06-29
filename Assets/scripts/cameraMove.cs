using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraMove : MonoBehaviour
{   
    public GameObject VRcamera;
    public GameObject Player;
    public GameObject number_1;
    public GameObject number_2;
    public GameObject number_3;
    public GameObject ArrivalSound;
    public float speed = 0.1f;

    private Vector3 Direction1;
    private Vector3 Direction2;
    private Vector3 Direction3;
    private int direction_state;
    private Vector3 cameraPosition;
    private Vector3 correctPosition;
    private bool show_3  = true;
    private bool show_2 = false;
    private bool show_1 = false;
    private float LoadTime;

    // Start is called before the first frame update
    void Start()
    {

        //cameraDirection = target1.transform.position - cameraPosition;
        Direction1 = new Vector3(0.0f, 0.0f, 2.0f);
        Direction2 = new Vector3(2.0f, 0.0f, 0.0f);
        Direction3 = new Vector3(0.0f, 0.0f, -2.0f);

        direction_state = 1;
        LoadTime = Time.time;
       
    }

    // Update is called once per frame
    void Update()
    {
        //Let PlayerController follow the camera's position

        cameraPosition = VRcamera.transform.position;
        correctPosition = new Vector3(cameraPosition.x, Player.transform.position.y, cameraPosition.z);
        Player.transform.position = correctPosition;
        

        if (Time.time - LoadTime >= 3)
        {
            if (show_3)
            {
                number_3.SetActive(false);
                number_2.SetActive(true);
                show_2 = true;
                show_3 = false;
            }
        }
        if (Time.time - LoadTime >= 4)
        {
            if (show_2)
            {
                number_2.SetActive(false);
                number_1.SetActive(true);
                show_2 = false;
                show_1 = true;

            }

        }

        // move
        if (Time.time - LoadTime >= 5)
        {
            if (show_1)
            {
                number_1.SetActive(false);
                show_1 = false;
            }
            if (direction_state == 1)
            {
                transform.Translate(Vector3.forward * speed * Direction1.z * Time.deltaTime);

                if (this.transform.position.z >= 1.96f)
                {
                    direction_state++;
                    Player.transform.Rotate(new Vector3(0f, 90f, 0f));
                }

            }
            else if (direction_state == 2)
            {
                transform.Translate(Vector3.right * speed * Direction2.x * Time.deltaTime);

                if (this.transform.position.x >= -291.59f)
                {
                    direction_state++;
                    Player.transform.Rotate(new Vector3(0f, 90f, 0f));
                }

            }
            else if (direction_state == 3)
            {

                transform.Translate(Vector3.forward * speed * Direction3.z * Time.deltaTime);

                if (this.transform.position.z <= -1.92)
                {
                    Debug.Log("我們到了");
                    ArrivalSound.SetActive(true);
                    speed = 0;
                    Invoke("changeScene", 3);
                }
            }
        }
        
        

    }

    private void changeScene()
    {
        SceneManager.LoadScene(2);

    }

}