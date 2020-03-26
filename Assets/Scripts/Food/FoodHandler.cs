using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    public float curFood;
    public float foodScaleEffectMultiplayer = 0.1f;
    
    private void Awake()
    {
        curFood = 0f;
    }

    public void HandleFood(float value)
    {
        curFood += value;
        transform.localScale += new Vector3(value * foodScaleEffectMultiplayer, value * foodScaleEffectMultiplayer, 0f); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
