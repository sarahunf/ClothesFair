using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private Npc npc;

    private void OpenSell()
    {
        npc.onSell.Invoke();
    }
}
