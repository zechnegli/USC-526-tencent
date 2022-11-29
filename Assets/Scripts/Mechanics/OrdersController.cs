using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class OrdersController : MonoBehaviour
{
    //绑定订单类
    public GameObject order;
    //同时最多存在的订单数
    private int OrdersMaxNum = 3;
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
    public static OrdersController instance;
    int ingredient = 1;
    int progressBar = 0;
    float time = (float) 45.0;
    public int highlightOrderIndex = -1;
    public bool[] finished = new bool[3];
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
            Timers.Add((float)time);
        }
        keyboardNums.Add(KeyCode.Alpha1);
        keyboardNums.Add(KeyCode.Alpha2);
        keyboardNums.Add(KeyCode.Alpha3);
        for(int i = 0; i < 3; i++){
            finished[i] = false;
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
        ob.GetComponentsInChildren<ProgressBar>()[progressBar].displayProgressBar();
//        //生成订单编号
//        TextMeshProUGUI number = ob.GetComponentsInChildren<TextMeshProUGUI>()[0];
//        number.text = (num + 1).ToString();

        //get ingredients

        return ob;
    }
    float elapsed = 0f;
    // Update is called once per frame
    [Obsolete]
    void Update()
    {
        for( int i = 0; i < orders.Count; i++){
            if(finished[i]){
                hideOrder(i,0);
            }
        }
        
        elapsed += Time.deltaTime;
        //check timers
        for (int i = 0; i < orders.Count; i++){
        
            if(Timers[i] > 0){
                float previous = Timers[i];
                Timers[i] -= Time.deltaTime;
//                orders[i].GetComponentsInChildren<TextMeshProUGUI>()[0].text = ((int)Timers[i]).ToString();         
            }else if(Timers[i] != -(float)1){
                hideOrder(i, 0);
                Timers[i] = -(float)1;
            }
          
        }
        //progress bar
        if (elapsed >= 1f) {
            for (int i = 0; i < orders.Count; i++){
            
                GameObject currentOrder = orders[i];
                if (currentOrder.active )
                {
                    
                    orders[i].GetComponentsInChildren<ProgressBar>()[progressBar].incrementProgress(((float) 1) / time);
                }
                 
            }
            elapsed = elapsed % 1f;
           
        }          

        
    
        //select order to fulfill
//        for (int i = 0; i < keyboardNums.Count; i++)
//        {
//            if (Input.GetKeyDown(keyboardNums[i])) {
//                hideOrder(i, 1);           
//            }
//        }

        //show a new order after one second 
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                GameObject currentOrder = orders[i];
              //  if (!currentOrder.active)
              if (!currentOrder.active && !finished[i])
                {
                    displayNewOrder(i);
                    orders[i].GetComponentsInChildren<ProgressBar>()[progressBar].resetSlider();  
                }
                 
            }
            timer = 0f;
            elapsed = 0f;
        }
        if (highlightOrderIndex != -1) {
            highlightOrder(highlightOrderIndex);
        } 
        
    }

    public void hideOrder(int index, int mode)
    {
        if (index < orders.Count)
        {
            GameObject currentOrder = orders[index];
            
            bool finished = false;
            
            if(mode==1){
                finished =  currentOrder.transform.GetChild(ingredient).gameObject.GetComponent<MenuIngredientsController>().checkIngredients();
                if (!finished)
                {
                    return;
                }
            }
  
            
//            if (Timers[index]>0 & finished & currentOrder.active)
//            {
//                getPoints(Int32.Parse(reward.text));
//            }
            currentOrder.SetActive(false);
            burgers[index].SetActive(false);
        }
        
        
    }


    void getPoints(int num)
    {
        CoinCounterScript.instance.ChangeAmount(num);
    }

    void updateOrderIngredients(GameObject currentIngredients)
    {
        currentIngredients.GetComponent<MenuIngredientsController>().randomResetIngredients();
    }

    void displayNewOrder(int index)
    {
        if (index < orders.Count)
        {
            GameObject currentOrder = orders[index];
            currentOrder.SetActive(true);
            burgers[index].SetActive(true);
            GameObject currentIngredients = currentOrder.transform.GetChild(ingredient).gameObject;
            updateOrderIngredients(currentIngredients);
            Timers[index] = (float)time;
        }

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
        return currentOrder.transform.GetChild(ingredient).gameObject.GetComponent<MenuIngredientsController>().checkIngredients();
    }
    
     public void reduceIngredients(int index) {
        GameObject currentOrder = orders[index]; currentOrder.transform.GetChild(1).gameObject.GetComponent<MenuIngredientsController>().reduceIngredients();
    }

    public void markAsFinished(int index){
        finished[index] = true;
    }
    

}
