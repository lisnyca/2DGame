using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, noSelectedColor;
    public void Select()
    {
        image.color = selectedColor;    
    }
    public void Deselect()
    {
        image.color = noSelectedColor;
    }
    private void Awake()
    {
        Deselect();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount ==0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem dragItem = dropped.GetComponent<InventoryItem>();
            dragItem.parentAfterDrag = transform;
        }
        else if (transform.childCount == 1)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem dragItem = dropped.GetComponent<InventoryItem>();
            Transform child = transform.GetChild(0);
            InventoryItem childItem = child.GetComponent<InventoryItem>();
            childItem.parentAfterDrag = dragItem.parentAfterDrag.transform;
            childItem.transform.SetParent(childItem.parentAfterDrag);
            dragItem.parentAfterDrag = transform;
            dragItem.transform.SetParent(dragItem.parentAfterDrag);
        }
    }
}
