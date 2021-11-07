using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace NPC
{
    public class NpcController : MonoBehaviour
    {
        [SerializeField] private string clothe;
        [SerializeField] private List<Clothes> clothes;
        private void Start()
        {
            SellingHUD.ME.onSell.AddListener(Sell);
        }

        private void Sell()
        {
            //PlayerController.ME.ChangeClothes(clothe);
        }

        public void OpenSell()
        {
            SellingHUD.ME.PopulateHUD(clothes);
        }

        public void CloseSell()
        {
            
        }
    }
}