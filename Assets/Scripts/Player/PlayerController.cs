using System.Collections.Generic;
using System.Linq;
using General;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<SpriteRenderer> clothes;
    public static PlayerController ME = null;

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

    public void ChangeClothes(string clothes)
    {
        foreach (var clt in this.clothes.Where(clt => clt.gameObject.name.Contains(clothes)))
        {
            clt.GetComponent<ChangeClothesColor>()
                .ChangeColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
            break;
        }
    }
}