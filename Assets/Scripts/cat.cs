using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    float full = 5f;
    float energy = 0f;
    bool isFull = false;
    public int Type;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30f;

        if (Type == 1)
        {
            full = 10f;
        }
        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full)
        {
            if (Type == 0)
            {
                transform.position += new Vector3(0, -0.05f, 0);
            }
            else if (Type == 1)
            {
                transform.position += new Vector3(0, -0.03f, 0);
            }
            else if (Type == 2)
            {
                transform.position += new Vector3(0, -0.1f, 0);
            }
            if (transform.position.y < -16.0f)
            {
                //게임오버!!!
                gameManager.I.gameOver();
            }

        }
        else
        {
            if(transform.position.x > 0)
            {
                transform.position += new Vector3(0.05f, 0, 0);
            }
            else
            {
                transform.position += new Vector3(-0.05f, 0, 0);
            }
            Destroy(gameObject, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "food")
        {
            if(energy < full)
            {
                energy += 1f;
                Destroy(coll.gameObject);
                gameObject.transform.Find("hungry/Canvas/front").transform.localScale = new Vector3(energy / full, 1.0f, 1.0f);
            }
            else
            {
                if(isFull ==  false)
                {
                    gameManager.I.addCat();
                    gameObject.transform.Find("hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("full").gameObject.SetActive(true);
                    isFull = true;
                }
                    
            }
        }
    }
}
