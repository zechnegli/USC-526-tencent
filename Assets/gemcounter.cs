using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemcounter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GenUpdate.instance.UpdateUI();
            Destroy(this.gameObject);

        }
    }
}
