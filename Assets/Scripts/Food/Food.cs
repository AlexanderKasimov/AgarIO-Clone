using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float value = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale *= value; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            FoodHandler foodhandler = collision.gameObject.GetComponent<FoodHandler>();
            if (foodhandler)
            {
                foodhandler.HandleFood(value);
                Destroy(gameObject);
            }
        }

        //Debug.Log(collision.gameObject);
    } 
}
