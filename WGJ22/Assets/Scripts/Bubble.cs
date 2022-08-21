using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bubble : MonoBehaviour
{
    public Animator bubble;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        activarfade();
     //bubble.SetBool("activar", true);       
    }
    public void activarfade()
    {
        FindObjectOfType<LevelLoaderScript>().LoadNextLevel();
    }
}
