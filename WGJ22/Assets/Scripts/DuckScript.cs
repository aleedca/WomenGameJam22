using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour
{

    //public GameObject camera;
    public float Speed;
    public float movY;
    private float posX;
    private float posY;
    private float minX;
    private float minY;
    private float maxX;
    private float maxY;

    // Start is called before the first frame update
    void Start()
    {
        var vertExtent = Camera.main.camera.orthographicSize;    
        var horzExtent = vertExtent * Screen.width / Screen.height;
 
        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0;
        maxX = mapX / 2.0 - horzExtent;
        minY = vertExtent - mapY / 2.0;
        maxY = mapY / 2.0 - vertExtent;

        changePos();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minX) changePos;
        else transform.position = new Vector2(posX + (Speed * movX), posY);
    }

    private void changePos(){
        Random rd = new Random();
        posX = maxX + 10;
        posY = rd.Next(minY, maxY);
    }
}
