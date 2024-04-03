using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropableItem : MonoBehaviour,IDropHandler
{
    protected PlayerAbilityController PAC;
    private void Start()
    {
        PAC = GameObject.Find("Player").GetComponent<PlayerAbilityController>();
    }
    public void OnDrop(PointerEventData eventData)
    {

        SetStats();
    }
    public virtual void SetStats()
    {
        
        MouseAbilityData.passive = null;
        MouseAbilityData.ability = null;
    }

}