using System;
using TMPro;
using Unity.Profiling;
using UnityEngine;

namespace Player
{
    public class PlayerMoney : MonoBehaviour
    {
        public TMP_Text text;
        public float money = 40f;


        private void Start()
        {
            text.text = money.ToString();
        }

        public void SpendMoney(float value)
        {
            if (!(money >= value)) return;
            money -= value;
            text.text = money.ToString();
        }
    }
}
