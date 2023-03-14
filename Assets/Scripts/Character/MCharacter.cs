using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    float Speed = 10;

    public State MState;
    Animator MAnimator;
    void Start()
    {
        MAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        switch (MState)
        {
            case State.Idle:
                MAnimator.SetBool("isRun", false);
                break;
            case State.Move:
                MAnimator.SetBool("isRun",true);
                break;
            case State.Attack:
                break;
            case State.Skill:
                break;
            default:
                break;
        }
    }
    public void MoveCharacter()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        MState = State.Move;

    }
}
