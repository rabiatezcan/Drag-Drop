using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    [SerializeField]
    private Transform dropPos;
    private Vector2 initialPos;
    GameObject[] players;
    GameObject[] dropPlayers; 
    private float deltaX, deltaY;
    public int locked;
    GameObject dragObject;
    void Start()
    {
        initialPos = transform.position;
        players = GameObject.FindGameObjectsWithTag("Player");
        dropPlayers = GameObject.FindGameObjectsWithTag("drop");
    }

    void Update()
    {
        if (Input.touchCount > 0 && locked < 3)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            for (int i = 0; i < players.Length; i++)
            {
                if(Mathf.Abs(players[i].transform.position.x - touchPos.x) < 2f && Mathf.Abs(players[i].transform.position.y - touchPos.y) < 2f)
                {
                    dragObject = players[i];
                    dropPos = dropPlayers[i].transform;
                }
            }
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - dragObject.transform.position.x;
                        deltaY = touchPos.y - dragObject.transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        dragObject.transform.position = new Vector2((touchPos.x - deltaX), (touchPos.y - deltaY));
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(dragObject.transform.position.x - dropPos.position.x) <= 0.5f && Mathf.Abs(dragObject.transform.position.y - dropPos.position.y) <= 0.5f)
                    {
                        dragObject.transform.position = dropPos.position;
                        locked++;
                    }
                    else
                    {
                        dragObject.transform.position = initialPos;
                    }
                    break;
            }
        }
        else if (Input.touchCount > 0 && locked > 0)
        {
            Touch touchBack = Input.GetTouch(0);
            Vector2 touchBackPos = Camera.main.ScreenToWorldPoint(touchBack.position);
            for (int i = 0; i < players.Length; i++)
            {
                if (Mathf.Abs(players[i].transform.position.x - touchBackPos.x) < 2f && Mathf.Abs(players[i].transform.position.y - touchBackPos.y) < 2f)
                {
                    dragObject = players[i];
                    dropPos = dropPlayers[i].transform;
                }
            }
            switch (touchBack.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchBackPos))
                    {
                        deltaX = touchBackPos.x - dragObject.transform.position.x;
                        deltaY = touchBackPos.y - dragObject.transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchBackPos))
                    {
                        dragObject.transform.position = new Vector2((touchBackPos.x - deltaX), (touchBackPos.y - deltaY));
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(dragObject.transform.position.x - dropPos.position.x) <= 0.5f && Mathf.Abs(dragObject.transform.position.y - dropPos.position.y) <= 0.5f)
                    {
                        dragObject.transform.position = dropPos.position;
                    }
                    else
                    {
                        dragObject.transform.position = initialPos;
                        locked--;

                    }
                    break;
            }
        }

    }
}
