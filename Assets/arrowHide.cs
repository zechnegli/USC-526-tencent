using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class arrowHide : MonoBehaviour
{

    public static arrowHide instance;
    public int second = 5;
    public bool flag = false;
    private float nexttime = 1;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }

    }
    // hide the arrow instruction after 5 seconds
    public void hide(){
        flag = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(flag){
            if(Time.time >= nexttime){
                second--;
                nexttime = Time.time + 1;
                if(second <= 0){
                    this.gameObject.transform.localPosition = new Vector3(-1000,-800, 0);
                }
            }
        }

        
    }
}
