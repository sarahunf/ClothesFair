using System;
using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private NpcController npc;
    public static bool opened;
    public Sprite facingStore;

    private void Start()
    {
        SellingHUD.ME.onClose.AddListener(CloseSell);
    }


    public void OpenSell()
    {
        if (opened) return;
        opened = true;
        npc.OpenSell();
        PlayerController.ME.movement.StopMoving();
    }

    public void CloseSell()
    {
        PlayerController.ME.movement.StartMoving();
        if (!opened) return;
        opened = false;
        npc.CloseSell();
    }
}