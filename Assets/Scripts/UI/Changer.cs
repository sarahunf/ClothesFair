using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Changer : MonoBehaviour
{ 
    public static bool opened;
    private PlayerController player;
    [SerializeField] private Animator animator;
    [SerializeField]  private Button wearBtn;

    private void Start()
    {
        player = PlayerController.ME;
        wearBtn.onClick.AddListener(WearClothes);
    }
    
    private void WearClothes()
    {
        foreach (var slot in player.inventory.allSlots.Where(slot => slot.toggle.isOn))
        {
            PlayerController.ME.ChangeClothes(slot.slotClothes);
        }
        animator.ResetTrigger("open");
        Close();
    }
    
    private void EnableWear()
    {
        if ( player.inventory.allClothes.Count > 0)
        {
            wearBtn.interactable = true;
        }
    }

    public void Open()
    {
        if (opened) return;
        opened = true;
        player.inventory.DisplayAllClothes();
        player.movement.StopMoving();
        animator.SetTrigger("open");
        EnableWear();
    }

    public void Close()
    {
        if (!opened) return;
        opened = false;
        player.inventory.HideAllClothes();
        player.movement.StartMoving();
    }
}
