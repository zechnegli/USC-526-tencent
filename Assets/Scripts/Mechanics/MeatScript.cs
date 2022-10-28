using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class MeatScript : MonoBehaviour
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
            float x_coordinate = Random.Range(-4.3f, 43f);
            float y_coordinate = 0f;
            if (x_coordinate < 18.62)
            {
                y_coordinate = Random.Range(-1.08f, 0.8f);
            }
            else if (x_coordinate < 23.11)
            {
                y_coordinate = Random.Range(0.83f, 2.86f);
            }
            else if (x_coordinate < 26.19)
            {
                y_coordinate = Random.Range(-1.15f, 2.86f);
            }
            else if (x_coordinate < 29.76)
            {
                y_coordinate = Random.Range(-2.33f, 2.86f);
            }
            else if (x_coordinate < 37.76)
            {
                y_coordinate = Random.Range(-1.13f, 2.86f);
            }
            else if (x_coordinate <= 43.78)
            {
                y_coordinate = Random.Range(-2.39f, -0.41f);
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