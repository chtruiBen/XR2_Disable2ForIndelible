using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hand : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;
    public GameObject player;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    private Interact m_CurrentInteractable = null;
    public List<Interact> m_ContactInteractable = new List<Interact>();
   
    private Vector3 oldposition;
   // private AudioSource dropsound;
 

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }
    
    void Start()
    {
        
        //dropsound = GetComponent<AudioSource>();
       // dropsound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
       
        // Down 
        if (m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            //print(m_Pose.inputSource + "Trigger Down");
            Pickup();
        }

        // Up
        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + "Trigger Up");
            //Drop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;
        Debug.Log("In");
        m_ContactInteractable.Add(other.gameObject.GetComponent<Interact>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;
         
        m_ContactInteractable.Remove(other.gameObject.GetComponent<Interact>());
    }

    public void Pickup()
    {
        // Get nearest
        m_CurrentInteractable = GetNearestInteractable();

        if (m_CurrentInteractable.m_ActiveHand)
        {
            m_CurrentInteractable.m_ActiveHand.Drop();
            return;
        }
        Debug.Log("XD");
      
        // Null check
        if (!m_CurrentInteractable)
            return;

        /* Already held, check
        if (m_CurrentInteractable.m_ActiveHand)
            m_CurrentInteractable.m_ActiveHand.Drop();
        */
        // Position
        m_CurrentInteractable.transform.position = transform.position;

        // Attach
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        // Set active hand
        m_CurrentInteractable.m_ActiveHand = this;
    }

    public void Drop()
    {
        // Null Check
        if (!m_CurrentInteractable)
            return;
        //dropsound.PlayDelayed(1);
        

        // Apply velocity
        Rigidbody target = m_CurrentInteractable.GetComponent<Rigidbody>();
        target.velocity = m_Pose.GetVelocity();
        target.angularVelocity = m_Pose.GetAngularVelocity();
        
        // Detach
        m_Joint.connectedBody = null;

        // Clear
        m_CurrentInteractable.m_ActiveHand = null;
        m_CurrentInteractable = null;
    }

    private Interact GetNearestInteractable()
    {
        Interact nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (Interact interaction in m_ContactInteractable)
        {
            Debug.Log(interaction.gameObject.name);
            distance = (interaction.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = interaction;
            }
        }

        return nearest;
    }
    

    

    
}
