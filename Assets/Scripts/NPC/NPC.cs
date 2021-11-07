using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace NPC
{
    public class Npc : MonoBehaviour
    {
        public UnityEvent onSell;
        [SerializeField] private Collider2D collider2D;

        private void Start()
        {
            onSell.AddListener(Sell);
        }

        private void Sell()
        {
            Debug.Log("Selling right now");
        }
    }
}