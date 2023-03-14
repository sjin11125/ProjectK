using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster_Control : MonoBehaviour {
    Animator anim;
    public static int health = 250;
    public static bool boss_death = false;
    public GameObject slider;

    public GameObject key;

	// Use this for initialization
	void Start () {
        anim = transform.GetComponent<Animator>();
        slider.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            health = 0;
            StartCoroutine(Death());
           
            //StartCoroutine(Death());

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="bullet")
        {
            health -= 10;
           
           
        }
    }
    IEnumerator Death()
    {
        Debug.Log("죽음");
        anim.SetBool("death", true);
        yield return new WaitForSeconds(5f);

        Instantiate(key, this.gameObject.transform.position,Quaternion.identity);

        boss_death = true;
        this.transform.gameObject.SetActive(false);

    }
}
