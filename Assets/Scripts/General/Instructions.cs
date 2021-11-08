using System;
using TMPro;
using UnityEngine;

namespace General
{
    //this class is generally poorly built. Refactor is welcome
    public class Instructions : MonoBehaviour
    {
       [SerializeField] private GameObject tipGO;
       public bool usedSpacebarOnce;
       public bool isShow;
       public static Instructions ME = null;

       public string[] instructionStrings;
       [SerializeField] private TMP_Text instructionText;
       [SerializeField] private Changer changer;
       
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

       public void ShowSpacebarTip()
       {
           isShow = true;
           usedSpacebarOnce = true;
           instructionText.text = instructionStrings[0];
           gameObject.SetActive(true);
           tipGO.SetActive(true);
       }

       public void HideSpacebarTip()
       {
           isShow = false;
           tipGO.SetActive(false);
           gameObject.SetActive(false);
       }

       public void ShowTreeTip()
       {
           isShow = true;
           changer.PlayAnimation();
           instructionText.text = instructionStrings[1];
           gameObject.SetActive(true);
           tipGO.SetActive(true);
       }

       public void HideTreeTip()
       {
           isShow = false;
           tipGO.SetActive(false);
           gameObject.SetActive(false);
       }
    }
}
