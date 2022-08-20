using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BacteriasScript : MonoBehaviour
{
    private GameObject myplayerPrefab;
    private GameObject myplayer;
    private float movY = 0.1f;
    private float sign = 1;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        myplayer = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(this.transform.position.x - myplayer.transform.position.x) < 3) MoveTowardsPlayer();
        // Debug.Log(Math.Abs(this.transform.position.x - myplayer.transform.position.x));
        //MoveTowardsPlayer();
        else MoveUpAndDown();
    }

    void MoveTowardsPlayer(){
        transform.position = Vector3.Lerp(this.transform.position, myplayer.transform.position, 3f * Time.deltaTime);
    }

    void MoveUpAndDown(){
        if (this.transform.position.y + (movY * Speed) == 4 || this.transform.position.y + (movY * Speed) == -3.3f){
            sign = sign * -1;
        }
        transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (movY * Speed * sign), this.transform.position.z);
    }
}
