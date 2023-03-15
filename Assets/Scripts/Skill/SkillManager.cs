using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class SkillManager : MonoBehaviour
{
    [SerializeField]
    List<SkillInfoUI> ChoiceSkills = new List<SkillInfoUI>();

    public Dictionary<string, SkillInfo> AllSkills = new Dictionary<string, SkillInfo>();        //��� ��� ����
    public Dictionary<string, SkillBase> MySkills = new Dictionary<string, SkillBase>();            //���� �÷��̾ ������ �ִ� ��ų��

    public KPlayer Player;
    // Start is called before the first frame update
    private void Start()
    {
        TextAsset csvData = Resources.Load<TextAsset>("SkillList");      //��ų ���� ���� ���� �Ľ�

        string[] data = csvData.text.Split(new char[] { '\n' });    //���� �������� �ɰ�
        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] == "")
                break;
            string[] skill = data[i].Split(',');            //�޸� �������� �ɰ�
       
            int[] speed = Array.ConvertAll((skill[2].Split('.')), int.Parse);
            int[] damage= Array.ConvertAll((skill[3].Split('.')), int.Parse);
            int[] radius= Array.ConvertAll((skill[4].Split('.')), int.Parse);
            int[] cooltime= Array.ConvertAll((skill[5].Split('.')), int.Parse);
            int[] count= Array.ConvertAll((skill[6].Split('.')), int.Parse);


            SkillInfo skillInfo = new SkillInfo(skill[0], skill[1], speed,damage,radius,cooltime,count, skill[7]);
            AllSkills.Add(skill[7], skillInfo);         //��� ��� ��ųʸ��� �߰�
        }

        foreach (var item in ChoiceSkills)
        {
            item.Btn.onClick.AddListener(()=> {         //��ư Ŭ�� �̺�Ʈ �߰�
                if (MySkills.ContainsKey(item.skillInfo.EngName))          //�ش� ��ų�� ������
                {
                    if (MySkills[item.skillInfo.EngName].level != 2)
                    {
                        MySkills[item.skillInfo.EngName].level += 1; //���� �߰�
                        MySkills[item.skillInfo.EngName].Speed = AllSkills[item.skillInfo.EngName].Speed[MySkills[item.skillInfo.EngName].level]; //���ǵ� ������Ʈ
                        MySkills[item.skillInfo.EngName].Damage = AllSkills[item.skillInfo.EngName].Damage[MySkills[item.skillInfo.EngName].level]; //������ ������Ʈ
                        MySkills[item.skillInfo.EngName].Radius = AllSkills[item.skillInfo.EngName].Radius[MySkills[item.skillInfo.EngName].level]; //���� ������Ʈ
                        MySkills[item.skillInfo.EngName].coolTime = AllSkills[item.skillInfo.EngName].CoolTime[MySkills[item.skillInfo.EngName].level]; //��Ÿ�� ������Ʈ
                        MySkills[item.skillInfo.EngName].count = AllSkills[item.skillInfo.EngName].Count[MySkills[item.skillInfo.EngName].level]; //���� ������Ʈ
                    }
                }
                else
                {
                    MySkills.Add(item.skillInfo.EngName,new SkillBase(item.skillInfo));         //���ο� ��ų �߰�

                }

            });
        }
        SkillLevelUp();

    }

    public void SkillLevelUp()
    {

        for (int i = 0; i < 3; i++)
        {
            string randNum;
            //��ų ���� ��
            do
            {
                int randSkill = Enum.GetNames(typeof(Skill)).Length;
                randNum = ((Skill)UnityEngine.Random.Range(0, randSkill)).ToString();

            } while (ChoiceSkills.Any(x => x.skillInfo.Name == AllSkills[randNum].Name));       //�ߺ� �ȵǰ�

            ChoiceSkills[i].skillInfo = AllSkills[randNum];

            //��ų ���� �ֱ�
            ChoiceSkills[i].skillNameText.text = AllSkills[randNum].Name;
            ChoiceSkills[i].skillInfoText.text = AllSkills[randNum].Info;

        }
    }
}
