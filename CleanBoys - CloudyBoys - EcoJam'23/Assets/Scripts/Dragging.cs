using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    //private float dist;
    //private bool dragging = false;
    //private Vector3 offset;
    //private Transform toDrag;

    //void Update()
    //{

    //    Vector3 v3;

    //    if (Input.touchCount != 1)
    //    {
    //        dragging = false;
    //        return;
    //    }

    //    Touch touch = Input.touches[0];
    //    Vector3 pos = touch.position;

    //    if (touch.phase == TouchPhase.Began)
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(pos);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            if (hit.collider.tag == "Garbage")
    //            {
    //                Debug.Log("Hit collider garbage");

    //                toDrag = hit.transform;

    //                Debug.Log("to drag: " + toDrag);

    //                dist = hit.transform.position.z - Camera.main.transform.position.z;
    //                v3 = new Vector3(pos.x, pos.y, 0);
    //                v3 = Camera.main.ScreenToWorldPoint(v3);
    //                offset = toDrag.position - v3;
    //                dragging = true;
    //            }
    //        }
    //    }

    //    if (dragging && touch.phase == TouchPhase.Moved)
    //    {
    //        v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    //        v3 = Camera.main.ScreenToWorldPoint(v3);
    //        toDrag.position = v3 + offset;
    //    }

    //    if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
    //    {
    //        dragging = false;
    //    }
    //}

    // ========================================================================



    //private Vector3 touchPosition;
    //private Rigidbody2D rb;
    //private Vector3 direction;
    //private float moveSpeed = 10f;

    //private void Start()
    //{
    //    //rb = GetComponent<Rigidbody2D>();
    //}

    //private void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.touches[0];
    //        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

    //        Debug.Log("touch position: " + touchPosition);

    //        Vector3 pos = touch.position;

    //        Debug.Log("pos: " + pos);

    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            Debug.Log("touch phase began: ");


    //            Ray ray = Camera.main.ScreenPointToRay(pos);
    //            RaycastHit hit;

    //            Debug.DrawRay(touchPosition, pos, Color.red, 5);

    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                Debug.Log("raycast hit : ");

    //                if (hit.collider.tag == "Garbage")
    //                {
    //                    Debug.Log("raycast hit garbage: ");

    //                    rb = hit.transform.gameObject.GetComponent<Rigidbody2D>();

    //                    touchPosition.z = 0;
    //                    direction = (touchPosition - transform.position);
    //                    rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

    //                    if (touch.phase == TouchPhase.Ended)
    //                        rb.velocity = Vector2.zero;
    //                }
    //            }
    //        }
    //    }
    //}



    // ============================================================================


    //private bool isDragging;

    //public void OnMouseDown()
    //{
    //    isDragging = true;
    //}

    //public void OnMouseUp()
    //{
    //    isDragging = false;
    //}

    //void Update()
    //{
    //    if (isDragging)
    //    {
    //        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //        transform.Translate(mousePosition);
    //    }
    //}





    //// ============================================================================


    //// SAHI BUT NOT SO SAHI


    float deltaX, deltaY;

    Rigidbody2D rb;

    bool moveAllowed = false;
    private PauseMenu Ps;

    public GameObject PauseMenuManager;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ps = PauseMenuManager.GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ps.IsPaused == false)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                //Debug.Log("TOuchInput");


                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        //Debug.Log("TOuchphaseBegin");
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        {
                            deltaX = touchPos.x - transform.position.x;
                            deltaY = touchPos.y - transform.position.y;
                            moveAllowed = true;
                            rb.velocity = new Vector2(0, 0);
                        }
                        break;

                    case TouchPhase.Moved:
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                            rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                        break;

                    case TouchPhase.Ended:
                        moveAllowed = false;
                        break;

                }
            }
        }

    }



    // ====================================================================


    // ============================================================================


    // EXPERIMENT


    //float deltaX, deltaY;

    //Rigidbody2D rb;

    //bool moveAllowed = false;

    //// Use this for initialization
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
    //        Vector3 pos = touch.position;

    //        Debug.Log("pos: " + pos);
    //        Debug.Log("touchpos: " + touchPos);

    //        switch (touch.phase)
    //        {
    //            case TouchPhase.Began:
    //                //touchPos = new Vector2(touchPos.x +)
    //                Debug.Log("touch phase began: ");


    //                Ray rayy = Camera.main.ScreenPointToRay(pos);
    //                RaycastHit hit;

    //                if (Physics.Raycast(rayy, out hit))
    //                {
    //                    if (hit.collider.tag == "Garbage")
    //                    {
    //                        Debug.Log("Hit collider garbage");

    //                        //toDrag = hit.transform;

    //                        //Debug.Log("to drag: " + toDrag);

    //                        //dist = hit.transform.position.z - Camera.main.transform.position.z;

    //                        //if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
    //                        //{
    //                            deltaX = touchPos.x - transform.position.x;
    //                            deltaY = touchPos.y - transform.position.y;
    //                            moveAllowed = true;
    //                            rb.velocity = new Vector2(0, 0);
    //                        //}
    //                    }
    //                }
    //                break;

    //            case TouchPhase.Moved:
    //                if (/*GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) &&*/ moveAllowed)
    //                    rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
    //                break;

    //            case TouchPhase.Ended:
    //                moveAllowed = false;
    //                break;

    //        }
    //    }
    //}


}