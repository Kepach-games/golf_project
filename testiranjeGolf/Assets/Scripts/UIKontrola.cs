using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIKontrola : MonoBehaviour {

    public Button buttonX;

    public void Awake()
    {
        buttonX.onClick.AddListener(BtnXOnClick);
    }

    void BtnXOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
