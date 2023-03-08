using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tornado_Warning : MonoBehaviour {
    public Text t;
    public GameObject tornado_warning;
    int i = 0;
    GameObject player;
    public GameObject tornado_prefab;
    float randomX;
    float randomZ;
    // Use this for initialization
    void Start () {
        StartCoroutine(Warning());
        player = GameObject.FindWithTag("kimrobot");
    }

    // Update is called once per frame
    void Update () {
        //t.text = i.ToString();
        randomX = Random.Range(player.transform.position.x + 30, player.transform.position.x - 30);//x축:플레이어 x좌표의 +-30 사이의 랜덤 값을 대입
        randomZ = Random.Range(player.transform.position.z + 40, player.transform.position.z - 40);//z축:플레이어 z좌표의 +-30사이의 랜덤 값을 대입


    }
    IEnumerator Warning()
    {
         //Instantiate(warning, new Vector3(randomX, 4.359f, randomZ), warning.transform.rotation);
        //warning.SetActive(true);
        for (i = 0; i < 3; i++)
        {
            tornado_warning.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            tornado_warning.SetActive(false);
            yield return new WaitForSeconds(0.5f);

        }
        Instantiate(tornado_prefab, new Vector3(tornado_warning.transform.position.x, tornado_warning.transform.position.y, tornado_warning.transform.position.z), tornado_prefab.transform.rotation);

        // Instantiate(tornado_prefab, new Vector3(tornado_warning.transform.position.x, tornado_warning.transform.position.y, tornado_warning.transform.position.z), tornado_prefab.transform.rotation);
        // tornado_prefab.SetActive(true);
        //  yield return new WaitForSeconds(4f);
        //  tornado_prefab.SetActive(false);
        //  ok = false;
    }
}
