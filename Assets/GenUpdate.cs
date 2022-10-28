using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GenUpdate : MonoBehaviour
{
    public static GenUpdate instance;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public TMP_Text gemCounter;
   public int gemcounter;
    public void UpdateUI()
    {
        gemcounter++;
        gemCounter.text = gemcounter.ToString();
    }
}
