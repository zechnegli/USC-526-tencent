using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMonsterHint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            KillText.instance.show("Kill monsters by stepping on it and get rewards ", 4);
        }
          
            
    }
}
