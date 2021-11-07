using System;
using System.Collections.Generic;
using System.IO;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace NPC
{
    public class NpcController : MonoBehaviour
    {
        [SerializeField] private string clothe;
        [SerializeField] private List<Clothes> clothes;

        public void OpenSell()
        {
            SellingHUD.ME.PopulateHUD(clothes);
        }

        public void CloseSell()
        {
            
        }
    }
}