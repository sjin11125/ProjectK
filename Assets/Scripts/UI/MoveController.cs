using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    using UnityEngine.EventSystems;
public class MoveController : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    Vector3 FirstPos;
    RectTransform rect;

   public MCharacter character;
    bool isMove;

    public void OnBeginDrag(PointerEventData eventData)
    {
        FirstPos = transform.position;         //처음 위치 저장
        isMove = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // transform.localPosition = new Vector3(0,0,0);  //드래그 끝나면 원위치
        rect.anchoredPosition=new Vector3(0,0,0);
        isMove = false;
        character.MState = State.Idle;
    }


    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (isMove)
        {
            var JoystickDir = (FirstPos - Input.mousePosition).normalized;
            if (Mathf.Abs( (FirstPos - Input.mousePosition).magnitude)<100)
            {

                transform.position = Input.mousePosition;        //드래그 중 일땐 마우스 위치 따라가기
               
            }
            else
            {
                transform.position = FirstPos + JoystickDir * -100;
            }
            character.gameObject.transform.eulerAngles = new Vector3(0,Mathf.Atan2(-JoystickDir.x, -JoystickDir.y)*Mathf.Rad2Deg,0);
            character.MoveCharacter();

        }
    }

}
