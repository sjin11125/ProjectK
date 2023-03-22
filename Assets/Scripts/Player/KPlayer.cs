using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KPlayer : MCharacter
{
    // Start is called before the first frame update
    [SerializeField]
    List<MonsterSpawner> MonsterSpawn;

    public float Exp;

    public GameObject Skillpos;

    public override void Update()
    {
        if (transform.CompareTag(NetworkManager.Instance.player.ToString()))
        {
            base.Update();


            TargetCheck();
        }
 
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

    public void Reward(float Exp)            //���� ���̰� ����ޱ�
    {
        this.Exp += Exp;
        if (this.Exp>=100)
        {
            this.Exp = 0;
            GameManager.Instance.SkillLevelUp();
        }
    }

    public void SkillUpdate(SkillBase skill)       //��ų ������Ʈ
    {
      
    }
}
