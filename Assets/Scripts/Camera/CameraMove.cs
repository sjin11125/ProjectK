using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    public float cameraSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        var dir = Player.transform.position - transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        //this.transform.Translate(moveVector);
        transform.position = Player.transform.position+new Vector3(-1,9,-12);
    }
}
