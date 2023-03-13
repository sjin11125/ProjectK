using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    float Speed = 10;
    void Start()
    {
        
    }
  public void MoveCharacter(MoveDir dir)
    {
        switch (dir)
        {
            case MoveDir.Right:
                transform.Translate(Vector3.right* Speed * Time.deltaTime,Space.World);
                break;
            case MoveDir.Left:
                transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
                break;
            case MoveDir.Up:
                transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.World);
                break;
            case MoveDir.Down:
                transform.Translate(Vector3.back * Speed * Time.deltaTime, Space.World);
                break;
            default:
                break;
        }
    }
}
