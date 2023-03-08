using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_Ending : MonoBehaviour {
    public GameObject fadeout;
    public static bool earth = false;
    public static bool nyang = false;
    public void To_Nyeang_Ending()
    {
        nyang = true;
        fadeout.SetActive(true);
        StartCoroutine(Ending());
        
    }
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("ending");
    }
    public void To_Earth_Ending()
    {
        earth = true;
        fadeout.SetActive(true);
        StartCoroutine(Ending());
    }
}
