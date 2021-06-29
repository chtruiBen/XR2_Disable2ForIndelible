using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UIStart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private UnityEvent onStart;
    void Start()
    {
        this.onStart.Invoke();
    }

    
}
