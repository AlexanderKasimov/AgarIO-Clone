using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private Vector2 aimingDirection;

    private float timeSinceFire = 0f;
    //fire rate
    public float firePerMinute = 120f;

    public Projectile projectilePrefab;

    public GameObject muzzle;

    private FoodHandler foodHandler;
    
    private void Awake()
    {
        foodHandler = GetComponentInParent<FoodHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timeSinceFire = 60f / firePerMinute;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate to mouse
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimingDirection = (mousePosition - (Vector2)transform.position).normalized;
        transform.rotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.right, aimingDirection));
        //update timeSinceFire
        timeSinceFire += Time.deltaTime;
    }

    public void Fire()
    {
        if (timeSinceFire >= 60f/ firePerMinute && foodHandler?.curFood > Mathf.Ceil(foodHandler.curFood * 0.1f))
        {          
            Projectile projectile = Instantiate(projectilePrefab, muzzle.transform.position, Quaternion.identity);
            //Не подавать скейл, подавать число еды
            projectile.Init(aimingDirection, transform.root.localScale, Mathf.Ceil(foodHandler.curFood * 0.1f));
            foodHandler?.HandleFood(-Mathf.Ceil(foodHandler.curFood * 0.1f));
            timeSinceFire = 0f;
        }
    }

}
