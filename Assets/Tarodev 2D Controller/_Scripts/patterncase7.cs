using UnityEngine;
using DG.Tweening;
using System.Collections;

//징글벨
public class patterncase7 : MonoBehaviour
{
    //public AudioClip[] Sound;
    //public AudioSource audioSource;
    public GameObject[] patternPrefab;
    public GameObject[] ifuseground;
    public Vector2[] position;
    public bool usingground;
    public Collider2D playerCollider;

    public IEnumerator Play()
    {   
        yield return pattern1();
        yield return pattern2();
        yield return pattern3();
        yield return pattern4();
        yield return pattern5();
    }

    GameObject[] 징글벨 = new GameObject[15];
    GameObject[] 임시땅 = new GameObject[4];
    float[] currentscale = new float[5];

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            currentscale[i] = ifuseground[i].transform.localScale.x;
        }
    }

    private void Update()
    {
        if (usingground)
        {
            if (Input.GetKey(KeyCode.S))
            {
                for (int i = 0; i <4 ; i++)
                {   
                    Physics2D.IgnoreCollision(playerCollider, 임시땅[i].GetComponent<Collider2D>(), true);
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    Physics2D.IgnoreCollision(playerCollider, 임시땅[i].GetComponent<Collider2D>(), false);
                }
            }
        }
    }

    public IEnumerator pattern1()
    {
        for (int i = 0; i < 4; i++)
        {
            임시땅[i] = Instantiate(ifuseground[0],new Vector2(position[0].x, position[0].y + i * -8 - 3),Quaternion.identity);
            임시땅[i].transform.DOScaleX(15f, 1f);
        }
        for (int i = 0; i < 5; i++)
        {
            ifuseground[i].transform.DOScaleX(0f, 2f);
        }
        usingground = true;
        yield return new WaitForSeconds(3f);
    }
    //
    public IEnumerator pattern2()
    {
        for (int i = 0; i < 15; i++)
        {
            징글벨[i] = Instantiate(patternPrefab[0],new Vector2(-position[0].x, position[0].y + Random.Range(0,4) * -8),Quaternion.Euler(0f, 0f, 90f));
            징글벨[i].transform.DOMoveX(Random.Range(-160f,-180f), Random.Range(3.5f,4.5f)).SetRelative();
            yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
        }
        for (int i = 0; i < 15; i++)
        {
            Destroy(징글벨[i],5f);
        }
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator pattern3()
    {
        ifuseground[4].transform.DOScaleX(30f, 1f);
        yield return new WaitForSeconds(2f);
    }

    public IEnumerator pattern4()
    {
        GameObject 꼬칼콘1 = Instantiate(patternPrefab[1],position[2],Quaternion.identity);
        GameObject 꼬칼콘2 = Instantiate(patternPrefab[1],-position[2],Quaternion.identity);
        꼬칼콘1.transform.DOMoveX(-30f, 0.5F).SetRelative();
        꼬칼콘2.transform.DOMoveX(30f, 0.5F).SetRelative();
        Destroy(꼬칼콘1,0.8f);
        Destroy(꼬칼콘2,0.8f);
        yield return new WaitForSeconds(1f);
    }

    //택시나 벽에 꼴아박기
    public IEnumerator pattern5()
    {
        for (int i = 0; i < 4; i++)
        {
            임시땅[i].transform.DOScaleX(0, 1f);
        }
        for (int i = 0; i < 5; i++)
        {
            ifuseground[i].transform.DOScaleX(currentscale[i], 2f);
        }
        yield return new WaitForSeconds(3.5f);
        usingground = false;
        for (int i = 0; i < 4; i++)
        {
            Destroy(임시땅[i]);
        }
    }
}