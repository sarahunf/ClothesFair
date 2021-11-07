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
        if (coll.gameObject.name.Contains("store") && spacePressed && !Store.opened)
        {
            coll.gameObject.GetComponent<Store>().OpenSell();
        }
    }
}