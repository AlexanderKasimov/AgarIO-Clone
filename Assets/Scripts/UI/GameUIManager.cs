using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    private Text foodText;

    private void Awake()
    {
        foodText = GetComponentInChildren<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foodText.text = "Food:" + PlayerController.instance.GetComponent<FoodHandler>().curFood;
    }
}
