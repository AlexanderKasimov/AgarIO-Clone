using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D rb;

    private Vector2 movementInput;

    public static PlayerController instance;

    private Weapon weapon;

    public bool isDead = false;

    //private FoodHandler foodHandler;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            //Get WeaponInput
            if (Input.GetButton("Fire1"))
            {
                weapon?.Fire();
            }
        }      
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
    }

    public void PlayerDied()
    {
        isDead = true;
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (var item in spriteRenderers)
        {
            item.enabled = false;            
        }
        speed = 0f;
        GameManager.instance.PlayerDied();
    }

}
