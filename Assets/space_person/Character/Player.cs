using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

    float rotSpeed = 12.0f;
    public Camera main;

    void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			if (Input.GetKey ("w")) {
				anim.SetInteger ("AnimationPar", 1);
			}  else {
				anim.SetInteger ("AnimationPar", 0);
			}

			if(controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;

       // Rotctrl();
		}
    
    void Rotctrl()
    {
        Vector3 rot = transform.rotation.eulerAngles;   // ���� ������Ʈ�� ������ Vector3�� ��ȯ

        rot.y += Input.GetAxis("Mouse X") * rotSpeed; //���콺�� X��ġ * ȸ�����ǵ�
        //rot.x += Input.GetAxis("Mouse Y") * 5;   //���콺�� Y��ġ * ȸ�����ǵ�

        Quaternion q = Quaternion.Euler(rot);   //Quaternion���� ��ȯ
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);   //�ڿ������� ȸ��
    }
}
