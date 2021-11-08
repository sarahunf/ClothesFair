using System;
using System.Collections.Generic;
using System.Linq;
using General;
using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<SpriteRenderer> clothes;
    public static PlayerController ME = null;
    public PlayerMovement movement;
    public Inventory inventory;
    public PlayerMoney money;
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

    public void ChangeClothes(Clothes clothes)
    {
        foreach (var clt in this.clothes.Where(clt => clt.gameObject.name.Contains(clothes.name.GetUntilOrEmpty())))
        {
            clt.GetComponent<ChangeClothesColor>().ChangeColor(clothes.color);
            break;
        }
        AddClothesToInventory(clothes, false);
    }

    public void AddClothesToInventory(Clothes clothes, bool shouldAddToInventory)
    {
        foreach (var t in inventory.shownSlots)
        {
            if (clothes.name.Contains(t.typeOfClothes))
                t.Populate(clothes);
        }

        if (shouldAddToInventory)
            inventory.allClothes.Add(clothes);
    }
    
}