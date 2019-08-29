using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapToCenterDrag : MonoBehaviour
{
    [SerializeField] UnityEvent OnClick;
    [SerializeField] UnityEvent OnDrag;
    [SerializeField] UnityEvent OnDragEnded;

    private void OnMouseDown()
    {
        StartCoroutine(FollowMouse());
    }

    public IEnumerator FollowMouse()
    {
        //before drag
        OnClick.Invoke();
        while (Input.GetMouseButton(0))// While Mouse is held down change the food's position to mouse
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            //during drag
            OnDrag.Invoke();
            transform.position = objectPos;
            yield return new WaitForEndOfFrame();
        }
        OnDragEnded.Invoke();
        //end of drag
    }

}
