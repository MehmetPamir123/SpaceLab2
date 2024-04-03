using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilityController : MonoBehaviour
{
    [SerializeField] Ability[] Abilities = new Ability[3];
    public Image[] SkillButtons = new Image[3];
    public Image[] SkillGRAYButtons = new Image[3];
    public Image[] SkillHolders = new Image[3];

    public Sprite EmptyHolder;

    public GameObject player;
    PlayerResourceController PRC;

    private void Start()
    {
        PRC = GameObject.FindGameObjectWithTag("PlayerResourceController").GetComponent<PlayerResourceController>();
    }

    private void Update()
    {
        //BÝLGÝSAYARDA SKÝLL KULLANMAM ÝÇÝN OLUÞTURDUM MOBÝLE YÜKLERKEN SÝLÝCEM
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SkillUse(0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SkillUse(1);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SkillUse(2);
        }
    }

    public void SkillUse(int abilityNummer)
    {
        if (Abilities[abilityNummer] != null && Abilities[abilityNummer].usable)
        {
            Abilities[abilityNummer].Activate(player, PRC);
            StartCoroutine(Cooldown(abilityNummer));
        }
        else
        {
            Debug.Log("There is no such skill");
        }
    }
    IEnumerator Cooldown(int abilityNummer)
    {

        float maxCooldown = Abilities[abilityNummer].cooldown;
        Debug.Log(maxCooldown);
        for (float coolDown = Abilities[abilityNummer].cooldown; coolDown >= 0.1f; coolDown -= 0.1f)
        {
            SkillGRAYButtons[abilityNummer].fillAmount = coolDown / maxCooldown;
            yield return new WaitForSeconds(0.1f);


        }
        if (SkillGRAYButtons[abilityNummer] != null)
        {
            SkillGRAYButtons[abilityNummer].fillAmount = 0;
        }


    }
    public void AddSkillToSkillSlot(Ability ability, int abilityIndex, Image holderImage)
    {
        for (int i = 0; i < Abilities.Length; i++)
        {
            if (Abilities[i] == ability)
            {
                if (abilityIndex == i)
                {
                    return;
                }
                else
                {
                    Abilities[i] = null;
                    SkillButtons[i].sprite = EmptyHolder;
                    SkillHolders[i].sprite = EmptyHolder;
                    break;

                }
            }
        }
        Abilities[abilityIndex] = ability;
        SkillButtons[abilityIndex].sprite = ability.abilityImage;
        holderImage.sprite = ability.abilityImage;
    }

}
