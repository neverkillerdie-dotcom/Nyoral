using UnityEngine;
using DG.Tweening;
using System.Collections;

//미나리먹고 미쳤니 도라지 먹고 도랐니 생강먹고 생각좀해
public class patterncase5 : MonoBehaviour
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
        yield return pattern4();
        yield return pattern5();
        yield return pattern6();
        yield return pattern7();
    }

    public IEnumerator pattern1()
    {
        GameObject 미나리 = Instantiate(patternPrefab[0] ,position[0] ,Quaternion.identity);
        미나리.transform.DOMove(new Vector2(0f, 80F),3f).SetRelative();
        for(int i = 0; i < 6; i++) 
        {
            if (i % 2 == 0)
            {
                yield return 미나리.transform.DOMove(new Vector2(6f, 0F),0.5f).SetRelative();
            }
            else
            {
               yield return 미나리.transform.DOMove(new Vector2(-8f, 0F),0.5f).SetRelative();
            }
        }
        Destroy(미나리);
    }

    public IEnumerator pattern2()
    {
        GameObject 미나리먹은린 = Instantiate(patternPrefab[1] ,position[1] ,Quaternion.identity);
        for(int i = 0; i < 3; i++) 
        {
            if (i % 2 == 0)
            {
                미나리먹은린.transform.rotation = Quaternion.Euler(0f, 0f, 30f);
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                미나리먹은린.transform.rotation = Quaternion.Euler(0f, 0f, 330f);
                yield return new WaitForSeconds(0.2f);
            }
            Destroy(미나리먹은린);
        }
    }

    public IEnumerator pattern3()
    {
        GameObject 도라지 = Instantiate(patternPrefab[2] ,position[2] ,Quaternion.identity);
        도라지.transform.DOMove(new Vector2(0f, 100F),1.5f).SetRelative();
        yield return new WaitForSeconds(1.5f);
        Destroy(도라지);
    }

    public IEnumerator pattern4()
    {
        GameObject 도라지먹은린 = Instantiate(patternPrefab[3] ,position[1] ,Quaternion.identity);
        yield return new WaitForSeconds(3f);
        //Vector2 size = 도라지먹은린.transform.localScale;
        //도라지먹은린.DORotate(new Vector3(0f, 0f, 360f), 1.2f).SetRelative();
        //yield return 도라지먹은린.transform.DOScale(new Vector2(size.x, size.y * 3),0.3f).SetLoops(4, LoopType.Yoyo);
        //Destroy(도라지먹은린);
    }

    public IEnumerator pattern5()
    {   
        GameObject 생강 = Instantiate(patternPrefab[4] ,position[3] ,Quaternion.identity);
        yield return 생강.transform.DOJump(new Vector2(30f, 5f),10f,1,3f).SetRelative();
        yield return 생강.transform.DOJump(new Vector2(50f, -5f),20f,1,2f).SetRelative();
        Destroy(생강);
    }

    public IEnumerator pattern6()
    {
        GameObject 생강먹은린 = Instantiate(patternPrefab[5] ,position[4] ,Quaternion.identity);
        GameObject 울렁증;
        for(int i = 0; i < 4 ; i++) 
        {
            if (i % 2 == 0)
            {
                //생강먹은린.transform.DOMoveX(-20f, 0.4f).SetLoops(4, LoopType.Yoyo).SetRelative();
                yield return 생강먹은린.transform.DOMoveX(-20f, 0.4f).SetRelative();
                //GameObject 울렁증 = Instantiate(patternPrefab[6] ,position[1] ,Quaternion.identity);
                //추후 패턴 추가예정
            }
            else
            {
                yield return 생강먹은린.transform.DOMoveX(20f, 0.4f).SetRelative();
            }
        }
        yield return new WaitForSeconds(1f);
        //아직 미완성 추후 destroy추가
    }

    public IEnumerator pattern7()
    {
        GameObject 미치고돌았고생각좀해야되는린 = Instantiate(patternPrefab[7] ,position[1] ,Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        미치고돌았고생각좀해야되는린.transform.DOMoveY(20f, 1f).SetRelative();
        GameObject 파도 = Instantiate(patternPrefab[8] ,position[5] ,Quaternion.identity);
        파도.transform.DOMoveY(30f, 1f).SetRelative();
        //if use ground 사용및 추후 destroy 추가
    }
}