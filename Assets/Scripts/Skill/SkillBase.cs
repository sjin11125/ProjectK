using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    string Name;
   public Skill SkillName;
    float Speed=3;
    float Damage;
    int level;
    int Radius = 1;

   public GameObject Player;
    // Start is called before the first frame update
    private void Update()
    {
        switch (SkillName)
        {
            case Skill.Basic:

                StartCoroutine(BasicCorountine());
                break;
            case Skill.Top:

                StartCoroutine(TopCorountine());
                break;
            case Skill.Shield:
                break;
            case Skill.FireBottle:
                break;
            case Skill.Thunder:
                break;
            default:
                break;
        }
    }
    

    IEnumerator BasicCorountine()       //기본 공격
    {
        while (true)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator TopCorountine()       //팽이 공격
    {
        int dir = 0;
        while (true)
        {
            //  transform.position = Player.transform.position +
            var x = Radius * Mathf.Cos(dir * Mathf.Deg2Rad);
            var z = Radius * Mathf.Sin(dir * Mathf.Deg2Rad);
            transform.localPosition = new Vector3(x, transform.localPosition.y, z);

                dir++;
            yield return null;
        }
    }
    private void Start()
    {
        Player = GameObject.Find("Player");

    }

}
