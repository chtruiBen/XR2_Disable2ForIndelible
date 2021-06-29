using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip Bush;
    public AudioClip chair;
    public AudioClip EmptyBox;
    public AudioClip IronStuff;
    public AudioClip PlasticBag;
    public AudioClip StreetLamp;
    AudioSource audioSource;

    private bool isPlay;
    private float timer;

    private float Playtime;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = 1.0f;
        isPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - Playtime >= timer)
            isPlay = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);


        if (collision.gameObject.tag == "Bush")
            audioSource.PlayOneShot(Bush, 0.7F);

        else if (collision.gameObject.tag == "chair")
            audioSource.PlayOneShot(chair, 0.7F);

        else if (collision.gameObject.tag == "EmptyBox")
            audioSource.PlayOneShot(EmptyBox, 0.7F);

        else if (collision.gameObject.tag == "IronStuff"){
            if(isPlay == false){
                audioSource.PlayOneShot(IronStuff, 0.3F);
                Playtime = Time.time;
                isPlay = true;
            }
        }
        else if (collision.gameObject.tag == " PlasticBag")
            audioSource.PlayOneShot(PlasticBag, 0.7F);

        else if (collision.gameObject.tag == "StreetLam")
            audioSource.PlayOneShot(StreetLamp, 0.7F);
    }
}