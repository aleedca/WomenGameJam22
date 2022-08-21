using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float transitionTime = 5f;


    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        int newIndex = (SceneManager.GetActiveScene().buildIndex + 1)%7;
        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        GetComponent<LevelLoaderScript>().LoadNextLevel();
    }
}
