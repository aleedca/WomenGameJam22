using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CometaScript : MonoBehaviour
{
    private float movY = 0.3f;
    private float movX = 0.3f;
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
            limitX1 = this.transform.position.x - 4f;
            limitX2 = this.transform.position.x;
            sign = -1;
        }
        else if (!LeftToRight && !isStatic){
            limitY1 = this.transform.position.y;
            limitY2 = 3- this.transform.position.y;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (LeftToRight) MoveLeftAndRight();
        else if (!LeftToRight && !isStatic) MoveUpAndDown();
        
    }

    void MoveUpAndDown(){
        if (this.transform.position.y + (movY * Speed) >= limitY2 || this.transform.position.y - (movY * Speed) <= limitY1){
            sign = sign * -1;
        }
        transform.position = new Vector2(this.transform.position.x, this.transform.position.y - (movY * Speed * sign));
    }

    void MoveLeftAndRight(){
        Debug.Log( this.transform.position.x + (movX * Speed) >=  limitX2);
        Debug.Log( this.transform.position.x - (movX * Speed) <=  limitX1);
        if (this.transform.position.x + (movX * Speed) >= limitX2 + 0.3f || this.transform.position.x - (movX * Speed) <= limitX1){
            sign = sign * -1;
        }
        transform.position = new Vector2(this.transform.position.x - (movX * Speed * sign), this.transform.position.y);
    }

}
