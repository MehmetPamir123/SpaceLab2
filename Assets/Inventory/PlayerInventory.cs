using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject equipmentInner;
    public InventoryObject equipmentOuter;


    public Attribute[] attributes;

    private void Start()
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < equipmentInner.GetSlots.Length; i++)
        {
            equipmentInner.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            equipmentInner.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }
        for (int i = 0; i < equipmentOuter.GetSlots.Length; i++)
        {
            equipmentOuter.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            equipmentOuter.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }
    }
    public void OnBeforeSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:

                break;
            case InterfaceType.Equipment:
                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int ii = 0; ii < attributes.Length; ii++)
                    {
                        if (attributes[ii].type == _slot.item.buffs[i].attiribute)
                            attributes[ii].value.RemoveModifier(_slot.item.buffs[i]);
                    }
                }
                break;
            case InterfaceType.Chest:

                break;
            default:
                break;
        }

    }
    public void OnAfterSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
            return;
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:

                break;
            case InterfaceType.Equipment:

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int ii = 0; ii < attributes.Length; ii++)
                    {
                        if (attributes[ii].type == _slot.item.buffs[i].attiribute)
                            attributes[ii].value.AddModifier(_slot.item.buffs[i]);

                        switch (attributes[ii].type.ToString())
                        {
                            case "Health":
                                PRC.MaxHealthSET(attributes[ii].value.BaseValue);
                                break;
                            case "Fuel":
                                PRC.MaxFuelSET(attributes[ii].value.BaseValue);
                                break;
                            case "Energy":
                                PRC.MaxEnergySET(attributes[ii].value.BaseValue);
                                break;
                        }
                    }
                }
                break;
            case InterfaceType.Chest:

                break;
            default:
                break;
        }
        
       
    }

    public PlayerResourceController PRC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<GroundItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            if (inventory.AddItem(_item, 1))
            {
                Destroy(collision.gameObject);
            }

            Destroy(collision.gameObject);
        }
    }
    [ContextMenu("Save Inventories")]
    public void SaveInventories()
    {
        inventory.Save();
        equipmentOuter.Save();
        equipmentInner.Save();
    }
    [ContextMenu("Load Inventories")]
    public void LoadInventories()
    {
        inventory.Load();
        equipmentOuter.Load();
        equipmentInner.Load();
    }

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute.type, " => ", attribute.value.ModifiedValue));
    }


    private void OnApplicationQuit()
    {
        inventory.Clear();
        equipmentInner.Clear();
        equipmentOuter.Clear();
    }
}

[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public PlayerInventory parent;
    public Attributes type;
    public ModifiableInt value;

    public void SetParent(PlayerInventory _parent)
    {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }
    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}
