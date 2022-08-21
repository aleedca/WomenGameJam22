using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Random = System.Random;

public class DuckScript : MonoBehaviour
{

    //public GameObject camera;
    public float Speed;
    public float movX;
    private float posX;
    private float posY;
    private float minX;
    private float minY;
    private float maxX;
    private float maxY;
    

    // Start is called before the first frame update
    void Start()
    {
        float maxX = Camera.main.GetComponent<Camera>().transform.localPosition.x;
        float minX = Camera.main.GetComponent<Camera>().transform.localPosition.x;
        changePos();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position.x < minX);
        if (transform.position.x < minX) changePos();
        else {transform.position = new Vector2(posX - (Speed * movX), posY); posX = posX - (Speed * movX);}
    }

    private void changePos(){
        maxX = Camera.main.GetComponent<Camera>().transform.localPosition.x + 10;
        minX = Camera.main.GetComponent<Camera>().transform.localPosition.x - 20;

        Random rd;
        rd = new Random();
        posX = maxX + (float)rd.Next(0, 20);;
        posY = (float)rd.Next(-2, 4);
        transform.position = new Vector2(posX, posY);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerMovement>())

            changePos();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
