using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class EarthSpinScript : MonoBehaviour {
    public float speed = 10f;
    public GameObject panel;

    void Update() {
        transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="spaceship")
        {
            //SceneManager.LoadScene("base");
            panel.SetActive(true);  //기지로 돌아갈 것인지 물음
            Time.timeScale = 0;     //일시정지
        }
    }
}