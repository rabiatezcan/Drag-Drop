using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerControl : MonoBehaviour
{
    Vector2 initialPos;
    Vector2 dropPos; 
    bool isTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = gameObject.transform.position; 
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.transform.tag.Contains(col.transform.tag) && !col.transform.tag.Contains("drag"))
        {
            dropPos = col.transform.position; 
            isTrigger = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (gameObject.transform.tag.Contains(col.transform.tag) && !col.transform.tag.Contains("drag"))
        {
            isTrigger = false;
        }
    }

    public void moveToPosition()
    {
        if (isTrigger)
        {
            gameObject.transform.position = dropPos;
        }
        else
        {
            gameObject.transform.position = initialPos; 
        }
    }
}
