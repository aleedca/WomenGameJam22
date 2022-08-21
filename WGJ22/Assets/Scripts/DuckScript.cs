using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        // float vertExtent = Camera.main.GetComponent<Camera>().transform.localPosition.x;
        // float horzExtent = vertExtent * Screen.width / Screen.height;
        // float mapX = 100.0f;
        // float mapY = 100.0f;
 
        // // Calculations assume map is position at the origin
        // minX = horzExtent - mapX / 2.0f;
        // maxX = mapX / 2.0f - horzExtent;
        // minY = vertExtent - mapY / 2.0f;
        // maxY = mapY / 2.0f - vertExtent;
        // Debug.Log(minX);
        // Debug.Log(minY);
        // Debug.Log(maxX);
        // Debug.Log(maxY);

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
        minX = Camera.main.GetComponent<Camera>().transform.localPosition.x - 10;

        Random rd;
        rd = new Random();
        posX = maxX;
        posY = (float)rd.Next(-2, 4);
        transform.position = new Vector2(posX, posY);
    }
}
