using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool spacePressed;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spacePressed = true;
        }

        if (Input.GetKeyUp("space"))
        {
            spacePressed = false;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.name.Contains("store") && spacePressed && !Store.Store.opened)
        {
            coll.gameObject.GetComponent<Store.Store>().OpenSell();
        }

    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name.Contains("Changer") && spacePressed)
        {
            coll.gameObject.GetComponent<Changer>().Open();
        }
    }
}