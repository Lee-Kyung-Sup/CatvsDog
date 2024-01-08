using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public GameObject dog;
    public GameObject food;
    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
    public GameObject retryBtn;
    public Text levelText;
    public GameObject levelFront;
    public static gameManager I;

    int level = 0;
    int cat = 0;
    private void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("makefood", 0.0f, 0.1f);
        InvokeRepeating("makeCat", 0.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void makefood()
    {
        float x = dog.transform.position.x;
        float y = dog.transform.position.y + 2.0f;
        Instantiate(food, new Vector3(x, y, 0), Quaternion.identity);
    }

    void makeCat()
    {
        Instantiate(normalCat);
        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if (p < 2) Instantiate(normalCat);
        }
        if(level >=2)
        {
            float p = Random.Range(0, 10);
            if(p<3) Instantiate(normalCat);
            Instantiate(pirateCat);
        }
        if(level>=3)
        {
            float p = Random.Range(0, 10);
            if (p < 4) Instantiate(normalCat);
            Instantiate(pirateCat);
            Instantiate(fatCat);
        }
 
        
    }

    public void gameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void addCat()
    {
        cat += 1;
        level = cat / 5;

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1.0f, 1.0f);
    }
}
