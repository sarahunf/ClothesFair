using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace NPC
{
    public class NpcController : MonoBehaviour
    {
        public UnityEvent onSell;
        [SerializeField] private string clothe;

        private void Start()
        {
            onSell.AddListener(Sell);
        }

        private void Sell()
        {
            PlayerController.ME.ChangeClothes(clothe);
        }
    }
}