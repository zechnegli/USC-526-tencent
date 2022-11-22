using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class level4MeatScript : MonoBehaviour
{
    public int meatNum = 1;
    public int vegNum = 1;
    public int breadNum = 1;
    //public Sprite[] sprites;
    //private int oldSprite;
    //private int newSprite;
    //private List<int> availableSprites = new List<int>();
    //public GameObject[] food;

    /*void Start() {
  oldSprite = 0;
  for (int i = 0; i < sprites.Length; i++) {
   availableSprites.Add(i);
  }
  GameObject gameObject = Instantiate(food[Random.Range(0, sprites.Length)]);
 }*/


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.name == "meat")
            {
                
                MeatCounterScript.instance.ChangeAmount(meatNum);
            }
            if (this.gameObject.name == "vegetable")
            {
                VegetableCounterScript.instance.ChangeAmount(meatNum);
            }
            if (this.gameObject.name == "bread")
            {
                BreadCounterScript.instance.ChangeAmount(meatNum);
            }
            float x_coordinate = Random.Range(26.37f, 53.96f);
            float y_coordinate = 0f;
            if (x_coordinate < 33.48)
            {
                y_coordinate = Random.Range(-1.1f, 1.47f);
            }
            else if (x_coordinate < 46.34)
            {
                y_coordinate = Random.Range(-2.24f, 1.58f);
            }
            else if (x_coordinate < 53.96)
            {
                y_coordinate = Random.Range(-4.63f, 1.54f);
            }
            
            this.gameObject.transform.localPosition = new Vector3(x_coordinate, y_coordinate, 0);
            //GameObject.Find("RandomHandler").GetComponent<RandomHandler>().SpawnNewMaterial();
        }
        /*availableSprites.Remove(oldSprite);
  newSprite = availableSprites[Random.Range(0,availableSprites.Count)];
  GetComponent<SpriteRenderer>().sprite = sprites[newSprite];
  
  availableSprites.Add(oldSprite);
  oldSprite = newSprite;*/
    }


}