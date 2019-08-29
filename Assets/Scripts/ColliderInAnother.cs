using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInAnother : MonoBehaviour
{

    Vector3 initalLoc;
    [SerializeField] Collider2D[] placementOptions;

    void Start()
    {
        initalLoc = this.transform.position;
    }

    private void OnMouseDown()
    {
        StartCoroutine(FollowMouse());
    }

    public IEnumerator FollowMouse()
    {
        while (Input.GetMouseButton(0))// While Mouse is held down change the food's position to mouse
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = objectPos;
            yield return new WaitForEndOfFrame();
        }
        if (!checkLocation())
        {
            this.transform.position = initalLoc;
        }
    }
    bool checkLocation()
    {
        int traversal = 0;
        for (int i = 0; i < placementOptions.Length; i++)
        {
            int count = 0;
            var points = this.GetComponent<PolygonCollider2D>().points;
            for (int j = 0; j < points.Length; j++)
            {
                if (placementOptions[i].OverlapPoint((Vector2)this.transform.position + points[j]))
                {
                    count++;
                }
            }
            Debug.Log(count);
            if (count == points.Length)
            {
                break;
            }
            else
            {
                traversal++;
            }
        }
        if (traversal == placementOptions.Length)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
