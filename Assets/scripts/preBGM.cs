using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class preBGM : MonoBehaviour
{
    private float timer;
    private float timer2;
    public AudioClip m_AudioClip;
    public GameObject BGM;
    // Start is called before the first frame update
    void Start()
    {
        timer = m_AudioClip.length;
        timer2 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer+timer2)
        {
            BGM.SetActive(true);
            
            Destroy(this);

        }
    }
}
