using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//
public class menu_action : MonoBehaviour
{
    public GameObject ClickToStart_text;
    public GameObject Start_button;
    public GameObject Quit_button;
    public GameObject ClickToStart_button;
    public GameObject Guide1;
    public GameObject Guide2;
    public GameObject Title;
    public GameObject UIcanvas;

    public GameObject Dingdong;
    public GameObject Sound;

	public void clickStart()
    {
        Title.SetActive(false);
        Start_button.SetActive(false);
        Quit_button.SetActive(false);
        Guide1.SetActive(true);
        Debug.Log("start");
    }
    public void clickExit()
    {
        //Debug.Log("exit");
        Application.Quit();
    }

    public void click_ClickToStart()
    {
        Start_button.SetActive(true);
        Quit_button.SetActive(true);
        ClickToStart_button.SetActive(false);
        ClickToStart_text.SetActive(false);

    }

   
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NextPage()
    {
        Guide1.SetActive(false);
        Guide2.SetActive(true);


    }

    public void LastPage()
    {
        Guide1.SetActive(true);
        Guide2.SetActive(false);

    }

    public void CloseUI()
    {
        Sound.SetActive(true);
        UIcanvas.SetActive(false);
        Invoke("DingDong",90);
    }

    public void DingDong()
    {
        
        Dingdong.SetActive(true);
    }

    void Start()
    {
        //Debug.Log("load menu_action");
    }

    // Update is called once per frame
    void Update()
    {

    }
}