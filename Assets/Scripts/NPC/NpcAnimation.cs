using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace NPC
{
    public class NpcAnimation : MonoBehaviour
    {
        [SerializeField] private Sprite[] spritesAnimation;
        [SerializeField] private Sprite mainSprite;
        private Sprite defaultSprite;
        private SpriteRenderer spriteRenderer;
        private const float waitTime = 2f;
        [SerializeField] private NpcController controller;
        
        private void Start()
        {
            SellingHUD.ME.onSell.AddListener(Sell);
            SellingHUD.ME.onLeftWithoutBuying.AddListener(NotSell);
            spriteRenderer = GetComponent<SpriteRenderer>();
            defaultSprite = spriteRenderer.sprite;
        }

        private void ChangeEmotion(string emotion)
        {
            foreach (var sp in spritesAnimation)
            {
                if (sp.name.Contains(emotion))
                {
                    mainSprite = sp;
                }
            }
            spriteRenderer.sprite = mainSprite;
            StartCoroutine(DefaultState());
        }

        private IEnumerator DefaultState()
        {
            yield return new WaitForSeconds(waitTime);
            spriteRenderer.sprite = defaultSprite;
        }

        private void Sell()
        {
            ChangeEmotion("happy");
        }

        protected void NotSell()
        {
            ChangeEmotion("sad");
        }
    }
}
