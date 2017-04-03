using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public float m_minDuration = 1;

    public IEnumerator LoadScene(string sceneName)
    {
                
        // Load loading screen
        yield return SceneManager.LoadSceneAsync("LoadingScene");

        // !!! unload old screen (automatic)

       
        float endTime = Time.time + m_minDuration;

        // Load level async
        yield return SceneManager.LoadSceneAsync(sceneName);

        Debug.Log(endTime);
        Debug.Log(Time.time);
        if (Time.time < endTime)
        {
            yield return new WaitForSeconds(endTime - Time.time);
        }


        // !!! unload loading screen
        SceneManager.UnloadSceneAsync("LoadingScene");

        
    }

    public void LoadSceneMethod(string sceneName)
    {
        StartCoroutine("LoadScene", sceneName);
    }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
