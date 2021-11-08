using System.Collections;
using NPC;
using UI;
using UnityEngine;

namespace Store
{
    public class Store : MonoBehaviour
    {
        [SerializeField] private NpcController npc;
        public static bool opened;
        private PlayerController player;

        [SerializeField] private GameObject speechBalloon;
        private void Start()
        {
            SellingHUD.ME.onClose.AddListener(CloseSell);
            player = PlayerController.ME;
        }

        public IEnumerator ShowSpeech()
        {
            if (SellingHUD.isOpen) yield break;
            speechBalloon.SetActive(true);
            yield return new WaitForSeconds(2f);
            speechBalloon.SetActive(false);
        }

        public void CloseSpeech()
        {
            speechBalloon.SetActive(false);
        }

        public void OpenSell()
        {
            if (opened) return;
            opened = true;
            npc.OpenSell();
            player.movement.StopMoving();
        }

        public void CloseSell()
        {
            player.movement.StartMoving();
            if (!opened) return;
            opened = false;
            npc.CloseSell();
        }
    }
}