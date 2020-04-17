using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionHandler : MonoBehaviour
{
    public bool isEnemy = false;
    //EatableTag?
    private string targetTag;

    private FoodHandler foodHandler;

    private void Awake()
    {
        foodHandler = GetComponent<FoodHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        targetTag = isEnemy ? "Player" : "Enemy"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            //Debug.Log(collision.gameObject.name);
            FoodHandler foodHandler = collision.gameObject.GetComponent<FoodHandler>();
            if (foodHandler)
            {
                if (this.foodHandler.curFood > foodHandler.curFood)
                {
                    this.foodHandler.HandleFood(foodHandler.curFood);
                    foodHandler.HandleFood(-foodHandler.curFood);
                    //Debug.Log("Eaten");
                }
            }
        }
    }


}
