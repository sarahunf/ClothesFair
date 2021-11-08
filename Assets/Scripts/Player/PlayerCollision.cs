using System;
using System.Collections;
using System.Collections.Generic;
using General;
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
        if (!coll.gameObject.name.Contains("store")) return;
        var store = coll.gameObject.GetComponent<Store.Store>();
        StartCoroutine(store.ShowSpeech());
        if (spacePressed && !Store.Store.opened)
        {
            store.CloseSpeech();
            store.OpenSell();
        }

        if (spacePressed && Instructions.ME.isShow)
        {
            Instructions.ME.HideSpacebarTip();
        }
        if (Instructions.ME.usedSpacebarOnce) return;
        Instructions.ME.ShowSpacebarTip();
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (!coll.gameObject.name.Contains("Changer")) return;
        if (spacePressed)
        {
            coll.gameObject.GetComponent<Changer>().Open();
        }

        if (spacePressed && Instructions.ME.isShow)
        {
            Instructions.ME.HideSpacebarTip();
        }

        if (Instructions.ME.usedSpacebarOnce) return;
        Instructions.ME.ShowSpacebarTip();
    }
}