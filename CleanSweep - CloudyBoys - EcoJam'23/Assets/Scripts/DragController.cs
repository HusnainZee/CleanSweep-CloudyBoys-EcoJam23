using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _WorldPosition;
    private Draggable _LastDragged;

    private void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_isDragActive)
        {
            if ((Input.GetMouseButtonDown(0)) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                Drop();
                return;
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 MousePos = Input.mousePosition;
            _screenPosition = new Vector2(MousePos.x, MousePos.y);
        }
        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _WorldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);
        
        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_WorldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _LastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        _isDragActive = true;
    }

    private void Drag()
    {
        if (_LastDragged)
        {
            _LastDragged.transform.position = new Vector2(_WorldPosition.x, _WorldPosition.y);
        }
    }

    void Drop()
    {
        _isDragActive = false;
    }
}
