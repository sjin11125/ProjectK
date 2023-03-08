using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour {
    GameObject end;

    public Text t;
	// Use this for initialization
	void Start () {
        //gameObject.SetActive(true);

        //this.transform.parent = end.transform;
        //this.transform.localPosition = Vector3.zero;
        end = GameObject.Find("end");
	}
	
	// Update is called once per frame
	void Update () {
        // transform.Translate(end.transform.position);
        // transform.position = Vector3.MoveTowards(transform.position,Vector3(end.transform.position.x, end.transform.position.y, end.transform.position.z),3f);
        //transform.LookAt(end.transform);
        // transform.Translate(new Vector3(0, -Time.deltaTime * 5, 0), Space.Self);
        //GetComponent<Rigidbody>().AddForce(-transform.right * 100);
        //GetComponent<Rigidbody>().AddForce(end.transform.position.x, end.transform.position.y, end.transform.position.z);
        //  Vector3 dir = (end.transform.position);
        // GetComponent<Transform>().transform.Translate(new Vector3(end.transform.position.x,
        //  end.transform.position.y, end.transform.position.z) );
        // this.transform.position = Vector3.Lerp(/*new Vector3(Gun_Control.bulpos.position.x, Gun_Control.bulpos.position.y, Gun_Control.bulpos.position.z)*/
        //new Vector3(0,0,0), new Vector3(end.transform.position.x, end.transform.position.y, end.transform.position.z), 1f);
       
        /*if (transform.position==end.transform.position)
        {
            Destroy(gameObject);
        }
        else
        {*/
            transform.position = Vector3.MoveTowards(transform.position, end.transform.position, 4);
        //}
        
        float distance= Vector3.Distance(end.transform.position, transform.position);
        // t.text = distance.ToString();
        Debug.Log(distance);
        if (end.transform.position==transform.position)
        {
            Destroy(this.gameObject);
        }
    }
    /*void OnTriggerEnter(Collider other)
    {
        if (other==end)
        {
            Destroy(this.gameObject);
        }
        
        
    }*/
}
