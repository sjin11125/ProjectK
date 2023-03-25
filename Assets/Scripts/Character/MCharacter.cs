using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MCharacter : MonoBehaviour
{
    // Start is called before the first frame update
   public  float Speed = 5;
    public float Hp;        //ü��
    public float Mp;

    public State MState;
    Animator MAnimator;

    public GameObject Target;
    public GameObject AttackPrefab;
    public GameObject AttackPos;

    public float Distance=10;

    public bool isAuto;     //�ڵ� �̵�����

    List<GameObject> AttakObjPool=new List<GameObject> ();      //���� ������Ʈ Ǯ
    public virtual void Start()
    {
        MAnimator = GetComponent<Animator>();
        isAuto = true;

        StartCoroutine(Attack());           //���� �ڷ�ƾ
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


             //   MoveCharacter();        //ĳ���� �̵� �Լ�

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

                MState = State.Attack;      //���� ���·� ��ȯ
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

        
            if (AttackObj == null)                //������Ʈ Ǯ�� Ȱ��ȭ�Ȱ� ������
            {
                AttackObj = Instantiate(AttackPrefab) as GameObject;         //���� ������ ����
                AttakObjPool.Add(AttackObj);            //��ġ ����

                
            }
            AttackObj.transform.eulerAngles = gameObject.transform.eulerAngles;     //���� ������ ���� ����(ĳ���Ͱ� �ٶ󺸴� ������ )

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
