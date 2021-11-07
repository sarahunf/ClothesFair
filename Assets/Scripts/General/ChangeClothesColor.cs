using System;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ChangeClothesColor : MonoBehaviour
    {
       private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                Debug.LogError("object does not contain an sprite renderer");
            }
        }

        public void ChangeColor(Color32 color)
        {
            if (spriteRenderer)
            {
                spriteRenderer.color = color;
            }
        }
    }
}