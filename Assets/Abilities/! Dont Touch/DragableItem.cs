using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler,IDragHandler
{
    Transform CanvasOnTop;
    GameObject tempItem;
    public Ability ability;
    public Passive passive;
    private void Start()
    {
        CanvasOnTop = GameObject.Find("CanvasOnTop").GetComponent<Transform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        CreateTempItem(this.gameObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        tempItem.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(tempItem);
    }

    public GameObject CreateTempItem(GameObject obj)
    {
        tempItem = new GameObject();
        var rt = tempItem.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(70, 70);
        var img = tempItem.AddComponent<Image>();
        img.sprite = obj.GetComponent<Image>().sprite;
        img.raycastTarget = false;

        MouseAbilityData.passive = passive;
        MouseAbilityData.ability = ability;

        tempItem.transform.parent = CanvasOnTop;


        return tempItem;


    }
    public void OnDrag(GameObject obj)
    {
        if (MouseData.tempItemBeingDragged != null)
        {
            MouseData.tempItemBeingDragged.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }
}
public static class MouseAbilityData
{
    public static Passive passive;
    public static Ability ability;
}
