using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //GAME PAGES
    [Header("GAME PAGES")]
    [SerializeField] private int currentPage;
    [SerializeField] private GameObject[] pages;
    [SerializeField] private bool pageAnim;
    //[SerializeField] private GameObject blackTrans;

    //MAIN MENU"
    [Header("MAIN MENU")]
    [Space(25)]
    [SerializeField] private GameObject imageTruck;

    //INSTRUCTION PAGE
    [Header("INSTRUCTION PAGE")]
    [Space(25)]
    [SerializeField] private GameObject productExp;
    //[SerializeField] private GameObject boxExp;
    public int curPageIns;
    public GameObject[] pagesIns;
    bool pageAnimIns;
    //public bool waitPageIns;

    //GAME START
    [Header("GAME START")]
    [Space(25)]
    public bool gameIsReady;
    [SerializeField] private Text countdownText;
    [SerializeField] private GameObject imageTop;
    [SerializeField] private GameObject imageBtm;

    //LEVEL
    [Header("LEVEL")]
    [Space(15)]
    public GameObject[] LevelPages;
    public int nextLevel;
    public bool reset = false;

    //PRODUCT
    [Header("MILK PRODUCT")]
    [Space(15)]
    public GameObject milkObj;
    [SerializeField] private GameObject spawnParent;
    public int curSpawnNum;

    public GameObject parMilk;

    //SPAWN OBJECT TIME COUNTDOWN
    [Header("SPAWN OBJECT TIME COUNTDOWN")]
    [Space(15)]
    [SerializeField] private Text countdownGameText;
    [SerializeField] private float timeLeft;
    [SerializeField] private float totalTime;
    [SerializeField] private bool startCount;

    //ARROW
    [Header("ARROW")]
    [Space(15)]
    [SerializeField] private GameObject[] arrowList;
    [SerializeField] private RectTransform[] startPos;
    //public bool resetPos = false;
    public bool unablePick = false;

    //NUM LEVEL CLEAR
    [Header("NUM LEVEL CLEAR")]
    [Space(15)]
    public int numLevel = 0;
    [SerializeField] private Text totalLevelText;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private Text endPanelText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameIsReady = false;
        StartCoroutine("mainMenuE");
    }

    void Update()
    {

    }

    IEnumerator mainMenuE()
    {
        while(true)
        {
            imageTruck.GetComponent<RectTransform>().anchoredPosition = new Vector2(3, 7);
            yield return new WaitForSeconds(0.4f);
            imageTruck.GetComponent<RectTransform>().anchoredPosition = new Vector2(-3, -7);
            yield return new WaitForSeconds(0.4f);
        }
    }

    public void GoToPage(int pageNum)
    {
        if (!pageAnim)
        {
            StartCoroutine("GoToPageE", pageNum);
        }
    }

    IEnumerator GoToPageE(int pageNum)
    {
        pageAnim = true;
        if (pageNum == 0)
        {
            ResetGame();
        }
        if (pageNum == 1)
        {
            //parEffect.SetActive(false);
            StopCoroutine("ResetGameE");
            StartCoroutine("InstructionPage");
        }
        if (pageNum == 2)
        {
            StartCoroutine("GameStart");
            Debug.Log("Start Game");
        }

        //BLACK TRANS START
        //blackTrans.SetActive(true);
       //blackTrans.GetComponent<RectTransform>().DOScale(new Vector3(7, 7, 1), 1);

        //CHANGE PAGES
        //yield return new WaitForSeconds(1);
        pages[currentPage].GetComponent<RectTransform>().DOAnchorPosY(1920, 1);
        //pages[currentPage].GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), 1);
        pages[pageNum].GetComponent<RectTransform>().anchoredPosition = new Vector2(1920, 0);
        pages[pageNum].gameObject.SetActive(true);
        pages[pageNum].GetComponent<RectTransform>().DOAnchorPosX(0, 1);
        yield return new WaitForSeconds(1);
        //pages[currentPage].GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 1);
        pages[currentPage].gameObject.SetActive(false);

        //BLACK TRANS END
        //blackTrans.GetComponent<RectTransform>().DOScale(new Vector3(0f, 0f, 1), 1);
        //yield return new WaitForSeconds(1);
        //blackTrans.SetActive(false);

        currentPage = pageNum;
        pageAnim = false;
    }

    IEnumerator InstructionPage()
    {
        while (true)
        {
            //boxExp.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0);
            //productExp.GetComponent<RectTransform>().anchoredPosition = new Vector2(-86, -85);
            //productExp.GetComponent<RectTransform>().DOAnchorPosX(68, 1);
            yield return new WaitForSeconds(1);
            //boxExp.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, -0.5f, 1), 0.5f, 6, 1);
            //yield return new WaitForSeconds(1);
            //yield return null;
        }
    }

    public void pageIns(int pageNumIns)
    {
        if (!pageAnimIns)
        {
            StartCoroutine("InstructionPageE", pageNumIns);
        }
    }

    IEnumerator InstructionPageE(int pageNumIns)
    {
        //pageAnimIns = true;

        if (pageNumIns == 0)
        {
            pageIns1();
        }
        if (pageNumIns == 1)
        {
            pageIns2();
        }
        if (pageNumIns == 2)
        {
            pageIns3();
        }

        if (pageNumIns == 3)
        {
            pageIns4();
        }

        //pageAnimIns = false;
        yield return null;
    }

    public void pageIns1()
    {
        //pagesIns[0].gameObject.SetActive(true);

        pagesIns[0].GetComponent<RectTransform>().DOAnchorPosY(0, 1);
        pagesIns[1].GetComponent<RectTransform>().DOAnchorPosY(-1920, 1);

        //StartCoroutine("InstructionPageWaitSecE");

        //if (waitPageIns == true)
        //{
        //    pagesIns[1].gameObject.SetActive(false);
        //    waitPageIns = false;
        //    //StopCoroutine("InstructionPageWaitSecE");
        //}
    }

    public void pageIns2()
    {
        //pagesIns[1].gameObject.SetActive(true);
       
        pagesIns[1].GetComponent<RectTransform>().DOAnchorPosY(0, 1);
        pagesIns[0].GetComponent<RectTransform>().DOAnchorPosY(1920, 1);
        pagesIns[2].GetComponent<RectTransform>().DOAnchorPosY(-1920, 1);

        //StartCoroutine("InstructionPageWaitSecE");

        //if (waitPageIns == true)
        //{
        //    pagesIns[0].gameObject.SetActive(false);
        //    pagesIns[2].gameObject.SetActive(false);
        //    //waitPageIns = false;
        //    //StopCoroutine("InstructionPageWaitSecE");
        //}
    }

    public void pageIns3()
    {
        //pagesIns[2].gameObject.SetActive(true);

        pagesIns[2].GetComponent<RectTransform>().DOAnchorPosY(0, 1);
        pagesIns[1].GetComponent<RectTransform>().DOAnchorPosY(1920, 1);
        pagesIns[3].GetComponent<RectTransform>().DOAnchorPosY(-1920, 1);

        //StartCoroutine("InstructionPageWaitSecE");

        //if (waitPageIns == true)
        //{
        //    pagesIns[1].gameObject.SetActive(false);
        //    pagesIns[3].gameObject.SetActive(false);
        //    waitPageIns = false;
        //    //StopCoroutine("InstructionPageWaitSecE");
        //}
    }

    public void pageIns4()
    {
        //pagesIns[3].gameObject.SetActive(true);

        pagesIns[3].GetComponent<RectTransform>().DOAnchorPosY(0, 1);
        pagesIns[2].GetComponent<RectTransform>().DOAnchorPosY(1920, 1);

        //StartCoroutine("InstructionPageWaitSecE");

        //if (waitPageIns == true)
        //{
        //    pagesIns[2].gameObject.SetActive(false);
        //    waitPageIns = false;
        //    //StopCoroutine("InstructionPageWaitSecE");
        //}
    }

    //IEnumerator InstructionPageWaitSecE()
    //{
    //    yield return new WaitForSeconds(1f);
    //    waitPageIns = true;
    //    Debug.Log("wait");
    //}

    public void pageInsReset()
    {
        //pagesIns[0].gameObject.SetActive(true);
        //pagesIns[1].gameObject.SetActive(false);
        //pagesIns[2].gameObject.SetActive(false);
        //pagesIns[3].gameObject.SetActive(false);

        pagesIns[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        pagesIns[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1920);
        pagesIns[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1920);
        pagesIns[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1920);
    }


    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1);

        //Countdown to Start Game 
        countdownText.gameObject.SetActive(true);
        countdownText.text = "Ready";
        AudioManager.instance.countDownReady(AudioManager.instance.countReady);
        yield return new WaitForSeconds(2);
        countdownText.text = "Go";
        AudioManager.instance.countDownGo(AudioManager.instance.countGo);
        yield return new WaitForSeconds(1);
        gameIsReady = true;

        StartCoroutine("totalScoreE");
        countdownText.gameObject.SetActive(false);
    }
 
    public void milkSpawn1()
    {
        if(curSpawnNum < 1 && gameIsReady == true)
        {
            startCount = true;
            Vector2 staringPos = new Vector2(-108, -86);
            GameObject obj1 = Instantiate(milkObj, staringPos, Quaternion.identity);
            obj1.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0);
            obj1.transform.SetParent(GameObject.Find("MILK_Spawn").transform, false);
            curSpawnNum += 1;
            //AudioManager.instance.spawnMilkSound(AudioManager.instance.spawnMilk);
            StartCoroutine("countdownGameE");
        }
    }

    public void milkSpawn2()
    {
        if (curSpawnNum < 1 && gameIsReady == true)
        {
            startCount = true;
            Vector2 staringPos = new Vector2(120, -140);
            GameObject obj2 = Instantiate(milkObj, staringPos, Quaternion.identity);
            obj2.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0);
            obj2.transform.SetParent(GameObject.Find("MILK_Spawn").transform, false);
            curSpawnNum += 1;
            //AudioManager.instance.spawnMilkSound(AudioManager.instance.spawnMilk);
            StartCoroutine("countdownGameE");
        }
    }

    public void milkSpawn3()
    {
        if (curSpawnNum < 1 && gameIsReady == true)
        {
            startCount = true;
            Vector2 staringPos = new Vector2(0, 0);
            GameObject obj3 = Instantiate(milkObj, staringPos, Quaternion.identity);
            obj3.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0);
            obj3.transform.SetParent(GameObject.Find("MILK_Spawn").transform, false);
            curSpawnNum += 1;
            //AudioManager.instance.spawnMilkSound(AudioManager.instance.spawnMilk);
            StartCoroutine("countdownGameE");
        }
    }

    IEnumerator countdownGameE()
    {
        timeLeft = totalTime;

        while (startCount == true)
        {
            //countdownGameText.text = "Time:\n" + timeLeft.ToString("00");
            timeLeft -= 1 * Time.deltaTime;
            unablePick = true;

            if (timeLeft <= 0)
            {
                AudioManager.instance.milkDestroySound(AudioManager.instance.milkDestroy);
                gameEnd();
                //startCount = false;
                Debug.Log("TIME OUT");
            }

            yield return null;
        }

        unablePick = false;
    }
        
    //IEnumerator NextLevelE()
    //{
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(0f);

    //        if (nextLevel == 1)
    //        {
    //            LevelPages[0].SetActive(true);
    //            LevelPages[2].SetActive(false);
    //            curSpawnNum = 0;
    //            //Debug.Log("Level 1");
    //            //break;
    //        }

    //        if (nextLevel == 2)
    //        {
    //            LevelPages[1].SetActive(true);
    //            LevelPages[0].SetActive(false);
    //            curSpawnNum = 0;
    //            //Debug.Log("Level 2");
    //            //break;
    //        }

    //        if (nextLevel == 3)
    //        {
    //            LevelPages[2].SetActive(true);
    //            LevelPages[1].SetActive(false);
    //            curSpawnNum = 0;
    //            gameEnd();
    //            //Debug.Log("Level 3");
    //            //break;
    //        }

    //        //yield return null;
    //    }
        
    //}

    public void levelPages1()
    {
        LevelPages[0].SetActive(true);
        LevelPages[1].SetActive(false);
        LevelPages[2].SetActive(false);
        StopCoroutine("countdownGameE");
        curSpawnNum = 0;
        Debug.Log("Level 1");
    }

    public void levelPages2()
    {
        LevelPages[1].SetActive(true);
        LevelPages[0].SetActive(false);
        StopCoroutine("countdownGameE");
        curSpawnNum = 0;
        Debug.Log("Level 2");
    }

    public void levelPages3()
    {
        LevelPages[2].SetActive(true);
        LevelPages[1].SetActive(false);
        StopCoroutine("countdownGameE");
        curSpawnNum = 0;
        Debug.Log("Level 3");
    }

    public void AddScore()
    {
        AudioManager.instance.milkGoalSound(AudioManager.instance.milkGoal);
        numLevel += 1;
    }

    IEnumerator totalScoreE()
    {
        //START COUNT SCORE
        while (true)
        {
            if (numLevel <= 0)
            {
                numLevel = 0;
            }

            totalLevelText.text = "Level Cleared:\n" + numLevel.ToString("00");
            endPanelText.text = totalLevelText.text;
            endPanelText.text = "Level Cleared:\n" + numLevel.ToString("00");
            yield return null;
        }
    }

    public void gameEnd()
    {
        //GAME END
        destroyProducts();
        ResetArrowPos();
        curSpawnNum = 0;
        startCount = false;
        gameIsReady = false;
        //canPick = false;
        endPanel.SetActive(true);
        AudioManager.instance.endSound(AudioManager.instance.endPanel);
        destroyProducts();
        //StartCoroutine("endPanelMove");
        timeLeft = 0;

        Debug.Log("GAME END");
    }


    public void destroyProducts()
    {
        Transform[] allChildren = spawnParent.GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            //Using tag to differentiate the target children and the parent
            if (child.gameObject.CompareTag("MilkProduct"))
            {
                //Do something
                Destroy(child.gameObject);
                Debug.Log("destroy");
            }

        }
    }

    IEnumerator endPanelMove()
    {
        endPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-58, 500);
        endPanel.GetComponent<RectTransform>().DOLocalRotate(new Vector3(0, 0, 28), 0);
        endPanel.GetComponent<RectTransform>().DOAnchorPosY(33, 0.5f).SetEase(Ease.InSine);
        yield return new WaitForSeconds(0.5f);
        endPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 33), 0.5f);
        endPanel.GetComponent<RectTransform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
        yield return new WaitForSeconds(1f);
        endPanel.GetComponent<RectTransform>().DOKill();
        yield return null;
    }

    public void ResetArrowPos()
    {

        arrowList[0].transform.position = startPos[0].GetComponent<RectTransform>().position;
        arrowList[1].transform.position = startPos[1].GetComponent<RectTransform>().position;
        arrowList[2].transform.position = startPos[2].GetComponent<RectTransform>().position;
        arrowList[3].transform.position = startPos[3].GetComponent<RectTransform>().position;

        DragInteraction.instance.isCorrectPlace = false;
        Debug.Log("Reset");
        //if (reset == true)
        //{
        //    arrowList[0].transform.position = startPos[0].GetComponent<RectTransform>().position;
        //    arrowList[1].transform.position = startPos[0].GetComponent<RectTransform>().position;
        //    arrowList[2].transform.position = startPos[0].GetComponent<RectTransform>().position;
        //    arrowList[3].transform.position = startPos[0].GetComponent<RectTransform>().position;

        //    DragInteraction.instance.isCorrectPlace = false;
        //    Debug.Log("Reset");
        //    //yield return new WaitForSeconds(0.1f);
        //    //reset = false;
        //    //break;
        //}
    }

    void ResetGame()
    {
        //score = 0;
        //timeLeft = totalTime;
        StartCoroutine("ResetGameE");
        Debug.Log("Reset");
    }

    IEnumerator ResetGameE()
    {
        yield return new WaitForSeconds(1);

        //KILL DOTWEEN
        //productExp.GetComponent<RectTransform>().DOKill();
        //boxExp.GetComponent<RectTransform>().DOKill();

        //INSTRUCTION PAGES
        pageInsReset();

        //IN-GAME
        levelPages1();
        timeLeft = totalTime;
        unablePick = false;
        endPanel.SetActive(false);
        numLevel = 0;

        yield return new WaitForSeconds(1);
        //STOP COROUTINE
        StopCoroutine("InstructionPage");
        StopCoroutine("GameStart");
        StopCoroutine("totalScoreE");
        StopCoroutine("spawnProductE");
        StopCoroutine("countdownGameE");
        StopCoroutine("endPanelMove");

        yield return null;
    }


    //public void DestroyPrefabsInScene(string tagName)
    //{
    //    GameObject[] prefabsTag = GameObject.FindGameObjectsWithTag(tagName);
    //    foreach (GameObject prefab in prefabsTag)
    //    {
    //        Destroy(prefab);
    //    }
    //}
}
