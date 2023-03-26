using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using socket.io;
using UniRx;

public class SkillManager : MonoBehaviour
{
    [SerializeField]
    List<SkillInfoUI> ChoiceSkills = new List<SkillInfoUI>();

    public Dictionary<string, SkillInfo> AllSkills = new Dictionary<string, SkillInfo>();        //모든 기술 정보
    public Dictionary<string, SkillBase> MySkills = new Dictionary<string, SkillBase>();            //현재 플레이어가 가지고 있는 스킬들

    [SerializeField]
    List<GameObject> SkillPrefab;

    public GameObject SkillLevelUpPopUp;

    public KPlayer Player;
    public KPlayer OtherPlayer;

    public Slider ExpSlider;
    public Slider HpSlider;
    public Slider OtherHpSlider;

    public float Exp;
    public int HP=100;
    public int OtherHP=100;
    // Start is called before the first frame update
    private void Start()
    {
        ExpSlider.maxValue = 100;
        ExpSlider.minValue = 0;

        


        TextAsset csvData = Resources.Load<TextAsset>("SkillList");      //스킬 정보 엑셀 파일 파싱

        string[] data = csvData.text.Split(new char[] { '\n' });    //엔터 기준으로 쪼갬
        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] == "")
                break;
            string[] skill = data[i].Split(',');            //콤마 기준으로 쪼갬
       
            int[] speed = Array.ConvertAll((skill[2].Split('*')), int.Parse);
            int[] damage= Array.ConvertAll((skill[3].Split('*')), int.Parse);
            float[] radius= Array.ConvertAll((skill[4].Split('*')), float.Parse);
            int[] cooltime= Array.ConvertAll((skill[5].Split('*')), int.Parse);
            int[] count= Array.ConvertAll((skill[6].Split('*')), int.Parse);


            SkillInfo skillInfo = new SkillInfo(skill[0], skill[1], speed,damage,radius,cooltime,count, skill[7]);
            AllSkills.Add(skill[7], skillInfo);         //모든 기술 딕셔너리에 추가
        }

        foreach (var item in ChoiceSkills)
        {
            item.Btn.onClick.AddListener(()=> {         //버튼 클릭 이벤트 추가
                if (MySkills.ContainsKey(item.skillInfo.EngName))          //해당 스킬이 있으면
                {
                    if (MySkills[item.skillInfo.EngName].level != 2)
                    {
                        MySkills[item.skillInfo.EngName].level += 1; //레벨 추가
                        MySkills[item.skillInfo.EngName].Speed = AllSkills[item.skillInfo.EngName].Speed[MySkills[item.skillInfo.EngName].level]; //스피드 업데이트
                        MySkills[item.skillInfo.EngName].Damage = AllSkills[item.skillInfo.EngName].Damage[MySkills[item.skillInfo.EngName].level]; //데미지 업데이트
                        MySkills[item.skillInfo.EngName].Radius = AllSkills[item.skillInfo.EngName].Radius[MySkills[item.skillInfo.EngName].level]; //범위 업데이트
                        MySkills[item.skillInfo.EngName].coolTime = AllSkills[item.skillInfo.EngName].CoolTime[MySkills[item.skillInfo.EngName].level]; //쿨타임 업데이트
                        MySkills[item.skillInfo.EngName].count = AllSkills[item.skillInfo.EngName].Count[MySkills[item.skillInfo.EngName].level]; //개수 업데이트
                   
                    }
                }
                else                //해당 스킬이 없으면
                {
                    GameObject skill = SkillPrefab.Find(x => x.GetComponent<SkillBase>().SkillName.ToString() == item.skillInfo.EngName);

                    GameObject skillPrefab = Instantiate(skill, Player.Skillpos.transform) as GameObject;
                   // skillPrefab.transform.localPosition

                    SkillBase skillObjSkillBase=skillPrefab.GetComponent<SkillBase>();

                    skillObjSkillBase.SetSkillInfo( item.skillInfo);            //스킬 정보 세팅
                    //skillObjSkillBase.skillManager = this;

                    MySkills.Add(item.skillInfo.EngName, skillObjSkillBase);         //새로운 스킬 추가

                }

                NetworkManager.Instance.SkillUpdate(MySkills[item.skillInfo.EngName].SkillName.ToString(), MySkills[item.skillInfo.EngName].level.ToString());
                //서버에 스킬 정보 전달

                SkillLevelUpPopUp.SetActive(false);     //팝업창 끄기
                //Player.SkillUpdate(MySkills[item.skillInfo.EngName]);           //스킬 업데이트

            });
  

        }

        // SkillLevelUp();
        NetworkManager.Instance.socket.Value.On("SkillUpdate",(string skill)=> {            //다른 플레이어 스킬 업데이트

            SkillInfos skillInfo = JsonUtility.FromJson<SkillInfos>(skill);
            GameObject skillObj = SkillPrefab.Find(x => x.GetComponent<SkillBase>().SkillName.ToString() == skillInfo.SkillName);

            GameObject skillPrefab = Instantiate(skillObj, OtherPlayer.Skillpos.transform) as GameObject;

        });
        NetworkManager.Instance.socket.Value.On("Attacked",(string attack)=> {            //공격받았다

            AttackInfo attackInfo = JsonUtility.FromJson<AttackInfo>(attack);

            if (attackInfo.PlayerName!=NetworkManager.Instance.player.ToString())       //내 캐릭터가 공격받은거라면?
            {
                HP -= int.Parse(attackInfo.Damage);
                HpSlider.value = HP;
            }
            else     //내 캐릭터가 공격받은게 아니라면
            {
                OtherHP -= int.Parse(attackInfo.Damage);
                OtherHpSlider.value = OtherHP;
               
            }
        });
    }
    public void OtherDamaged(int damage)
    {
       
    }
    public void GetReward()
    {
        Exp += 10;
        ExpSlider.value = Exp;
        if (Exp>=100)
        {
            Exp = 0;
            SkillLevelUp();
        }
    }
    public void SkillLevelUp()
    {
        SkillLevelUpPopUp.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            string randNum;
            //스킬 랜덤 고름
            do
            {
                int randSkill = Enum.GetNames(typeof(Skill)).Length;
                randNum = ((Skill)UnityEngine.Random.Range(0, randSkill)).ToString();

            } while (ChoiceSkills.Any(x => x.skillInfo.Name == AllSkills[randNum].Name));       //중복 안되게

            ChoiceSkills[i].skillInfo = AllSkills[randNum];

            //스킬 정보 넣기
            ChoiceSkills[i].skillNameText.text = AllSkills[randNum].Name;
            ChoiceSkills[i].skillInfoText.text = AllSkills[randNum].Info;

        }
    }
}
