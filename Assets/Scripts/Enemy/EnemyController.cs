using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 3f;

    private Vector2 movementDirection;

    private GameObject target;

    public float detectionRadius = 5f;

    private FoodHandler foodHandler;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        foodHandler = GetComponent<FoodHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            float minDistance = float.MaxValue;
            Collider2D[] foodColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, LayerMask.GetMask("Player"));
            foreach (Collider2D collider in foodColliders)
            {
                float distance = (collider.gameObject.transform.position - transform.position).magnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = collider.gameObject;
                }
            }
        }

        if (target)
        {
            FoodHandler foodHandler = target.GetComponent<FoodHandler>();
            if (foodHandler)
            {
                target = this.foodHandler.curFood > foodHandler.curFood * 1.1f ? target : null;
            }        
        }


        if (!target)
        {
            float minDistance = float.MaxValue;
            Collider2D[] foodColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, LayerMask.GetMask("Food"));
            foreach (Collider2D collider in foodColliders)
            {
                float distance = (collider.gameObject.transform.position - transform.position).magnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = collider.gameObject;
                }
            }
        }

        movementDirection = target ? (target.transform.position - transform.position).normalized : Vector3.zero;
     

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * speed * Time.fixedDeltaTime);
    }
}
