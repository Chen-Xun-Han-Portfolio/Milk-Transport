using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjScript : MonoBehaviour
{
    public static ObjScript instance;
    //public bool reset = false;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
           //Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("OBSTACLES"))
        {
            Debug.Log("DESTROY");
            //GameManager.instance.reset = true;
            GameManager.instance.ResetArrowPos();
            GameManager.instance.nextLevel = 1;
            //DragInteraction.instance.resetPos();
            AudioManager.instance.milkDestroySound(AudioManager.instance.milkDestroy);
            GameManager.instance.gameEnd();
        }

        if (other.gameObject.name == "Panel_GOAL1")
        {
            Debug.Log("LEVEL 1 CLEAR");
            //GameManager.instance.reset = true;
            GameManager.instance.ResetArrowPos();
            GameManager.instance.nextLevel = 2;
            GameManager.instance.AddScore();
            spawnParticles();
            GameManager.instance.unablePick = false;
            GameManager.instance.levelPages2();
            //Destroy(gameObject);
            GameManager.instance.destroyProducts();
        }

        if (other.gameObject.name == "Panel_GOAL2")
        {
            Debug.Log("LEVEL 2 CLEAR");
            //GameManager.instance.reset = true;
            GameManager.instance.ResetArrowPos();
            GameManager.instance.nextLevel = 3;
            GameManager.instance.AddScore();
            spawnParticles();
            GameManager.instance.unablePick = false;
            GameManager.instance.levelPages3();
            //Destroy(gameObject);
            GameManager.instance.destroyProducts();
        }

        if (other.gameObject.name == "Panel_GOAL3")
        {
            Debug.Log("LEVEL 3 CLEAR");
            //GameManager.instance.reset = true;
            GameManager.instance.ResetArrowPos();
            GameManager.instance.AddScore();
            spawnParticles();
            GameManager.instance.gameEnd();
        }
    }


    public void spawnParticles()
    {
        if (GameManager.instance.gameIsReady == true)
        {
            GameObject par = Instantiate(GameManager.instance.parMilk, new Vector3(transform.localPosition.x, transform.localPosition.y, -6), Quaternion.identity);
            par.transform.SetParent(GameObject.Find("MILK_Spawn").transform, false);
            Destroy(gameObject);
        }
    }
}
