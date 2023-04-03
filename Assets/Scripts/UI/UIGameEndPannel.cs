using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using socket.io;
using UniRx;
using UnityEngine.SceneManagement;

public class UIGameEndPannel : MonoBehaviour
{
    public GameObject PlayerBlue;
    public GameObject PlayerRed;
    public GameObject GameEndPannel;

    public Button GoMainBtn;        //����ȭ������ ���� ��ư

    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.socket.Value.On("GameEnd",(string name) => {

            Time.timeScale = 0;     //�Ͻ�����
            name = name.Replace('"',' ').Trim();
            GameEndPannel.SetActive(true);
            if (name.Equals("Player1"))         //�÷��̾� ��簡 �̰��
            {
                PlayerBlue.SetActive(true);

            }
            else                //�÷��̾� ���尡 �̰��
            {
                PlayerRed.SetActive(true);
            }
        });

        GoMainBtn.OnClickAsObservable().Subscribe(_ => {
            Time.timeScale = 1;     //�Ͻ����� ��

            SceneManager.LoadScene("Main");

        });
    }

}
