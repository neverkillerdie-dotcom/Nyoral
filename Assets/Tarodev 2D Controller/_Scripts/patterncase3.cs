using UnityEngine;
using DG.Tweening;
using System.Collections;

//헤엄 헤엄 뒤지게 돌리기 하면서 왔다 갔다 거리면됨
public class patterncase3 : MonoBehaviour
{
    //public AudioClip[] Sound;
    //public AudioSource audioSource;
    public GameObject[] patternPrefab;
    public GameObject[] ifuseground;
    public Vector2[] position;

    private float[] currentscale = new float[4];

    public IEnumerator Play()
    {   
        yield return pattern1();
        yield return pattern2();
        yield return pattern3();
        yield return pattern4();
    }

    private void Awake()
    {
        for (int i = 1; i < 4; i++)
        {
            currentscale[i] = ifuseground[i].transform.localScale.x;
        }
    }

    GameObject sy;
    //일단 점점 돌아가게 해보죠
    public IEnumerator pattern1()
    {
        ifuseground[0].transform.DOMoveY(7f, 1f).SetRelative();
        for (int i = 1; i < 4; i++)
        {
            int fls = i;
            ifuseground[i].transform.DOScaleX(0f, 2f).OnComplete(() => ifuseground[fls].SetActive(false));
        }
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator pattern2()
    {
        sy = Instantiate(patternPrefab[0], position[0],Quaternion.Euler(0f, 0f, 270f));
        int total = 0;
        while (total < 90)
        {
            int roll = Random.Range(15, 25);
            if (total + roll > 90)
            {
                roll = 90 - total;
            }   
            total += roll;
            float roll1 = Random.Range(0.2f,0.5f);
            sy.transform.DORotate(new Vector3(0f, 0f, roll), roll1).SetRelative();
            yield return new WaitForSeconds(roll1);
        }
    }
    //여기서 헤엄 헤엄
    public IEnumerator pattern3()
    {
        int[] roll = new int[3];
        float[] roll1 = new float[3];
        float[] roll2 = new float[3];
        for (int a = 0; a < 2; a++)
        {
            for (int i = 0; i < 3; i++)
            {
                roll[i] = Random.Range(120, 140);
                roll1[i] = Random.Range(6f, 9f);
                roll2[i] = Random.Range(1f, 1.5f);
            }
            //나중에 이것도  패턴 1과 같이 움직임 끊기게 조절하기
        
            sy.transform.DOMove(new Vector2(-roll[0],-roll1[0]), roll2[0]).SetRelative();
            yield return new WaitForSeconds(roll2[0]);
            sy.transform.position = position[1];
            sy.transform.DOMove(new Vector2(roll[1],-roll1[1]), roll2[1]).SetRelative();
            yield return new WaitForSeconds(roll2[1]);
            sy.transform.DOMove(new Vector2(-roll[2],-roll1[2]), roll2[2]).SetRelative();
            yield return new WaitForSeconds(roll2[2]);
        }
        Destroy(sy);
        
    }

    public IEnumerator pattern4()
    {
        ifuseground[0].transform.DOMoveY(-7f, 0.5f).SetRelative();
        for (int i = 1; i < 4; i++)
        {
            ifuseground[i].SetActive(true);
            ifuseground[i].transform.DOScaleX(currentscale[i], 2f);
        }
        yield return new WaitForSeconds(1f);
    }
}