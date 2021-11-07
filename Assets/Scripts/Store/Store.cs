using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private NpcController npc;
    public static bool opened;

    public void OpenSell()
    {
        if (opened) return;
        opened = true;
        npc.OpenSell();
    }
}