using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ItemSpawner : MonoBehaviour
{
    //서버에서 정한 랜덤 시드를 바탕으로 아이템을 랜덤으로 생성(플레이어1,2 동일 위치에 생성되게)
    int randomSeed = 0;

    int[] XValue =new int[] { -51, 37 };
    int[] ZValue = new int[] { -53, 30 };
    int[] CenterXValue =new int[] { -28, 20 };
    int[] CenterZValue = new int[] { -27, 20 };


    public GameObject ItemPrefab;
    public GameObject ItemParent;
    [SerializeField]
    List<GameObject> ItemList = new List<GameObject>();

    public SkillManager skillManager;
    void Start()
    {   //시드값으로 랜덤생성

        /*NetworkManager.Instance.RandomSeed.Subscribe((seed)=> {
           
            ItemObjSetting(seed);

        });*/
        ItemObjSetting(NetworkManager.Instance.RandomSeed.Value);

        NetworkManager.Instance.socket.Value.On("GetItem", (string index) => {

//Debug.Log("아이템 획득");
            index = index.Replace('"',' ').Trim();
            Debug.Log("아이템 획득 "+ index);
            int i = int.Parse(index);
            ItemList[i].SetActive(false);
        });
    }
    public void ItemObjSetting(int seed)
    {
        Random.InitState(seed);
        for (int i = 0; i < 10; i++)
        {
            GameObject ItemObj = Instantiate(ItemPrefab, ItemParent.transform) as GameObject;
            do
            {

                ItemObj.transform.localPosition = new Vector3(Random.Range(XValue[0], XValue[1]), 8, Random.Range(ZValue[0], ZValue[1]));
            } while ((ItemObj.transform.localPosition.x <= 20 && ItemObj.transform.localPosition.x >= -20) ||
            (ItemObj.transform.localPosition.z <= 20 && ItemObj.transform.localPosition.z >= -27));

            ItemList.Add(ItemObj);

            ItemObj.OnTriggerEnterAsObservable().Subscribe((other) =>
            {
                if (other.CompareTag(NetworkManager.Instance.player.ToString()))            //유저가 아이템에 닿으면
                {
                    NetworkManager.Instance.GetItem(ItemList.IndexOf(ItemObj));     //닿은 아이템 인덱스 전송
                   // ItemList[ItemList.IndexOf(ItemObj)].SetActive(false);

                    skillManager.GetReward();
                }

            });

        }
           
        
    }

}
