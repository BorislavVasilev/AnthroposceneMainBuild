using UnityEngine;
using System.Collections;

public class TimeDestroyer : MonoBehaviour
{
    bool destroying = false;

    // Use this for initialization
    void Update()
    {
        if(GameManager.Instance.GameState == GameState.Playing && destroying == false)
        {
            Invoke("DestroyObject", LifeTime);
            destroying = true;
        }
        
    }


    void DestroyObject()
    {
        if (GameManager.Instance.GameState != GameState.Dead)
            Destroy(gameObject);
    }


    public float LifeTime = 10f;
}
