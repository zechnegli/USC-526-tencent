using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuIngredientsController : MonoBehaviour
{
    //绑定订单食材类
    public GameObject MenuIngredient;
    //食材 list
   
    public static MenuIngredientsController instance;
    public List<string> ingredientsImagesString = new List<string> {"images/lettuce","images/steak","images/breadSlice"};
    List<GameObject> ingredients = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateIngredients();
        randomResetIngredients();
        
    }

    public void GenerateIngredients(){
        for (int i = 0; i< ingredientsImagesString.Count; i++){
            //新建一个订单食材类
            GameObject ob = Instantiate(MenuIngredient);
            //绑定parent，parent为此controller所属的Menu
            ob.transform.SetParent(this.transform);

            //调整食材的位置
            ob.transform.position = this.transform.position+new Vector3(-(float)0.3+(float)i*(float)0.3,-(float)0.18,0);
            ob.transform.localScale = new Vector3((float)0.5,(float)0.5,0);

            Image icon = ob.transform.GetChild(0).GetComponent<Image>();
            Debug.Log(" this image is " + ingredientsImagesString[i]);
            Sprite s = Resources.Load<Sprite>(ingredientsImagesString[i]);
            icon.sprite = s;

            ingredients.Add(ob);
        }
        
    }

    public void randomResetIngredients()
    {
        int totalIngredients = 0;
        for (int i = 0; i < ingredients.Count; i++)
        {
            GameObject ob = ingredients[i];
            //随机食材需要的数量
            TextMeshProUGUI num = ob.GetComponentsInChildren<TextMeshProUGUI>()[0];
            int totalNumber = Random.Range(0, 3);
            num.text = totalNumber.ToString();
            totalIngredients += totalNumber;
            if (totalNumber == 0)
            {
                ob.SetActive(false);
            } else
            {
                ob.SetActive(true);
            }
            
        }    
        if (totalIngredients == 0) {
            randomResetIngredients();
        }
    }


    public bool checkIngredients(){
        int veges = ingredients[0] ? int.Parse(ingredients[0].GetComponentsInChildren<TextMeshProUGUI>()[0].text) : 0;
        int meats = ingredients[1] ? int.Parse(ingredients[1].GetComponentsInChildren<TextMeshProUGUI>()[0].text) : 0;
        int bread = ingredients[2] ? int.Parse(ingredients[2].GetComponentsInChildren<TextMeshProUGUI>()[0].text) : 0;
       // int t_veges = int.Parse(VegetableCounterScript.instance.text.text);
      //  int t_meats = int.Parse(MeatCounterScript.instance.text.text);
         int t_veges = int.Parse(lettuceCounterScript.instance.text.text);
        int t_meats = int.Parse(steakCounterScript.instance.text.text);
       // int t_bread = int.Parse(BreadCounterScript.instance.text.text);
       int t_bread = int.Parse(breadSliceCounterScript.instance.text.text);
        
        if((veges <= t_veges) & (meats <= t_meats) & (bread <= t_bread)){
          
            return true;
        }
        
        return false;
        
    }
    
    public void reduceIngredients() {
        int veges = ingredients[0] ? int.Parse(ingredients[0].GetComponentsInChildren<TextMeshProUGUI>()[0].text) : 0;
        int meats = ingredients[1] ? int.Parse(ingredients[1].GetComponentsInChildren<TextMeshProUGUI>()[0].text) : 0;
        int bread = ingredients[2] ? int.Parse(ingredients[2].GetComponentsInChildren<TextMeshProUGUI>()[0].text) : 0;
       // int t_veges = int.Parse(VegetableCounterScript.instance.text.text);
      //  int t_meats = int.Parse(MeatCounterScript.instance.text.text);
         int t_veges = int.Parse(lettuceCounterScript.instance.text.text);
        int t_meats = int.Parse(steakCounterScript.instance.text.text);
       // int t_bread = int.Parse(BreadCounterScript.instance.text.text);
       int t_bread = int.Parse(breadSliceCounterScript.instance.text.text);
       //  MeatCounterScript.instance.ChangeAmount(-meats);
          steakCounterScript.instance.ChangeAmount(-meats);
          //  BreadCounterScript.instance.ChangeAmount(-bread);
         //   VegetableCounterScript.instance.ChangeAmount(-veges);
         lettuceCounterScript.instance.ChangeAmount(-veges);
         breadSliceCounterScript.instance.ChangeAmount(-bread);
        
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
