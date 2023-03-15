using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    public Skill SkillName;

    public string Name;
    public float Speed;
    public float Damage;
    public int level;
    public int Radius ;
    public int coolTime;
    public int count ;      //°¹¼ö

    public SkillBase(SkillInfo skillInfo)
    {
        Name = skillInfo.Name;
        Speed = skillInfo.Speed[0];
        Damage = skillInfo.Damage[0];
        this.level = 0;
        Radius = skillInfo.Radius[0];
        this.coolTime = skillInfo.CoolTime[0];
        this.count = skillInfo.Count[0];
    }



    //public SkillInfo skillInfo;

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
    

    IEnumerator BasicCorountine()       //±âº» °ø°Ý
    {
        while (true)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator TopCorountine()       //ÆØÀÌ °ø°Ý
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
    IEnumerator BombCorountine()       //ÆøÅº °ø°Ý
    {
        while (true)
        {
            //  transform.position = Player.transform.position +
          
            yield return new WaitForSeconds(coolTime);
        }
    }
    private void Start()
    {
      //  Player = GameObject.Find("Player");

    }

}
