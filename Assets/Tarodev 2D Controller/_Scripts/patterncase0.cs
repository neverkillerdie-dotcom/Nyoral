using UnityEngine;
using DG.Tweening;
using System.Collections;

//2.사카밤바스피스 구간
public class patterncase0 : MonoBehaviour
{
    //public AudioClip[] Sound;
    //public AudioSource audioSource;
    public GameObject[] patternPrefab;

    public Vector2[] position;

    public IEnumerator Play()
    {   
        yield return pattern1();
        yield return pattern2();
    }

    /*GameObject spawnedfirst = Instantiate(patternPrefab[0],position[0],Quaternion.identity); 머리 3개 
    GameObject spawnedsecond = Instantiate(patternPrefab[1],position[0],Quaternion.identity); 몸 3개
    GameObject spawned3 = Instantiate(patternPrefab[2],position[0],Quaternion.identity); 꼬리 2개*/

    //머리 3개 몸 3개 꼬리 2개 2번 반복
    public IEnumerator pattern1()
    {
        //audioSource.PlayOneShot(Sound[number[a]]);
        for (int i = 0; i < 2; i++)
        {
            int[] number = {0, 0, 0, 1, 1, 1, 2, 2};
            
            for (int a = 0; a < 8; a++)
            {
                GameObject _sy = Instantiate(patternPrefab[number[a]],position[0] + new Vector2(8f * a, 0f),Quaternion.identity);
                Destroy (_sy , (1.6f - 0.2f* a));
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    //사카밤바스피스 소환 앞뒤 움직임
    public IEnumerator pattern2()
    {
        GameObject _sakabambaspis = Instantiate(patternPrefab[3] ,position[1] ,Quaternion.identity);
        Rigidbody2D _tkzkqkaqktmvltm = _sakabambaspis.GetComponent<Rigidbody2D>();
        _tkzkqkaqktmvltm.transform.DOMoveX(120f, 2f).SetRelative();
        yield return new WaitForSeconds(2f);
        _tkzkqkaqktmvltm.transform.DOMoveX(-40f, 0.5f).SetRelative();
        yield return new WaitForSeconds(0.5f);
        _tkzkqkaqktmvltm.angularVelocity = 1080f;
        _tkzkqkaqktmvltm.transform.DOMoveY(80f, 1f).SetRelative();
        yield return new WaitForSeconds(2f);
        Destroy(_sakabambaspis, 3f);
    }
}