using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UniRx;

public class KPlayer : MCharacter
{
    // Start is called before the first frame update
    [SerializeField]
    List<MonsterSpawner> MonsterSpawn;

    public float Exp;

    public GameObject Skillpos;

    public override void Start()
    {
        base.Start();
        NetworkManager.Instance.Funcs.Subscribe((func)=> {
            switch (func)
            {
                case Func.GetItem:

                    break;

                default:
                    break;
            }

        });
    }
    public override void Update()
    {
        if (transform.CompareTag(NetworkManager.Instance.player.ToString()))
        {
            base.Update();


            //TargetCheck();
        }
 
    }

    public void TargetCheck()
    {
        if (MState != State.Attack&&
            isAuto)           //공격 중이 아니고 자동 이동이라면
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
