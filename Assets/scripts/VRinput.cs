using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class VRinput : MonoBehaviour
{
    public SteamVR_Action_Boolean touchpad_up = null;
    public SteamVR_Action_Boolean touchpad_down = null;
    public SteamVR_Action_Boolean trigger_down = null;
    public SteamVR_Action_Boolean snap_turn_right = null;
    public SteamVR_Action_Boolean snap_turn_left = null;


    private SteamVR_Behaviour_Pose m_Pose = null;

    private TestState testState;
    private GameObject testState_Object;

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        testState_Object = GameObject.Find("State_Controller");
        testState = testState_Object.GetComponent<TestState>();
    }

    //private SteamVR_Behaviour_Boolean 
    void Update()
    {

        if (snap_turn_right.GetStateDown(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + " right ");

            testState.ChangePage();
        }

        if (snap_turn_left.GetStateDown(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + " left ");

            testState.ChangePage();
        }

        //touchpad up is been click
        if (touchpad_up.GetStateDown(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + "touchpad_up ");
            //change up
            testState.ChangeTarget(1); 

        } 
         
        //touchpad down is been click
        if(touchpad_down.GetStateDown(m_Pose.inputSource))
        {
            
            print(m_Pose.inputSource + "touchpad_down");
            //change down
            testState.ChangeTarget(2); 
            //print("current_target_state is " + current_target_state);
        }  

        //trigger is on click
        if(trigger_down.GetStateDown(m_Pose.inputSource)){
            print(m_Pose.inputSource + "Trigger Down");

            testState.TrrigerOnClick();


        }

        
    }

   
   
}
