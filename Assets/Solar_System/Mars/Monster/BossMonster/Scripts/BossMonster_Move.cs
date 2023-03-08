using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMonster_Move : MonoBehaviour {
    CharacterController controller;
    Animator anim;
    public float velocity;
    Vector3 direction;
    public Transform target;
    public Text t;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("kimrobot").transform;
    }

    // Update is called once per frame
    void Update () {
        Move();
        
    }
    void Move()
    {
        direction = (target.position - transform.position).normalized;
        // r.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed), Space.Self);
        velocity = (0.1f * Time.deltaTime / 1.2f);
        float distance = Vector3.Distance(target.position, transform.position);
         t.text = distance.ToString();
        if (distance <= 19f && distance >= 7f && anim.GetBool("death") == false)
        {
            anim.SetBool("attack", false);
            anim.SetBool("run", true);
            //Debug.Log("이동");
            transform.LookAt(target);
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity * 20),
                                                  transform.position.y + (direction.y * velocity * 20),
                                                  transform.position.z + (direction.z * velocity * 20));


        }
        else if (distance < 7f)
        {
            Debug.Log("공격!");
            velocity = 0;
            anim.SetBool("attack", true);
            if (BossMonster_Control.health<=0)
            {
                anim.SetBool("death",true);
            }
            // StartCoroutine(Attack());
        }
      /*  else if (anim.GetBool("death") == true)
        {
            StartCoroutine(Death());
        }*/
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("attack", false);
            // anim.SetInteger("AnimationPar", 1);
            velocity = 0;
        }

    }
    /*IEnumerator Death()
    {

        velocity = 0;
        // anim.SetBool("death", true);
        yield return new WaitForSeconds(1.5f);
        //Monster_Control.death = true;
        //Monster_Control.monster_kill += 1;
        Destroy(this.gameObject);


    }*/
}
