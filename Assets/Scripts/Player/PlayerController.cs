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
    }
}