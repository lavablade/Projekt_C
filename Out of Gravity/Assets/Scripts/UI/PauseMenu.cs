﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {
    public Canvas canvasPause;
    public GameObject button;
    public GameObject exitButton;
    private bool isPaused;
    // Use this for initialization
    void Start () {
        GoOnFunktions();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {


            if (isPaused)
            {
                GoOnFunktions();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
        canvasPause.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(button);
    }

    public void GoOnFunktions()
    {
        canvasPause.gameObject.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
