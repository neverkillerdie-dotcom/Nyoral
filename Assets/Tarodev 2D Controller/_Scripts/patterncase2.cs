using UnityEngine;
using DG.Tweening;
using System.Collections;

public class patterncase2 : MonoBehaviour
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

    //1.화면에서 일정 구역 위융위융거리기
    public IEnumerator pattern1()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject sy = Instantiate(patternPrefab[0], position[i], Quaternion.identity);
            Vector3 size = sy.transform.localScale;
            sy.transform.DOScale(new Vector3(size.x, size.y * 4f, size.z),0.3f).SetLoops(6, LoopType.Yoyo);
            Destroy(sy, 1.85f);
        }
        yield return new WaitForSeconds(1.9f);
    }
    
    //2.와앙 거리면서 위아래로 쓸고감
    public IEnumerator pattern2()
    {
        //Vector3 size1 = sy1.transform.localScale;
        //Vector3 size2 = sy2.transform.localScale;

        GameObject sy1 = Instantiate(patternPrefab[0], position[3], Quaternion.identity);
        Vector3 size1 = sy1.transform.localScale;
        sy1.transform.DOScale(new Vector3(size1.x, size1.y * 3f, size1.z),0.3f).SetLoops(6, LoopType.Yoyo);
        sy1.transform.DOMoveX(-120f, 2f).SetRelative();
        sy1.GetComponent<SpriteRenderer>().flipX = true;
        yield return new WaitForSeconds(2f);

        GameObject sy2 = Instantiate(patternPrefab[0], position[4], Quaternion.identity);
        Vector3 size2 = sy2.transform.localScale;
        sy2.transform.DOScale(new Vector3(size2.x, size2.y * 3f, size2.z),0.3f).SetLoops(6, LoopType.Yoyo);
        sy2.transform.DOMoveX(120f, 2f).SetRelative();
        yield return new WaitForSeconds(2f);

        Destroy(sy1);
        Destroy(sy2);
    }

    //3.빙빙 돌아가는 회전 목마처럼
    public IEnumerator pattern3()
    {
        Camera.main.transform.DORotate(new Vector3(0f, 0f, 180f),0.5f);
        yield return new WaitForSeconds(0.5f);

        GameObject sy = Instantiate(patternPrefab[0], position[3], Quaternion.identity);
            
        sy.transform.DOMoveX(-60f, 2f).SetRelative();
        yield return new WaitForSeconds(2f);
        sy.transform.DOMoveX(-15f, 0.2f).SetRelative();
        yield return new WaitForSeconds(0.2f);
        sy.transform.DOMoveY(-50f, 0.2f).SetRelative();
        yield return new WaitForSeconds(0.2f);
        sy.transform.DOMoveY(200f, 1f).SetRelative();
        yield return new WaitForSeconds(1f);

        Destroy(sy);

        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 6; i++)
        {
            GameObject sy_ = Instantiate(patternPrefab[0], position[5] + new Vector2(-10f * i, 0f), Quaternion.identity);
            sy_.transform.DOMoveY(100f, 1f).SetRelative();
            Destroy(sy_, 3f);
        }
        yield return new WaitForSeconds(1f);
        Camera.main.transform.DORotate(new Vector3(0f, 0f, 0f),0.5f);
        yield return new WaitForSeconds(0.5f);
    }
}