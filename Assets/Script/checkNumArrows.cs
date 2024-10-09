using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkNumArrows : MonoBehaviour
{
    public static checkNumArrows instance;
    public int numArrows = 0;
    public bool checkArrow = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numArrows == 0)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }

        if (numArrows == 2)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            numArrows = 0;
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Arrows"))
        {
            numArrows += 1;
        }
    }
}
