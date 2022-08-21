using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BacteriasScript : MonoBehaviour
{
    private GameObject myplayerPrefab;
    private GameObject myplayer;
    private float movY = 0.1f;
    private float movX = 0.1f;
    private float sign = 1;
    private float limitX1;
    private float limitX2;
    public bool LeftToRight;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        myplayer = GameObject.FindWithTag("Player");
        //limitX1 = Input.GetAxisRaw("Horizontal") - 2f;
        //limitX2 = Input.GetAxisRaw("Horizontal") + 2f;

        limitX1 = this.transform.position.x - 2f;
        limitX2 = this.transform.position.x + 2f;

        // Random rd = new Random();
        // LeftToRight = (rd.Next(0, 100) % 2 == 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(this.transform.position.x - myplayer.transform.position.x) < 3) MoveTowardsPlayer();
        // Debug.Log(Math.Abs(this.transform.position.x - myplayer.transform.position.x));
        //MoveTowardsPlayer();
        else {
            if (LeftToRight) MoveLeftAndRight();
            else MoveUpAndDown();
        }
    }

    void MoveTowardsPlayer(){
        transform.position = Vector3.Lerp(this.transform.position, myplayer.transform.position, 1f * Time.deltaTime);
    }

    void MoveUpAndDown(){
        if (this.transform.position.y + (movY * Speed) >= 4 || this.transform.position.y + (movY * Speed) <= -3.3f){
            sign = sign * -1;
        }
        transform.position = new Vector2(this.transform.position.x, this.transform.position.y + (movY * Speed * sign));
    }

    void MoveLeftAndRight(){
        if (Math.Abs(this.transform.position.x + (movX * Speed)) >= Math.Abs(limitX2) || Math.Abs(this.transform.position.x + (movX * Speed)) <= Math.Abs(limitX1)){
            sign = sign * -1;
        }
        transform.position = new Vector2(this.transform.position.x + (movX * Speed * sign), this.transform.position.y);
    }
}
