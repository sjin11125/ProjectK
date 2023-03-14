using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MonsterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> MonsterPool;            //���� ������Ʈ Ǯ
    public GameObject MonsterPrefab;            //���� ������

    [SerializeField]
    int SpawnCount = 10;
    void Start()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            GameObject monster = Instantiate(MonsterPrefab,transform)as GameObject;
            monster.transform.localPosition = new Vector3(Random.Range(-5f,5f),0, Random.Range(-5f, 5f));
            MonsterPool.Add(monster);
        }
    }
    private void Update()
    {
        if (!MonsterPool.All(x => x.activeSelf) )
        { 
            MonsterSpawn();
        }
    }
    public void MonsterSpawn()
    {
        foreach (var item in MonsterPool)
        {
            if (!item.gameObject.activeSelf)            //Ȱ��ȭ �ȵǾ� ������
            {
                item.SetActive(true);           //Ȱ��ȭ
                item.transform.position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));     //��ġ ����
            }
        }
    }
}
