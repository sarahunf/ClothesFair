using UI;
using UnityEngine;

namespace Player
{
    public class InventorySlot : Slot
    {
        public string typeOfClothes;

        public override void Populate(Clothes clt)
        {
            base.Populate(clt);
            var imageColor = image.color;
            imageColor.a = 1f;
        }
    }
}
