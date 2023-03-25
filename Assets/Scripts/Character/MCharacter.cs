using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

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

    List<GameObject> AttakObjPool=new List<GameObject> ();      //공격 오브젝트 풀
    public virtual void Start()
    {
        MAnimator = GetComponent<Animator>();
        isAuto = true;

        StartCoroutine(Attack());           //공격 코루틴
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

    public IEnumerator Attack()       
    {
        while (true)
        {
            GameObject AttackObj = AttakObjPool.Find(x => x.activeSelf == false);

        
            if (AttackObj == null)                //오브젝트 풀에 활성화된게 없으면
            {
                AttackObj = Instantiate(AttackPrefab) as GameObject;         //공격 프리팹 생성
                AttakObjPool.Add(AttackObj);            //위치 설정

                
            }
            AttackObj.transform.eulerAngles = gameObject.transform.eulerAngles;     //공격 프리팹 각도 설정(캐릭터가 바라보는 쪽으로 )

            Observable.EveryUpdate().Where(_ => (AttackObj.transform.position - transform.position).magnitude >= 50).Subscribe(_ => {
                AttackObj.SetActive(false);

            }).AddTo(AttackObj);

            AttackObj.transform.position = AttackPos.transform.position;


            yield return new WaitForSeconds(3f);

        }

    }
  /*  public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Item"))
        {
            NetworkManager.Instance.GetItem();
        }
    }*/
}
