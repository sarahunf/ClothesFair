using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image image;
    public Text displayName;
    public Text displayValue;
    private Color32 color;

    public Clothes slotClothes;
    
    public Toggle toggle;

    private void Start()
    {
        toggle.group = SellingHUD.ME.slotsParent.GetComponent<ToggleGroup>();
    }

    public void Populate(Clothes clt)
    {
        image.sprite = clt.sprite;
        displayName.text = clt.displayName;
        displayValue.text = clt.value.ToString();
        image.color = clt.color;
        slotClothes = clt;
    }
}
