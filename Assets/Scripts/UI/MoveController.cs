using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    using UnityEngine.EventSystems;
using UniRx;
public class MoveController : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    Vector3 FirstPos;
    RectTransform rect;

   public MCharacter character;
   public MCharacter Othercharacter;

    public GameObject[] Characters;
    bool isMove;

    public SkillManager skillManager;
    public void OnBeginDrag(PointerEventData eventData)
    {
        FirstPos = transform.position;         //ó�� ��ġ ����
        isMove = true;
        character.isAuto = false;       //�ڵ��̵� false
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // transform.localPosition = new Vector3(0,0,0);  //�巡�� ������ ����ġ
        rect.anchoredPosition=new Vector3(0,0,0);
        isMove = false;
        character.MState = State.Idle;
        character.isAuto = true;            //�ڵ��̵� true
    }


    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        switch (NetworkManager.Instance.player)
        {
            case PlayerName.Player1:
                character = Characters[0].GetComponent<MCharacter>();
                Othercharacter= Characters[1].GetComponent<MCharacter>();
                break;

            case PlayerName.Player2:
                character = Characters[1].GetComponent<MCharacter>();
                Othercharacter = Characters[0].GetComponent<MCharacter>();

                break;

            default:
                break;
        }
        NetworkManager.Instance.OtherCharacterMove.Subscribe((movePosDir)=> {
            if (NetworkManager.Instance.IsOtherCharacterMove.Value)
            MoveOtherPlayer(movePosDir.Dir, movePosDir.Pos);


        });
    }
    private void Update()
    {
        if (isMove)
        {
            var JoystickDir = (FirstPos - Input.mousePosition).normalized;
            if (Mathf.Abs( (FirstPos - Input.mousePosition).magnitude)<100)
            {

                transform.position = Input.mousePosition;        //�巡�� �� �϶� ���콺 ��ġ ���󰡱�
               
            }
            else
            {
                transform.position = FirstPos + JoystickDir * -100;
            }
            Move(JoystickDir);      //�ش� �������� �̵�

        }
    }
    public void Move(Vector3 JoystickDir)
    {
        character.gameObject.transform.eulerAngles = new Vector3(0, Mathf.Atan2(-JoystickDir.x, -JoystickDir.y) * Mathf.Rad2Deg, 0);
        character.Target = null;
        character.MState = State.Move;


        character.transform.Translate(Vector3.forward * character.Speed * Time.deltaTime);

        NetworkManager.Instance.MovePlayer(JoystickDir, character.transform.position);
    }
    public void MoveOtherPlayer (Vector3 JoystickDir,Vector3 Pos)
    {
        Debug.Log(Pos);
        Othercharacter.gameObject.transform.eulerAngles = new Vector3(0, Mathf.Atan2(-JoystickDir.x, -JoystickDir.y) * Mathf.Rad2Deg, 0);
        Othercharacter.Target = null;
        Othercharacter.MState = State.Move;

        Othercharacter.transform.transform.position = Pos;
    }

}
