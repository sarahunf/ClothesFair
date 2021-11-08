using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class SellingHUD : MonoBehaviour
    {
        public GameObject slot; 
        public List<Slot> slots;

        public static SellingHUD ME = null;

        public Transform slotsParent;
        public static Clothes selectedClothes;
        public UnityEvent onClose;
        public UnityEvent onSell;
        public UnityEvent onLeftWithoutBuying;

        private bool boughtSomething;

        private void Awake()
        {
            if (ME == null)
            {
                ME = this;
            }
            else if (ME != this)
            {
                Destroy(gameObject);
            }
        }
        public void PopulateHUD(List<Clothes> clothes)
        {
            slotsParent.parent.gameObject.SetActive(true);
        
            foreach (var clt in clothes)
            {
                var go = Instantiate(slot,slotsParent);
                Slot x = go.GetComponent<Slot>();
                x.Populate(clt);
                slots.Add(x);
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        }

        public void CloseHUD()
        {
            for (int i = 0; i < slotsParent.childCount; i++)
            {
                GameObject go = slotsParent.GetChild(i).gameObject;
                Destroy(go);
            }
            slotsParent.parent.gameObject.SetActive(false);
            Store.Store.opened = false;
        
            //left without buying unlock NPC anim
            if (!boughtSomething)
            {
                onLeftWithoutBuying.Invoke();
            }
            else
            {
                boughtSomething = false;
            }
            onClose.Invoke();
        }

        public void BuyClothes()
        {
            foreach (var slotX in slots.Where(s => s.toggle.isOn))
            {
                selectedClothes = slotX.slotClothes;
            }

            if (selectedClothes.value <= PlayerController.ME.money.money)
            {
                PlayerController.ME.AddClothesToInventory(selectedClothes, true);
                boughtSomething = true;
                onSell.Invoke();
                CloseHUD();
                PlayerController.ME.money.SpendMoney(selectedClothes.value);
            }
            else
            {
                Debug.Log("Not enough money to buy");
            }
        }
    }
}
