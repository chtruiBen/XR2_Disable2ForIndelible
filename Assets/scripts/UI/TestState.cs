using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class TestState : MonoBehaviour
{

    public List<GameObject> button_list;

    private Text myText;
    private string temp;
    private GameObject current_target = null;
    public static int current_target_state;


    // Start is called before the first frame update
    void Start()
    {
        current_target_state = 0;
        current_target = button_list[0];
    }

    
    public void ChangePage()
    {
        if (current_target_state != 3 && current_target_state != 4)
            return;
        current_target = button_list[current_target_state];
        ExecuteEvents.Execute(current_target, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);

        if (current_target_state == 3)
            current_target_state = 4;
        else if (current_target_state == 4)
            current_target_state = 3;

    }

    public void TrrigerOnClick()
    {
        if (current_target_state != 3 && current_target_state != 4)
            ExecuteEvents.Execute(current_target, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);

        if (current_target_state == 0)
            current_target_state = 2;

        if(current_target_state == 1)  
            current_target_state = 3;

        if(current_target_state == 4)
        {
            current_target_state = 5;
            current_target = button_list[current_target_state];
            ExecuteEvents.Execute(current_target, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);

        }


        //Debug.Log(current_target_state);


    }

    public void ChangeTarget(int togo)
    {
        if (togo == 1) //up
        {

            switch (current_target_state)
            {
                case 1: // target is Start

                    hideSelected(current_target_state);

                    current_target = button_list[2];
                    current_target_state = 2;

                    showSelected(current_target_state);

                    break;
                case 2: // target is Quit
                    hideSelected(current_target_state);

                    current_target = button_list[1];
                    current_target_state = 1;

                    showSelected(current_target_state);

                    break;
                default:
                    break;

            }
        }
        if(togo == 2) // down
        {

            switch (current_target_state)
            {
                case 1: // target is Start

                    hideSelected(current_target_state);

                    current_target = button_list[2];
                    current_target_state = 2;

                    showSelected(current_target_state);

                    break;
                case 2: // target is Quit

                    hideSelected(current_target_state);

                    current_target = button_list[1];
                    current_target_state = 1;

                    showSelected(current_target_state);

                    break;
                default:
                    break;

            }

        }



    }

    public void showSelected(int i)
    {
        myText = button_list[i].GetComponentInChildren<Text>();
        temp = "＞" + myText.text.Substring(1, 3);
        myText.text = temp;
    }

    public void hideSelected(int i)
    { 
        myText = button_list[i].GetComponentInChildren<Text>();
        temp = "　" + myText.text.Substring(1, 3);
        myText.text = temp;
    }

   
}
