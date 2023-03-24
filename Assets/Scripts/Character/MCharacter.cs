using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCharacter : MonoBehaviour
{
    // Start is called before the first frame update
   public  float Speed = 5;
    public float Hp;        //체력
    public float Mp;

    public State MState;
    Animator MAnimator;

    public GameObject Target;
    public GameObject AttackPrefab;
    public GameObject AttackPos;

    public float Distance=10;

    public bool isAuto;     //자동 이동인지
    public virtual void Start()
    {
        MAnimator = GetComponent<Animator>();
        isAuto = true;
    }
    public virtual void Update()
    {

        switch (MState)
        {
            case State.Idle:
                MAnimator.SetBool("isRun", false);
                break;
            case State.Move:
                MAnimator.SetBool("isRun",true);
                MAnimator.SetBool("isAttack", false);


             //   MoveCharacter();        //캐릭터 이동 함수

                break;
            case State.Attack:
                MAnimator.SetBool("isAttack",true);
                break;
            case State.Skill:
                break;
            default:
                break;
        }
    }
    public void MoveCharacter()
    {
        if (Target!=null)
        {
            if ((Target.transform.position - transform.position).magnitude > Distance)
            {
              
                    transform.LookAt(Target.transform);


                    transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
                
             
            }
            else
            {
                  transform.LookAt(Target.transform);

                MState = State.Attack;      //공격 상태로 전환
            }
        }
        else
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            MState = State.Move;
        }
  
    

    }

    public void Attack()        //공격 애니메이션에서 사용될 이벤트 함수
    {
      //  GameObject AttackObj = Instantiate(AttackPrefab) as GameObject;         //공격 프리팹 생성
      //  AttackObj.transform.position = AttackPos.transform.position ;

    }
  /*  public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Item"))
        {
            NetworkManager.Instance.GetItem();
        }
    }*/
}
