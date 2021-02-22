using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragDrop : MonoBehaviour
{
    [SerializeField]
    private float deltaX, deltaY;
    public Transform movebleObject;
    private Vector2 dropPos;
 
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction, 100f);
          
            if (raycastHit2D.collider != null && raycastHit2D.transform.tag.Contains("drag")) 
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                if (touch.phase == TouchPhase.Began)
                {
                    movebleObject = raycastHit2D.transform;
                    Debug.Log(movebleObject.name + " clicked.");
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    movebleObject.transform.position = touchPos;
                    Debug.Log(movebleObject.name + " moving.");

                }
                else if (touch.phase == TouchPhase.Ended)
                {                
                    dropPos = GameObject.FindGameObjectWithTag(movebleObject.transform.tag).GetComponent<triggerControl>().dropPosition;
                    movebleObject.transform.position = dropPos; 
                    Debug.Log(movebleObject.name + " dropped.");
                }
            }
            
        }
               
    }
 
}
