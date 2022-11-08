using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardCookingSpot : MonoBehaviour
{
    public static RewardCookingSpot Instance;
    public float timeRemaining;
    public bool BurgerorNot;

    public Transform[] Level2spaenpoints;
    public Transform[] Level3spaenpoints;

    public bool Level2orNot;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }


    public void changePos()
    {
        if(Level2orNot)
        {
            this.transform.position = Level2spaenpoints[Random.Range(0, Level2spaenpoints.Length)].position;

        }
        else
        {
            this.transform.position = Level3spaenpoints[Random.Range(0, Level2spaenpoints.Length)].position;

        }
    }
}
