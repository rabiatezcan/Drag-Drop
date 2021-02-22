using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerControl : MonoBehaviour
{
    Vector2 initialPos;
    public Vector2 dropPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = gameObject.transform.position; 
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.transform.tag.Contains(col.transform.tag))
        {
            dropPosition = col.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        dropPosition = initialPos;
    }
}
