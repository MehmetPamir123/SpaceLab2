using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetailsUI : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text itemName;
    public TMP_Text itemType;
    public TMP_Text itemDescription;
    public Transform StatsHolderObject;
    public GameObject BuffHolderText;
    public void GetDetails(InventorySlot _item)
    {

        itemImage.sprite = _item.ItemObject.sprite;
        itemName.text = _item.ItemObject.data.Name;
        itemType.text = _item.ItemObject.type.ToString();
        itemDescription.text = _item.ItemObject.description.ToString();
        for (int i = 0; i < _item.item.buffs.Length; i++)
        {
            var buffText = Instantiate(BuffHolderText,StatsHolderObject);
            buffText.GetComponent<TMP_Text>().text = (_item.item.buffs[i].attiribute.ToString()+ " : " + _item.item.buffs[i].value.ToString());
        }
    }
}
