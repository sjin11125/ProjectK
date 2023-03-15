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
    int coolTime = 5;
    int count = 1;      //����
    int range = 5;      //����

   public GameObject Player;
    // Start is called before the first frame update
    private void Update()
    {
        switch (SkillName)
        {
            case Skill.Top:

                StartCoroutine(TopCorountine());
                break;
            case Skill.Shield:
                break;
            case Skill.Bomb:
                break;
            case Skill.Thunder:
                break;
            default:

                StartCoroutine(BasicCorountine());
                break;
        }
    }
    

    IEnumerator BasicCorountine()       //�⺻ ����
    {
        while (true)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator TopCorountine()       //���� ����
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
    IEnumerator BombCorountine()       //��ź ����
    {
        while (true)
        {
            //  transform.position = Player.transform.position +
          
            yield return new WaitForSeconds(coolTime);
        }
    }
    private void Start()
    {
        Player = GameObject.Find("Player");

    }

}
