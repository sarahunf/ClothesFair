using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Slot : MonoBehaviour
    {
        public Image image;
        public Text displayName;
        public Text displayValue;
        private Color32 color;
        public Toggle toggle;

        [HideInInspector]public Clothes slotClothes;
    

        private void Start()
        {
            if (toggle)
                toggle.group = SellingHUD.ME.slotsParent.GetComponent<ToggleGroup>();
        }

        public virtual void Populate(Clothes clt)
        {
            if (image)
            {
                image.gameObject.SetActive(true);
                image.sprite = clt.sprite;
                image.color = clt.color;
            }
            if (displayName)
                displayName.text = clt.displayName;
            if (displayValue)
                displayValue.text = clt.value.ToString();
        
            slotClothes = clt;
        }
    }
}
