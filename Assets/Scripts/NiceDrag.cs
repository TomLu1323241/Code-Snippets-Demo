using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiceDrag : MonoBehaviour
{
    private void OnMouseDown()
    {
        StartCoroutine(FollowMouse());
    }

    public IEnumerator FollowMouse()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        Vector3 offset = this.transform.position - Camera.main.ScreenToWorldPoint(mousePos);
        while (Input.GetMouseButton(0))
        {
            mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = objectPos + offset;
            yield return new WaitForEndOfFrame();
        }
    }
}
