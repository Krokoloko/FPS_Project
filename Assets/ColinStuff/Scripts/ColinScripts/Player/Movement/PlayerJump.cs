﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private bool isGrounded = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 5 * this.transform.localScale.y, Color.red);

        if(Physics.Raycast(ray, out hit, 7f * this.transform.localScale.y))
        {
            if(hit.distance >= 1.1f * this.transform.localScale.y)
            {
                isGrounded = false;
            } else if(hit.distance <= 1.1f * this.transform.localScale.y)
            {
                isGrounded = true;
            }
        }
        if(Input.GetButtonDown(Strings.Movement.JUMP) && isGrounded)
        {
            StartCoroutine("Jumping", 100);
        }
    }

    private IEnumerator Jumping()
    {
        float jumpSpeed = 6 /* (this.transform.localScale.y/5)*/;
        float maxHeight = 2 + this.transform.position.y/* * this.transform.localScale.y*/;
        while(Input.GetButton(Strings.Movement.JUMP) && this.transform.position.y < maxHeight)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpSpeed, 0);
            jumpSpeed -= 0.06f * this.transform.localScale.y;
            yield return null;
        }

    }
}
