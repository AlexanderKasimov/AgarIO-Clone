using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    public float curFood;
    public float foodScaleEffectMultiplayer = 0.1f;

    private bool isDead = false;

    public bool isPlayer = false;
    
    private void Awake()
    {
        curFood = 1f;
    }

    public void HandleFood(float value)
    {
        if (isDead)
        {
            return;
        }
        curFood += value;
        if (curFood <= 0)
        {
            HandleDeath();
            return;
        }
        transform.localScale += new Vector3(value * foodScaleEffectMultiplayer, value * foodScaleEffectMultiplayer, 0f); 
    }

    private void HandleDeath()
    {
        isDead = true;
        if (isPlayer)
        {
            PlayerController.instance.PlayerDied();
        }
        else
        {
            Destroy(gameObject);
        }       

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
