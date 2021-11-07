using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        public InventorySlot[] shownSlots;
        public List<Clothes> allClothes;
        public List<InventorySlot> allSlots = new List<InventorySlot>();
        public GameObject inventoryGO;
        public GameObject slotPrefab;
        public Transform slotsParent;

        public void DisplayAllClothes()
        {
            inventoryGO.SetActive(true);
            for (int i = 0; i < allClothes.Count; i++)
            {
                GameObject go = Instantiate(slotPrefab, slotsParent);
                allSlots.Add(go.GetComponent<InventorySlot>());
                allSlots[i].Populate(allClothes[i]);
            }
        }

        public void HideAllClothes()
        {
            inventoryGO.SetActive(false);
            allSlots.Clear();
            
            for (int i = 0; i < slotsParent.childCount; i++)
            {
                GameObject go = slotsParent.GetChild(i).gameObject;
                Destroy(go);
            }
        }
    }
}
