using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 movingDirection;

    public float speed = 15f;

    public float lifeTime = 2f;

    private float foodCost = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
  
    public void Init(Vector2 direction, Vector3 scale, float foodCost)
    {
        movingDirection = direction;
        transform.rotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.right, direction));
        transform.localScale = Vector3.Scale(transform.localScale, scale);
        this.foodCost = foodCost;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movingDirection * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            FoodHandler foodHandler = collision.gameObject.GetComponent<FoodHandler>();
            if (foodHandler)
            {
                foodHandler.HandleFood(-foodCost * 2f);
            }
            
        }


        Destroy(gameObject);
    }

}
