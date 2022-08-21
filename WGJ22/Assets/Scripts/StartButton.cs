using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    //public Button button;
    //public Sprite newSprite;

    public void StartGame(){
        SceneManager.LoadScene("Water");
        //button.image.sprite = newSprite;
    }
}
