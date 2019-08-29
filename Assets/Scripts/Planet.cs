using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    [SerializeField] float radius = 4;
    [SerializeField] float gravityScale = 1;
    [SerializeField] Sprite circle;
    [SerializeField] Color32 radiusColor;

    private void Start()
    {
        GameObject createVisableRadius = new GameObject();
        createVisableRadius.AddComponent<SpriteRenderer>().sprite = circle;
        createVisableRadius.GetComponent<SpriteRenderer>().color = radiusColor;
        createVisableRadius.transform.localScale = Vector3.one * radius * 2;
        createVisableRadius.transform.position = this.transform.position;
        createVisableRadius.transform.SetParent(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] inField = Physics2D.OverlapCircleAll(this.transform.position, radius);
        foreach (Collider2D col in inField)
        {
            Debug.Log(inField.Length);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Mathf.Clamp(radius / Vector3.Distance(this.transform.position, col.transform.position), 1, 10) * Vector3.Normalize(this.transform.position - col.transform.position) * gravityScale);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
