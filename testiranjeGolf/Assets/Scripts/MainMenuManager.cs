using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public Button buttonPlay;
    public Button buttonExit;

    private void Awake()
    {
        //Prave se listeneri koji cekaju klik
        buttonPlay.onClick.AddListener(OnButtonPlayClick);
        buttonExit.onClick.AddListener(OnButtonExitClick);
    }

    private void OnButtonPlayClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnButtonExitClick()
    {
        Application.Quit();
    }
}
