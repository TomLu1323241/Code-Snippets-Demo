using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    Vector3 touchStart;

    [SerializeField] float verticalBound = 5;
    [SerializeField] float horizontalBound = 5;

    Vector3 origin;


    private void Start()
    {
        origin = this.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position += direction;
        }
        Bounds();
    }

    void Bounds()
    {
        float vertical = Camera.main.orthographicSize;
        float horizontal = vertical * Camera.main.aspect;
        if ((this.transform.position + vertical * Vector3.up).y > (origin + (vertical + verticalBound) * Vector3.up).y)
        {
            this.transform.position = new Vector3(this.transform.position.x, origin.y + verticalBound, this.transform.position.z);
        }
        if ((this.transform.position - vertical * Vector3.up).y < (origin - (vertical + verticalBound) * Vector3.up).y)
        {
            this.transform.position = new Vector3(this.transform.position.x, origin.y - verticalBound, this.transform.position.z);
        }
        if ((this.transform.position - horizontal * Vector3.right).x < (origin - (horizontal + horizontalBound) * Vector3.right).x)
        {
            this.transform.position = new Vector3(origin.x - horizontalBound, this.transform.position.y, this.transform.position.z);
        }
        if ((this.transform.position + horizontal * Vector3.right).x > (origin + (horizontal + horizontalBound) * Vector3.right).x)
        {
            this.transform.position = new Vector3(origin.x + horizontalBound, this.transform.position.y, this.transform.position.z);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 origin = Vector3.zero;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(origin, new Vector3(Camera.main.orthographicSize * Camera.main.aspect * 2 + horizontalBound * 2, Camera.main.orthographicSize * 2 + verticalBound * 2, 10));
    }
}
