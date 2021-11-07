using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private NpcController npc;

    private void OpenSell()
    {
        npc.onSell.Invoke();
    }
}
