using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {
    public bool pause;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject settingsButton;

	// Use this for initialization
	void Start () {
        pause = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onPause()
    {
        pause = !pause;
        if (!pause)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
            settingsButton.SetActive(true);
        }
        else if (pause)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
            settingsButton.SetActive(false);
        }
    }
}
