using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KPlayer : MCharacter
{
    // Start is called before the first frame update
    [SerializeField]
    List<MonsterSpawner> MonsterSpawn;

 

    public Dictionary<string, SkillInfo> MySkills = new Dictionary<string, SkillInfo>();            //���� �÷��̾ ������ �ִ� ��ų��
    public override void Update()
    {
        base.Update();


        TargetCheck();
    }

    public void TargetCheck()
    {
        if (MState != State.Attack&&
            isAuto)           //���� ���� �ƴϰ� �ڵ� �̵��̶��
        {
            foreach (var spawner in MonsterSpawn)
            {
                if (Target == null)
                {
                    foreach (var item in spawner.MonsterPool)
                    {
                        if (item.activeSelf)
                        {
                            Target = item;
                            MState = State.Move;

                      
                            break;
                        }
                    }
                }
                
            }
        }
    }
}
