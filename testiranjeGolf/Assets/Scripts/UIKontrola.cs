using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIKontrola : MonoBehaviour {

    [SerializeField]
    private Button buttonX;

    [SerializeField]
    private Canvas PauseMenu;

    public void Awake()
    {
        buttonX.onClick.AddListener(BtnXOnClick);
    }

    void BtnXOnClick()
    {
        if (PauseMenu.enabled == true)
            PauseMenu.enabled = false;
        else
            PauseMenu.enabled = true;
    }

}
