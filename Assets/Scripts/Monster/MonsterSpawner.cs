using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MonsterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> MonsterPool;            //몬스터 오브젝트 풀
    public GameObject MonsterPrefab;            //몬스터 프리팹

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
            if (!item.gameObject.activeSelf)            //활성화 안되어 있으면
            {
                item.SetActive(true);           //활성화
                item.transform.position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));     //위치 랜덤
            }
        }
    }
}
