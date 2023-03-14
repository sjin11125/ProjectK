using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
     GameObject Player;
    float Distance;         //일정 거리 이하면 공격
    void Start()
    {
        Player = GameObject.Find("Sparrow");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        if ((Player.transform.position-gameObject.transform.position).magnitude>Distance)
        {
            //공격
        }
    }
}
