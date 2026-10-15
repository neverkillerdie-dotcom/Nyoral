using UnityEngine;
using DG.Tweening;
using System.Collections;


[System.Serializable]
public class random
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
}

public class patterncase1 : MonoBehaviour
{
    //public AudioClip[] Sound;
    //public AudioSource audioSource;
    public GameObject[] patternPrefab;

    public Vector2[] position;

    public random minmaxdata;
    public Vector2 random위치;

    //random위치 = new Vector2(Random.Range(minmaxdata.minX, minmaxdata.maxX),Random.Range(minmaxdata.minY, minmaxdata.maxY));

    public IEnumerator Play()
    {   
        yield return pattern1();
        yield return pattern2();
    }

    //1.린이 하늘에서 랜덤 좌표에서 랜덤속도로 내려오는거
    public IEnumerator pattern1()
    {
        for (int i = 0; i < 30; i++)
        {
            random위치 = new Vector2(Random.Range(minmaxdata.minX, minmaxdata.maxX),Random.Range(minmaxdata.minY, minmaxdata.maxY));
            
            GameObject spawnedfirst = Instantiate(patternPrefab[0],random위치,Quaternion.identity);
            Rigidbody2D 작은린 = spawnedfirst.GetComponent<Rigidbody2D>();
            작은린.gravityScale = Random.Range(3f, 5f);
            작은린.angularVelocity = Random.Range(180f, 720f);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
            int roll = Random.Range(1, 11);
            if (roll == 1)
            {
                //audioSource.PlayOneShot(Sound[0]); 
            }
            Destroy(spawnedfirst, 10f);
        }
    }

    //2.마지막에 엄청 큰 린이 땅을 내려치며 충격파를 일으킴  마지막 돌면서 퇴장
    public IEnumerator pattern2()
    {
        GameObject spawnedsecond = Instantiate(patternPrefab[1] ,position[0] ,Quaternion.identity);
        Rigidbody2D 큰린 = spawnedsecond.GetComponent<Rigidbody2D>();
        큰린.transform.DOMoveY(-100f, 0.5F).SetRelative();
        yield return new WaitForSeconds(1f);
        
        GameObject spawnedthird = Instantiate(patternPrefab[0] ,position[1] ,Quaternion.identity);
        GameObject spawned4 = Instantiate(patternPrefab[0] ,position[2] ,Quaternion.identity);

        Rigidbody2D _spawnedthird = spawnedthird.GetComponent<Rigidbody2D>();
        Rigidbody2D _spawned4 = spawned4.GetComponent<Rigidbody2D>();

        for (int i = 0; i < 3; i++)
        {
            float randomnumberx = Random.Range(20f, 50f);
            float randomnumbery = Random.Range(5f, 25f);

            _spawnedthird.DOJump(new Vector2(randomnumberx, 0f),randomnumbery,1,1f).SetRelative();
            yield return _spawned4.DOJump(new Vector2(-randomnumberx, 0f), randomnumbery, 1, 1f).SetRelative().WaitForCompletion();
            spawnedthird.transform.position = position[1];
            spawned4.transform.position = position[2];
        }
        _spawnedthird.gravityScale = 0f;
        _spawned4.gravityScale = 0f;
        Destroy(spawnedthird);
        Destroy(spawned4);

        큰린.angularVelocity = 1080f;
        yield return new WaitForSeconds(1.5f);
        큰린.transform.DOMoveX(40f, 2f).SetRelative();
        yield return new WaitForSeconds(2f);
        큰린.transform.DOMoveX(-200f, 0.5F).SetRelative();
        큰린.transform.DOMoveY(3f, 0.5F).SetRelative();
        spawnedsecond.transform.DOScale(new Vector3(3f, 3f, 1f), 0.5f);
        Destroy(spawnedsecond,0.6f);
    }
}
