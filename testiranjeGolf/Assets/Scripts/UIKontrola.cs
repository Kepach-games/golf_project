using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIKontrola : MonoBehaviour {

    [SerializeField]
    private Button ButtonX;
    [SerializeField]
    private Button ButtonPlay;
    [SerializeField]
    private Button ButtonExit;
    [SerializeField]
    private Canvas PauseMenu;

    public void Awake()
    {
        ButtonX.onClick.AddListener(PauseToggle);
    }

    void PauseToggle()
    {
        if (PauseMenu.gameObject.activeSelf == true) //Izlazak iz pauze
        {
            ButtonX.gameObject.SetActive(true);
            PauseMenu.gameObject.SetActive(false);
            ButtonPlay.onClick.RemoveAllListeners();
            ButtonExit.onClick.RemoveAllListeners();
        }
        else //Ulazak u pauzu
        {
            ButtonX.gameObject.SetActive(false);
            PauseMenu.gameObject.SetActive(true);
            ButtonPlay.onClick.AddListener(PauseToggle);
            ButtonExit.onClick.AddListener(BtnExtitOnClick);
        }
    }

    private void BtnExtitOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
