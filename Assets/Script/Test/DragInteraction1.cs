using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInteraction1 : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 startPosition;
    [SerializeField] private RectTransform startPos;

    private GameObject dropPlace_GO;
    private Vector3 dropPlacePosition;

    [SerializeField] private bool isCorrectPlace = false;
    public bool resetPos = false;


    void Start()
    {
        //dropPlacePosition = dropPlace_GO.GetComponent<RectTransform>().position;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //startPosition = this.gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }

    private void OnMouseDrag()
    {
        //Debug.Log("can drag");
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        this.transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        if(isCorrectPlace == true)
        {
            this.gameObject.transform.position = dropPlacePosition;
        }
        else
        {
            this.gameObject.transform.position = startPos.GetComponent<RectTransform>().position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ArrowPlace"))
        {
            Debug.Log("Drag inside");
            dropPlacePosition = other.GetComponent<RectTransform>().position;
            isCorrectPlace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ArrowPlace"))
        {
            Debug.Log("Drag out");
            isCorrectPlace = false;
        }
    }
}
