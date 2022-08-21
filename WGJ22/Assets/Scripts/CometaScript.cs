using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CometaScript : MonoBehaviour
{
    private float movY = 0.1f;
    private float movX = 0.1f;
    private float sign = 1;
    private float limitX1;
    private float limitX2;
    private float limitY1;
    private float limitY2;
    private float posX;
    private float posY;
    public bool LeftToRight;
    public bool isStatic;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        if (LeftToRight) {
            limitX1 = this.transform.position.x - 10f;
            limitX2 = this.transform.position.x;
        }
        else if (!LeftToRight && !isStatic){
            limitY1 = this.transform.position.y;
            limitY2 = 4- this.transform.position.y;
        }

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(LeftToRight);
        Debug.Log(isStatic);

        if (LeftToRight) MoveLeftAndRight();
        else if (!LeftToRight && !isStatic) MoveUpAndDown();
        
    }

    void MoveUpAndDown(){
        if (this.transform.position.y + (movY * Speed) >= limitY2 || this.transform.position.y - (movY * Speed) <= limitY1){
            sign = sign * -1;
        }
        transform.position = new Vector2(this.transform.position.x, this.transform.position.y + (movY * Speed * sign));
    }

    void MoveLeftAndRight(){
        if (Math.Abs(this.transform.position.x + (movX * Speed)) >= Math.Abs(limitX2) || Math.Abs(this.transform.position.x - (movX * Speed)) <= Math.Abs(limitX1)){
            sign = sign * -1;
        }
        transform.position = new Vector2(this.transform.position.x + (movX * Speed * sign), this.transform.position.y);
    }

}
