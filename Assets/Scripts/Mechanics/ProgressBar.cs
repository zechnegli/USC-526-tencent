using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar instance;
    private Slider slider;
    private double targetProgress = 0;
    public float fillSpeed = 0.5f;
    public bool isFull = false;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        this.gameObject.SetActive(false);
        slider = gameObject.GetComponent<Slider>();
//        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress) {
            slider.value += fillSpeed * Time.deltaTime;
        } 
//        if (isFull) {
//            this.myGameObject.SetActive(false);
//            isFull = false;
//        }
        isFull = slider.value >= 1;  
    }
    
    public void incrementProgress(float newProgress) {
        targetProgress = slider.value + newProgress;
    }
    
    public bool checkIfSliderToFull() {
        return isFull;
    }
    
    public void resetSlider() {
        slider.value = 0;
        isFull = false;
    }
    
    public void displayProgressBar() {
        this.gameObject.SetActive(true);
    }
    
    public void hideProgressBar() {
        this.gameObject.SetActive(false);
        resetSlider();
    }
}
