using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Linq;

public class ItemSpawner : MonoBehaviour
{
    //서버에서 정한 랜덤 시드를 바탕으로 아이템을 랜덤으로 생성(플레이어1,2 동일 위치에 생성되게)
    ReactiveProperty< int> randomSeed = new ReactiveProperty<int>();

    int[] XValue =new int[] { -51, 37 };
    int[] ZValue = new int[] { -53, 30 };
    int[] CenterXValue =new int[] { -28, 20 };
    int[] CenterZValue = new int[] { -27, 20 };


    public GameObject ItemPrefab;
    public GameObject ItemParent;
    [SerializeField]
    List<GameObject> ItemList = new List<GameObject>();

    public SkillManager skillManager;

    IObservable<long> TimerStream;
    void Start()
    {   //시드값으로 랜덤생성

        NetworkManager.Instance.RandomSeed.Subscribe((seed)=> {
           
            ItemObjSetting(seed);

        });


        NetworkManager.Instance.socket.Value.On("GetItem", (string index) => {      //아이템 비활성화 동기화

            index = index.Replace('"',' ').Trim();

            int i = int.Parse(index);
            ItemList[i].SetActive(false);
            //아이템 비활성화

            if (!ItemList.Any(x=>x.activeSelf))     //아이템 오브젝트가 활성화 되어 있는게 없다면(아이템 다 먹었다면)
                NetworkManager.Instance.ItemRespawn();  //아이템 리스폰 해야됨

        });

        NetworkManager.Instance.socket.Value.On("ItemRespawn", (string seed) => {      //아이템 비활성화 동기화

            ItemObjSetting(int.Parse(seed));
        });
    }
    public void ItemObjSetting(int seed)
    {
        Random.InitState(seed);
        for (int i = 0; i < 10; i++)
        {
            GameObject ItemObj;

            if (ItemList.Count != 10)           //아이템이 다 할당되어 있지 않을 때
            {
                ItemObj = Instantiate(ItemPrefab, ItemParent.transform) as GameObject;
                ItemList.Add(ItemObj);
            }
            else
            {
                //if (!ItemList.Any(x=>x.activeSelf))         //다 할당되었는데 다 비활성화 되었으면?
                ItemObj = ItemList[i];
          

            }


            do
            {
                ItemObj.transform.localPosition = new Vector3(Random.Range(XValue[0], XValue[1]), 8, Random.Range(ZValue[0], ZValue[1]));

            } while ((ItemObj.transform.localPosition.x <= 20 && ItemObj.transform.localPosition.x >= -20) ||
            (ItemObj.transform.localPosition.z <= 20 && ItemObj.transform.localPosition.z >= -27));

            ItemObj.SetActive(true);            //아이템 활성화

            ItemObj.OnTriggerEnterAsObservable().Subscribe((other) =>
            {
                if (other.CompareTag(NetworkManager.Instance.player.ToString()))            //유저가 아이템에 닿으면
                {
                    NetworkManager.Instance.GetItem(ItemList.IndexOf(ItemObj));     //닿은 아이템 인덱스 전송
                    ItemList[ItemList.IndexOf(ItemObj)].SetActive(false);

                    skillManager.GetReward();
                }

            });

        }
           
        
    }


}
