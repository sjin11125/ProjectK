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
    public float Radius ;
    public int coolTime;
    public int count ;      //����

    public GameObject[] Prefabs;
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


    public void SetSkillInfo(SkillInfo skillInfo)
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

    private void OnEnable()
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
                StartCoroutine(ThunderCorountine());
                break;
            default:

                StartCoroutine(BasicCorountine());
                break;
        }
    }
    private void Start()
    {
        
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
            for (int i = 0; i < count; i++)
            {
                Prefabs[i].SetActive(true);
                int deg = dir + (i * (360 / count));            //������ �°� ���� ����
                var x = Radius * Mathf.Cos(deg * Mathf.Deg2Rad);         //x ���ϱ�
                var z = Radius* Mathf.Sin(deg * Mathf.Deg2Rad);        //y ���ϱ�
                Prefabs[i].transform.localPosition = new Vector3((float)x, transform.localPosition.y, (float)z);

                dir++;

            }
        
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
    IEnumerator ThunderCorountine()       //���� ����
    {
        List<GameObject> ThunderObjPool=new List<GameObject> ();

      
            if (ThunderObjPool.Count == 0)
            {
                GameObject ThunderObj = Instantiate(Prefabs[0], null) as GameObject;

                ThunderObjPool.Add(ThunderObj);     //������Ʈ Ǯ�� �߰�
                Vector3 pos = ThunderObj.transform.position;
                ThunderObj.transform.position = new Vector3(pos.x+Random.Range(-10,10),pos.y,
                                                            pos.z + Random.Range(-10, 10)); //������ġ ����
            }
            else
            {
               
                    GameObject ThunderObj = ThunderObjPool.Find(x => x.activeSelf == false);
                if (ThunderObj==null)
                {
                    ThunderObj = Instantiate(Prefabs[0], null) as GameObject;

                    ThunderObjPool.Add(ThunderObj);     //������Ʈ Ǯ�� �߰�
                }
                else
                {

                }
            }

            yield return new WaitForSeconds(coolTime);
        
    }

}
