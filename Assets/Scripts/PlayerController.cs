using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    PlayerInfo playerinfo;

    // Use this for initialization
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("PlayerInfoStorage") != null)
        {
            playerinfo = GameObject.FindGameObjectWithTag("PlayerInfoStorage")
            .GetComponent<PlayerInfo>();
            moveSpeed = 1.5f * Mathf.Pow(playerinfo.agility, 0.3f);
            gameObject.GetComponent<SpriteRenderer>().color = playerinfo.monsterColour;
        }
        else moveSpeed = 1.5f * Mathf.Pow(1, 0.3f);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Horizontal")>0.5f || Input.GetAxisRaw("Horizontal")< -0.5f)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal")
                * moveSpeed * Time.deltaTime, 0f));
            if(Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical")
                * moveSpeed * Time.deltaTime));
        }
    }
}
