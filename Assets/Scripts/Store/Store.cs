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

        private void Start()
        {
            SellingHUD.ME.onClose.AddListener(CloseSell);
            player = PlayerController.ME;
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