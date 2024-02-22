using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public abstract class UserInterface : MonoBehaviour
{
    
    public InventoryObject inventory;
    public Sprite NullItem;
    Transform CanvasOnTop;
    public GameObject DescriptionObject;

    protected Dictionary<GameObject, InventorySlot> slotsOnInterfaces = new Dictionary<GameObject, InventorySlot>();
    private void Awake()
    {
        CanvasOnTop = GameObject.Find("CanvasOnTop").GetComponent<Transform>();
        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            inventory.GetSlots[i].parent = this;
            inventory.GetSlots[i].OnAfterUpdate += OnSlotUpdate;
        }
        CreateSlots();

        
    }
    private void OnSlotUpdate(InventorySlot _slot)
    {
        if (_slot.item.Id >= 0)
        {
            _slot.slotDisplay.transform.Find("ItemImage").GetComponent<Image>().sprite = _slot.ItemObject.sprite;
            _slot.slotDisplay.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = _slot.amount == 1 ? "" : _slot.amount.ToString("n0");
        }
        else
        {
            _slot.slotDisplay.transform.Find("ItemImage").GetComponent<Image>().sprite = NullItem;
            _slot.slotDisplay.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "";
        }
    }
    private void OnEnable()
    {
        slotsOnInterfaces.UpdateSlotDisplay(NullItem);
    }

    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
    public abstract void CreateSlots();

    static GameObject UIDetailObject;

    public void OnEnter(GameObject obj)
    {
        MouseData.slotHoberedOver = obj;
        MouseData.interfaceMouseIsOver = this;
        if (slotsOnInterfaces[obj].item.Id < 0) return;

    }
    public void OnExit(GameObject obj)
    {
        MouseData.slotHoberedOver = null;
        MouseData.interfaceMouseIsOver = null;

    }
    public void OnDragStart(GameObject obj)
    {
        if (slotsOnInterfaces[obj].item.Id >=0)
        MouseData.tempItemBeingDragged = CreateTempItem(obj);

    }
    public GameObject CreateTempItem(GameObject obj)
    {
        if (UIDetailObject != null)
        {
            Destroy(UIDetailObject);

        }

        var DescObj = Instantiate(DescriptionObject, GameObject.Find("CanvasOnTop").transform);
        DescObj.GetComponent<ItemDetailsUI>().GetDetails(slotsOnInterfaces[obj]);
        UIDetailObject = DescObj;

        var tempItem = new GameObject();
        var rt = tempItem.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(70, 70);
        tempItem.transform.SetParent(CanvasOnTop.parent);
        var img = tempItem.AddComponent<Image>();
        img.sprite = slotsOnInterfaces[obj].ItemObject.sprite;
        img.raycastTarget = false;
        MouseData.tempItemBeingDragged = tempItem;
        return tempItem;


    }
    public void OnDragEnd(GameObject obj)
    {
        if(slotsOnInterfaces[obj].item.Id < 0) { return; }
        Destroy(MouseData.tempItemBeingDragged);

        if (MouseData.slotHoberedOver)
        {
            InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterfaces[MouseData.slotHoberedOver];
            inventory.SwapItem(slotsOnInterfaces[obj], mouseHoverSlotData);
        }
        slotsOnInterfaces.UpdateSlotDisplay(NullItem);
        if (UIDetailObject != null) Destroy(UIDetailObject);
    }
    public void OnDrag(GameObject obj)
    {
        if (MouseData.tempItemBeingDragged != null)
        {
            MouseData.tempItemBeingDragged.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }


}
public static class MouseData
{
    public static UserInterface interfaceMouseIsOver;
    public static GameObject tempItemBeingDragged;
    public static GameObject slotHoberedOver;
}

public static class ExtensionMethods
{
    public static void UpdateSlotDisplay(this Dictionary<GameObject, InventorySlot> _slotsOnInterface, Sprite NullItem)
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in _slotsOnInterface)
        {
            if (_slot.Value.item.Id >= 0)
            {
                _slot.Key.transform.Find("ItemImage").GetComponent<Image>().sprite = _slot.Value.ItemObject.sprite;
                _slot.Key.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.Find("ItemImage").GetComponent<Image>().sprite = NullItem;
                _slot.Key.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }
}
