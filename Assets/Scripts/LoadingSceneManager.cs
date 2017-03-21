﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadingSceneManager : MonoBehaviour
{

	// Use this for initialization
	void Start () {
      DontDestroyOnLoad(gameObject);
	}
    public void LoadScene(string sceneName)
    {
        StartCoroutine("LoadSceneAsync",sceneName);
    }


   public float minLoadingSceneDuration = 6f;
    /*
     *
     * http://www.gamasutra.com/blogs/SarahHerzog/20151125/260053/Creating_an_Animating_Loading_Screen_in_Unity_5.php
     *
     */
    IEnumerator LoadSceneAsync(string sceneName)
    {

        // Load loading screen
        yield return SceneManager.LoadSceneAsync("LoadingScene");

        // !!! unload old screen (automatic)
        
        float endTime = Time.time + minLoadingSceneDuration;

        // Load level async
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        GameObject canvasReferance = GameObject.Find("RunnerGameCanvas");
        canvasReferance.GetComponent<Canvas>().targetDisplay = 10;

        if (Time.time < endTime) yield return new WaitForSeconds(endTime - Time.time);

        // !!! unload loading screen
        SceneManager.UnloadSceneAsync("LoadingScene");
        //LoadingSceneManager.UnloadLoadingScene();

        // canvasReferance.SetActive(true);
        canvasReferance.GetComponent<Canvas>().targetDisplay = 0;
    }
}
