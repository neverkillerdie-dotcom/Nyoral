using UnityEngine;
using DG.Tweening;
using System.Collections;

//5.뇨치의 자유 방생 
public class patterncase4 : MonoBehaviour
{
    //public AudioClip[] Sound;
    //public AudioSource audioSource;
    public GameObject[] patternPrefab;

    public Vector2[] position;

    public IEnumerator Play()
    {   
        yield return pattern1();
        yield return pattern2();
        yield return pattern3();
    }
    GameObject[] sy = new GameObject[5];

    float[] number = {-57.74f, -26.79f, 0f, 26.79f, 57.74f};
    int[] number1 = {330,345,0,15,30};

//단 뇨치를 쏴
    public IEnumerator pattern1()
    {
        for (int a = 0; a < 2; a++)
        {
            for (int i = 0; i < 5; i++)
            {  
                sy[i] = Instantiate(patternPrefab[0] ,position[0] ,Quaternion.Euler(0f, 0f, number1[i]));
                sy[i].GetComponent<SpriteRenderer>().flipX = true;
            }
            yield return new WaitForSeconds(1.5f);
            for (int i = 0; i < 5; i++)
            {
                sy[i].transform.DOMove(new Vector2(100f, number[i]),1f).SetRelative();
            }
            yield return new WaitForSeconds(1.5f);
            for (int i = 0; i < 5; i++)
            {
                sy[i].GetComponent<SpriteRenderer>().flipX = false;
                Destroy(sy[i]);
            }
            yield return new WaitForSeconds(1f);
        }
    }
//다음 반대로 쏴 후 화면 회전
    public IEnumerator pattern2()
    {
        Debug.Log("패턴 2실행");
        GameObject[] _sy = new GameObject[2];

        for (int a = 0; a < 4; a++)
        {
            for (int i = 0; i < 5; i++)
            {   
                sy[i] = Instantiate(patternPrefab[0] ,position[1] ,Quaternion.Euler(0f, 0f, number1[i]));
            }
            yield return new WaitForSeconds(1.5f);
            for (int i = 0; i < 5; i++)
            {
                sy[i].transform.DOMove(new Vector2(-100f, -number[i]),1f).SetRelative();
                Destroy(sy[i], 4f);
                if (a >= 2)
                {
                    Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 180f);   
                    _sy[0] = Instantiate(patternPrefab[0] ,position[2] ,Quaternion.identity);
                    _sy[0].GetComponent<SpriteRenderer>().flipX = false;
                    _sy[0].transform.DOMoveY(-100f, 0.5F).SetRelative();
                    _sy[1] = Instantiate(patternPrefab[0] ,position[3] ,Quaternion.identity);
                    _sy[1].GetComponent<SpriteRenderer>().flipX = true;
                    _sy[1].transform.DOMoveY(100f, 0.5F).SetRelative();
                    Destroy(_sy[0],0.6f);
                    Destroy(_sy[1],0.6f);
                }
            }
        }
        yield return new WaitForSeconds(1f);
        Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator pattern3()
    {
        Vector2 center = position[4];
        GameObject[] sy_ = new GameObject[10];
        float 반지름 = 7f;

        for (int i = 0; i <10; i++)
        {
            float 각도 = (i+1f) * 30f + 90f;
            if (각도 >= 270f)
            {
                각도 += 30f;
            }
            float 라디안 = 각도 * Mathf.Deg2Rad;
            Vector2 fls = center + new Vector2(Mathf.Cos(라디안) * 반지름,Mathf.Sin(라디안) * 반지름);
            sy_[i] = Instantiate(patternPrefab[0],fls, Quaternion.Euler(0f, 0f, 각도));
            if (각도 <= 180f)
            {
                sy_[i].GetComponent<SpriteRenderer>().flipY = true;
            }
            sy_[i].GetComponent<SpriteRenderer>().flipX = true;
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(2f);
        for (int i = 0; i <10; i++)
        {
            sy_[i].transform.DOMove(sy_[i].transform.right * 100f,1.5f).SetRelative();
            sy_[i].GetComponent<SpriteRenderer>().flipY = false;
            sy_[i].GetComponent<SpriteRenderer>().flipX = true;
            Destroy(sy_[i],2f);
        }
        yield return new WaitForSeconds(2f);
    }
}