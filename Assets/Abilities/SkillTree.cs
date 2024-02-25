using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillTree : MonoBehaviour
{
    public AbilityAndPassiveClassHolder AbilitiesAndPassives;

    public GameObject buttonPassive;
    public GameObject buttonSkillNormal;
    public GameObject buttonSkillMaster;
    public GameObject buttonSkillPerfect;
    public TMP_Text SkillNormalText;
    public TMP_Text SkillMasterText;

    Color32 lockedColor = new Color32(61, 61, 61, 255);
    Color32 unlockedColor = new Color32(255, 255, 255, 255);

    public void Start()
    {
        SkillNormalText.text = AbilitiesAndPassives.Level.ToString();
        SkillMasterText.text = AbilitiesAndPassives.Level.ToString();
        DragableItem drag;
        switch (AbilitiesAndPassives.Mastery )
        {
            case SkillMastery.Locked:
                buttonPassive.GetComponent<Button>().enabled = false;
                buttonPassive.GetComponent<Image>().color = lockedColor;

                break;
            case SkillMastery.Passive:

                drag = buttonPassive.AddComponent<DragableItem>();
                drag.passive = AbilitiesAndPassives.passive;

                break;
            case SkillMastery.Normal:
                buttonSkillNormal.GetComponent<Image>().color = unlockedColor;
                buttonSkillNormal.GetComponent<Button>().enabled = true;
                SkillNormalText.text = AbilitiesAndPassives.Level.ToString();
                SkillNormalText.gameObject.SetActive(true);

                drag = buttonSkillNormal.AddComponent<DragableItem>();
                drag.ability = AbilitiesAndPassives.abilityNormal;
                drag = buttonPassive.AddComponent<DragableItem>();
                drag.passive = AbilitiesAndPassives.passive;

                break;
            case SkillMastery.Master:
                buttonSkillMaster.GetComponent<Image>().color = unlockedColor;
                buttonSkillMaster.GetComponent<Button>().enabled = true;
                SkillMasterText.text = AbilitiesAndPassives.Level.ToString();
                SkillMasterText.gameObject.SetActive(true);

                drag = buttonSkillMaster.AddComponent<DragableItem>();
                drag.ability = AbilitiesAndPassives.abilityMaster;
                drag = buttonPassive.AddComponent<DragableItem>();
                drag.passive = AbilitiesAndPassives.passive;
                break;
            case SkillMastery.Perfect:
                buttonSkillPerfect.GetComponent<Image>().color = unlockedColor;
                buttonSkillPerfect.GetComponent<Button>().enabled = true;

                drag = buttonSkillPerfect.AddComponent<DragableItem>();
                drag.ability = AbilitiesAndPassives.abilityPerfect;
                drag = buttonPassive.AddComponent<DragableItem>();
                drag.passive = AbilitiesAndPassives.passive;
                break;
        }
        Debug.Log("Performanssorunu : pasifin içine zaten dragable itemi ekleyip yalnýzca Locked konumunda silsen performansta artýþ olur bi ara yap bunu");
    }

}
public enum SkillType
{
    Attack,
    Defence,
    Flexible
}
