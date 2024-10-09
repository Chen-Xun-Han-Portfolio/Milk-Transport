using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInteraction : MonoBehaviour
{
    public static DragInteraction instance;

    private Vector3 screenPoint;
    private Vector3 startPosition;
    [SerializeField] private RectTransform startPos;

    private GameObject dropPlace_GO;
    private Vector3 dropPlacePosition;

    public bool isCorrectPlace = false;
    //public bool resetPos = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //destroy(gameobject);
        }
    }

    void Start()
    {
        //dropPlacePosition = dropPlace_GO.GetComponent<RectTransform>().position;
//StartCoroutine("resetE");
    }

    void Update()
    {
        //if (GameManager.instance.reset == true)
        //{
        //    //this.gameObject.transform.position = startPos.GetComponent<RectTransform>().position;
        //    //isCorrectPlace = false;
        //    //ObjScript.instance.reset = false;
        //    //resetPos();
        //    StartCoroutine("resetE");
        //}
        //resetPos();
    }

    private void OnMouseDown()
    {
        //startPosition = this.gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }

    private void OnMouseDrag()
    {
        if(GameManager.instance.gameIsReady == true && GameManager.instance.unablePick == false)
        {
            //Debug.Log("can drag");
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            this.transform.position = curPosition;
        }
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

    //IEnumerator resetE()
    //{

    //    if (GameManager.instance.reset == true)
    //    {
    //        this.gameObject.transform.position = startPos.GetComponent<RectTransform>().position;
    //        isCorrectPlace = false;
    //        Debug.Log("Reset");
    //        //yield return new WaitForSeconds(0.1f);
    //        GameManager.instance.reset = false;
    //        yield return null;
    //        //break;
    //    }

    //    //while (ObjScript.instance.reset == true)
    //    //{
    //    //    this.gameObject.transform.position = startPos.GetComponent<RectTransform>().position;
    //    //    isCorrectPlace = false;
    //    //    yield return new WaitForSeconds(0f);
    //    //    ObjScript.instance.reset = false;
    //    //    Debug.Log("Reset");
    //    //    yield return null;
    //    //}

    //    //while (resetPos == true)
    //    //{
    //    //    this.gameObject.transform.position = startPos.GetComponent<RectTransform>().position;
    //    //    Debug.Log("Reset");
    //    //    yield return new WaitForSeconds(1f);
    //    //    resetPos = false;
    //    //    yield return null;
    //    //}

    //    //yield return null;
    //}


    //public void resetPos()
    //{
    //    //StartCoroutine("resetE");

    //    //if (GameManager.instance.reset == true)
    //    //{
    //    //    this.gameObject.transform.position = startPos.GetComponent<RectTransform>().position;
    //    //    isCorrectPlace = false;
    //    //    Debug.Log("Reset");
    //    //    GameManager.instance.reset = false;
    //    //}

    //    this.gameObject.transform.position = startPos.GetComponent<RectTransform>().position;
    //    isCorrectPlace = false;
    //    GameManager.instance.reset = false;
    //    Debug.Log("Reset");
    //    //GameManager.instance.reset = false;
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ArrowPlace"))
        {
            //Debug.Log("Drag inside");
            dropPlacePosition = other.GetComponent<RectTransform>().position;
            isCorrectPlace = true;
        }

        //if (other.gameObject.CompareTag("Arrows"))
        //{
        //    this.gameObject.transform.position = startPos.GetComponent<RectTransform>().position;
        //    //isCorrectPlace = false;
        //    if (dropPlacePosition == other.GetComponent<RectTransform>().position)
        //    {
        //        this.gameObject.transform.position = startPos.GetComponent<RectTransform>().position;
        //    }
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ArrowPlace"))
        {
            //Debug.Log("Drag out");
            isCorrectPlace = false;
        }
    }

    //public void reset()
    //{
    //    isCorrectPlace = false;
    //    this.gameObject.transform.position = startPos.GetComponent<RectTransform>().position;
    //}
}
