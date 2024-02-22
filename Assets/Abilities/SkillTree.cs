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

    Color32 lockedColor = new Color32(150, 150, 150, 100);
    Color32 unlockedColor = new Color32(255, 255, 255, 100);

    public void Start()
    {
        SkillNormalText.text = AbilitiesAndPassives.Level.ToString();
        SkillMasterText.text = AbilitiesAndPassives.Level.ToString();
        switch (AbilitiesAndPassives.Mastery )
        {
            case SkillMastery.Locked:
                buttonPassive.GetComponent<Button>().enabled = false;
                buttonPassive.GetComponent<Image>().color = lockedColor;

                break;
            case SkillMastery.Passive:

                break;
            case SkillMastery.Normal:
                buttonSkillNormal.GetComponent<Image>().color = unlockedColor;
                buttonSkillNormal.GetComponent<Button>().enabled = true;
                SkillNormalText.text = AbilitiesAndPassives.Level.ToString();
                SkillNormalText.gameObject.SetActive(true);

                break;
            case SkillMastery.Master:
                buttonSkillMaster.GetComponent<Image>().color = unlockedColor;
                buttonSkillMaster.GetComponent<Button>().enabled = true;
                SkillMasterText.text = AbilitiesAndPassives.Level.ToString();
                SkillMasterText.gameObject.SetActive(true);
                break;
            case SkillMastery.Perfect:
                buttonPassive.GetComponent<Image>().color = unlockedColor;
                buttonSkillPerfect.GetComponent<Button>().enabled = true;
                break;
        }

    }

}
public enum SkillType
{
    Attack,
    Defence,
    Flexible
}
