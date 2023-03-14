using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    float Speed = 5;

    public State MState;
    Animator MAnimator;

    public GameObject Target;

    public float Distance=10;

    public bool isAuto=true;     //자동 이동인지
    void Start()
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


                MoveCharacter();

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
                    Debug.Log("Target Check" + (Target.transform.position - transform.position).magnitude);
                
             
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

    public void Attack()
    {
        MState = State.Attack;
    }
}
