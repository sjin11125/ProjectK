using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

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

    public PlayerName Owner;

    public GameObject[] Prefabs;
    IDisposable triggerStream;
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
    public void SetSkillInfo(SkillInfo skillInfo,int level)
    {
        Name = skillInfo.Name;
        Speed = skillInfo.Speed[level];
        Damage = skillInfo.Damage[level];
        this.level = level;
        Radius = skillInfo.Radius[level];
        this.coolTime = skillInfo.CoolTime[level];
        this.count = skillInfo.Count[level];
    }
    /*public void SetSkillInfo(int level)
    {
        //Name = skillInfo.Name;
        Speed = skillInfo.Speed[0];
        Damage = skillInfo.Damage[0];
        this.level = 0;
        Radius = skillInfo.Radius[0];
        this.coolTime = skillInfo.CoolTime[0];
        this.count = skillInfo.Count[0];
    }*/
    //public SkillInfo skillInfo;

    // Start is called before the first frame update

    private void OnEnable()
    {
      
       
        switch (SkillName)
        {
            case Skill.Top:
                OnTriggerSubscribe((int)Damage);
                StartCoroutine(TopCorountine());
                break;
            case Skill.Shield:
                OnTriggerStaySubscribe((int)Damage);
                StartCoroutine(ShiledCoroutine());
                break;
            case Skill.Bomb:
            //    OnTriggerSubscribe((int)Damage);
                break;
            case Skill.Thunder:
             //   OnTriggerSubscribe((int)Damage);
                StartCoroutine(ThunderCorountine());
                break;
            default:
                OnTriggerSubscribe((int)Damage);
                StartCoroutine(BasicCorountine());
                break;
        }
        
    }
    public void OnTriggerStaySubscribe(int damage)
    {
        triggerStream = gameObject.OnTriggerStayAsObservable().Subscribe(other=> {

            switch (Owner)          //�ڱⰡ ������ �� �ȸ���
            {
                case PlayerName.Player1:
                    if (other.tag.Equals(PlayerName.Player2.ToString()))
                    {
                        NetworkManager.Instance.Attack(damage);
                        gameObject.SetActive(false);

                    }
                    break;

                case PlayerName.Player2:
                    if (other.tag.Equals(PlayerName.Player1.ToString()))
                    {
                        NetworkManager.Instance.Attack(damage);
                        gameObject.SetActive(false);

                    }
                    break;
                default:
                    break;
            }
        });
    }
    public void OnTriggerSubscribe(int damage)
    {


       triggerStream =   gameObject.OnTriggerEnterAsObservable().Subscribe(other => {
            switch (Owner)          //�ڱⰡ ������ �� �ȸ���
            {
                case PlayerName.Player1:
                    if (other.tag.Equals(PlayerName.Player2.ToString()))
                    {
                        NetworkManager.Instance.Attack(damage);
                        gameObject.SetActive(false);
                   
                    }
                    break;

                case PlayerName.Player2:
                    if (other.tag.Equals(PlayerName.Player1.ToString()))
                    {
                        NetworkManager.Instance.Attack(damage);
                        gameObject.SetActive(false);
                     
                    }
                    break;
                default:
                    break;
            }
            //skillManager.OtherDamaged(damage);      //�ٸ� �÷��̾� HP �ݿ�
        }).AddTo(gameObject);

    }

    public void OnDisable()
    {
        triggerStream.Dispose();
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
    IEnumerator ShiledCoroutine()
    {
        Vector3 ShiledScale = gameObject.transform.localScale;
        while (true)
        {


            // Prefabs[0].SetActive(true);
            gameObject.transform.localScale = new Vector3(ShiledScale.x + Radius + 1, ShiledScale.y, ShiledScale.z + Radius + 1);

            yield return null;
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
                ThunderObj.transform.position = new Vector3(pos.x+ UnityEngine.Random.Range(-10,10),pos.y,
                                                            pos.z + UnityEngine.Random.Range(-10, 10)); //������ġ ����
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
