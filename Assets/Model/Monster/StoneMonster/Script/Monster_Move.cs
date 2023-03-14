using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Move : MonoBehaviour {
    public Transform target;
    
    Rigidbody r;
    Vector3 direction;
    public float velocity;
    float speed = 2;

    //float health = 100;     //체력

    public GameObject attack;
    public Transform monpos;

    public Text t;

    Animator anim;
    // Use this for initialization
    void Start() {
        r = GetComponent<Rigidbody>();
        // anim = this.gameObject.transform.parent.parent.GetComponent<Animator>();
        anim = this.gameObject.transform.GetComponent<Animator>();
        target = GameObject.FindWithTag("kimrobot").transform;
    }

    // Update is called once per frame
    void Update() {
        Move();
    
        
    }

    void Move()
    {
        

        

        direction = (target.position - transform.position).normalized;
        // r.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed), Space.Self);
        velocity = ( 0.1f * Time.deltaTime/1.2f);
        float distance = Vector3.Distance(target.position,transform.position);
       // t.text = distance.ToString();
        if (distance<=19f&&distance>=5f&& anim.GetBool("death") == false)
        {
            anim.SetBool("attack", false);
            anim.SetBool("run", true);
            Debug.Log("이동");
            transform.LookAt(target);
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity*12),
                                                  transform.position.y + (direction.y * velocity*12),
                                                  transform.position.z + (direction.z * velocity*12));
            
          
        }
        else if(distance<5f)
        {
            velocity = 0;
            anim.SetBool("attack", true);
            // StartCoroutine(Attack());
        }
        else if (anim.GetBool("death")==true)
        {
            StartCoroutine(Death());
        }
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("attack", false);
            // anim.SetInteger("AnimationPar", 1);
            velocity = 0;
        }

    }

    void OnTriggerEnter(Collider other)
    {
      /*  if (other.tag == "bullet")
        {
            health -= 10;
        }
       /* if (other.tag=="kimrobot")
        {
            Player_control.health -= 1;
        }*/

    }
    IEnumerator Death()
    {
        
        velocity = 0;
        yield return new WaitForSeconds(1.5f);
        Monster_Control.monster_kill += 1;
        Destroy(this.gameObject);
        

    }

    IEnumerator Attack()
    {
        //Instantiate(attack, monpos.transform.position, monpos.transform.rotation);
        anim.SetBool("attack",true);
        yield return new WaitForSeconds(3f);
       

    }
}
