using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float mapBoxSize = 60f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckIfPlayerWon", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckIfPlayerWon()
    {
        FoodHandler foodHandler = PlayerController.instance.GetComponent<FoodHandler>();
        if (foodHandler)
        {
            if (foodHandler.curFood * foodHandler.foodScaleEffectMultiplayer > mapBoxSize)
            {
                PlayerWon();
            }            
        }       
    }

    private void PlayerWon()
    {
        Invoke("RestartGame", 3f);
    }

    public void PlayerDied()
    {
        Invoke("RestartGame", 5f);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

  

}
