using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using DG.Tweening;

public class Pattern : MonoBehaviour
{
    public GameObject[] redzonePrefab;
    public AudioSource audioSource;
    public AudioClip[] Sound;
    public GameObject[] patternPrefab;

    public bool IsGamePlaying { get; private set; }
    public bool[] ResetPosition { get; private set; } = new bool[1];

    public TMP_Text countdownText;

    int current = 0;

    private IEnumerator ShowAttetch(GameObject redzonePrefab)
    {   
        redzonePrefab.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        redzonePrefab.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        redzonePrefab.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        redzonePrefab.SetActive(false);


    }

   private IEnumerator Start()
    {
        IsGamePlaying = false;

        countdownText.gameObject.SetActive(true);
        countdownText.text = "3초후 게임 시작";
        //audioSource.PlayOneShot(Sound[0]);

        yield return new WaitForSeconds(1f);

        countdownText.text = "2초후 게임 시작";
        //audioSource.PlayOneShot(Sound[1]);

        yield return new WaitForSeconds(1f);

        countdownText.text = "1초후 게임 시작";
        //audioSource.PlayOneShot(Sound[2]);

        yield return new WaitForSeconds(1f);
        //audioSource.PlayOneShot(Sound[3]);

        countdownText.gameObject.SetActive(false);

        IsGamePlaying = true;
        StartCoroutine(PatternPlaying());
    }

    private IEnumerator PatternPlaying()
    {
        while (IsGamePlaying)
        {
            current = Random.Range(0, 11);

            switch (current)
            {
                //1.린이 하늘에서 랜덤 좌표에서 랜덤속도로 내려오는거
                case 0:
                Debug.Log("case 0 실행");
                //완성
                    yield return StartCoroutine(ShowAttetch(redzonePrefab[current]));
                    yield return StartCoroutine(patternPrefab[0].GetComponent<patterncase0>().Play());
                    break;

                //2.사카밤바스피스가 일정 구역을 가로로 지나가면서 피격하는거
                case 1:
                    Debug.Log("case 1 실행");
                    //완성
                    yield return StartCoroutine(ShowAttetch(redzonePrefab[current]));
                    yield return StartCoroutine(patternPrefab[1].GetComponent<patterncase1>().Play());
                    break;

                //3.화면에서 랜덤 구역 위융위융거리기
                case 2:
                    Debug.Log("case 2 실행");
                    //완성
                    yield return StartCoroutine(ShowAttetch(redzonePrefab[current]));
                    yield return StartCoroutine(patternPrefab[2].GetComponent<patterncase2>().Play());
                    break;

                //아저씨 머리 아파요 
                case 3 :
                    Debug.Log("case 3 실행");
                    //완성
                    yield return StartCoroutine(ShowAttetch(redzonePrefab[current]));
                    yield return StartCoroutine(patternPrefab[3].GetComponent<patterncase3>().Play());
                    break;
                //5.뇨치의 자유 방생 
                case 4:
                    Debug.Log("case 4 실행");
                    //완성
                    yield return StartCoroutine(ShowAttetch(redzonePrefab[current]));
                    yield return StartCoroutine(patternPrefab[4].GetComponent<patterncase4>().Play());
                    break;
                //미나리먹고 미쳤니 도라지 먹고 도랐니 생강먹고 생각좀해
                case 5:
                    Debug.Log("case 5 실행");
                    //미완성 (재미없음)
                    //yield return StartCoroutine(ShowAttetch(redzonePrefab[current]));
                    //yield return StartCoroutine(patternPrefab[5].GetComponent<patterncase5>().Play());
                    break;
                //아저씨 머리 아파요 
                case 6:
                    Debug.Log("case 6 실행");
                    //완성
                    yield return StartCoroutine(ShowAttetch(redzonePrefab[current]));
                    yield return StartCoroutine(patternPrefab[6].GetComponent<patterncase6>().Play());
                    break;
                //
                case 7:
                    ResetPosition[0] = true;
                    Debug.Log("case 7 실행");
                    //완성
                    yield return StartCoroutine(ShowAttetch(redzonePrefab[current]));
                    yield return StartCoroutine(patternPrefab[7].GetComponent<patterncase7>().Play());
                    //ResetPosition[0] = false;
                    break;
            }

            yield return new WaitForSeconds(0.05f);
        }             
    }
}