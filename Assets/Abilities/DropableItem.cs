using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropableItem : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropped");
        SetStats();
    }
    public virtual void SetStats()
    {
        
        MouseAbilityData.passive = null;
        MouseAbilityData.ability = null;
    }

}