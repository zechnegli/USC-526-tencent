using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableScript : MonoBehaviour
{
   public int VegetableNum = 1;
   private void OnTriggerEnter2D(Collider2D other)
   {
		if(other.gameObject.CompareTag("Player")){
			VegetableCounterScript.instance.ChangeAmount(VegetableNum);
			Destroy(gameObject);
		}
   }
}
