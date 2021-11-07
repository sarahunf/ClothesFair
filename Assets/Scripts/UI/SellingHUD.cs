using System;
using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;
using UnityEngine.UI;

public class SellingHUD : MonoBehaviour
{
    public GameObject slot;

    public static SellingHUD ME = null;

    public Transform slotsParent;

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
            go.GetComponent<Slot>().Populate(clt);
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
        Store.opened = false;
    }
}
