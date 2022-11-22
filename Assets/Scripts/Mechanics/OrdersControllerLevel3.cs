using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class OrdersControllerLevel3 : MonoBehaviour
{
    //绑定订单类
    public GameObject order;
    //同时最多存在的订单数
    private int OrdersMaxNum = 1;
    //当前订单数
    private int OrdersNum = 0;
    //timer list
    List<float> Timers = new List<float>();
    //订单list
    List<GameObject> orders = new List<GameObject>();
    //burger
    public GameObject[] burgers;
    //keyboard输入list
    List<KeyCode> keyboardNums = new List<KeyCode>();
    private float timer = 0f;
    // Start is called before the first frame update
    public static OrdersControllerLevel3 instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        for (int i = 0; i < OrdersMaxNum; i++)
        {
            GameObject newOb = GenerateOrder(i);
            orders.Add(newOb);
            Timers.Add((float)20.0);
        }
        
    }

    GameObject GenerateOrder(int num){
    /*
        用来随机生成订单
    */
        //创建一个订单instance
        GameObject ob = Instantiate(order);
        //绑定parent，parent为此controller所属的Orders
        ob.transform.SetParent(this.transform);
        //根据parent的position调整位置
        ob.transform.position = this.transform.position + getOrderPosition(num);

        //get ingredients

        return ob;
    }

    // Update is called once per frame
    [Obsolete]
    void Update()
    {

        
    }

    public void hideOrder(int index, int mode)
    {
        if (index < orders.Count)
        {
            GameObject currentOrder = orders[index];
            
            bool finished = false;
            
            if(mode==1){
                finished =  currentOrder.transform.GetChild(5).gameObject.GetComponent<MenuIngredientsController>().checkIngredients();
                if (!finished)
                {
                    return;
                }
            }
  
            
            if (Timers[index]>0 & finished & currentOrder.active)
            {
                TextMeshProUGUI reward = currentOrder.GetComponentsInChildren<TextMeshProUGUI>()[2];
                getPoints(Int32.Parse(reward.text));
            }
            currentOrder.SetActive(false);
            burgers[index].SetActive(false);
        }
        
    }


    void getPoints(int num)
    {
        CoinCounterScript.instance.ChangeAmount(num);
    }


    Vector3 getOrderPosition(int num) 
    {
        return new Vector3(-(float)1.5 + (float)num * (float)1 + (float) (num - 1.0) * (float)0.25, -(float)0.01, 0);
    }
    
    public void highlightOrder(int index) {
        GameObject currentOrder = orders[index];
        currentOrder.GetComponent<RawImage>().color = Color.red;
    }
    
    public void deHighlightOrder(int index) {
        GameObject currentOrder = orders[index];
        currentOrder.GetComponent<RawImage>().color = new Color32(233, 182, 91, 154);
    }
    
    public bool checkIfIngredientsCompleted(int index) {
        GameObject currentOrder = orders[index];
//        print(currentOrder.transform.GetChild(0));
//        print(currentOrder.transform.GetChild(0).gameObject.GetComponent<MenuIngredientsController>());
        return currentOrder.transform.GetChild(1).gameObject.GetComponent<MenuIngredientsController>().checkIngredients();
    }
    
    public void reduceIngredients(int index) {
        GameObject currentOrder = orders[index]; currentOrder.transform.GetChild(1).gameObject.GetComponent<MenuIngredientsController>().reduceIngredients();
    }
    

    

}
