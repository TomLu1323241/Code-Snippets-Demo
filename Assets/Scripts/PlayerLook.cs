using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    Vector3 mouse_pos;
    Transform target;
    Vector3 object_pos;
    float angle;
    Rigidbody2D body;
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        target = this.transform;
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f;
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        body.MoveRotation(angle);
    }
}
