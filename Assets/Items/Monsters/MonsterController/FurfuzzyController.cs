using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurfuzzyController : MonoBehaviour {

    public float moveSpeed;
    public float timeGap;

    public float movingDistance;
    public float timer;
    public Vector2 targ;

    float x;
    float y;

    private void Start()
    {
        NewTarget();
    }

    private void Update()
    {
        //target change every timeGap based on timer
        timer -= Time.deltaTime;
        if (timer < -timeGap)
        {
            //Debug.Log("beep"+timer);
            NewTarget();
            timer = 0;
        }

        //moving character
        transform.position = Vector2.MoveTowards(transform.position,
            targ, moveSpeed*Time.deltaTime);
    }

    //if collide stop moving to that target
    void OnCollisionEnter2D(Collision2D col)
    {
        targ = transform.position;
        //Debug.Log("collid");
    }

    void NewTarget()
    {
        x = Random.Range(-movingDistance, movingDistance);
        y = Random.Range(-movingDistance, movingDistance);

        targ = new Vector2(gameObject.transform.position.x + x,
            gameObject.transform.position.y + y);        
    }
}
