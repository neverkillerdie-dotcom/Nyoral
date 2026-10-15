using UnityEngine;
using DG.Tweening;
using System.Collections;
using TarodevController;

[System.Serializable]
public class RandomPosition
{
    public float upDownMin;
    public float upDownMax;
    public float leftRightMin;
    public float leftRightMax;
}

public class patterncase6 : MonoBehaviour
{
    [SerializeField] private GameObject[] _patternPrefab;
    [SerializeField] private Vector2[] _position;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private RandomPosition _randomPosition;


    public IEnumerator Play()
    {
        for(int i = 0; i <10 ; i++) 
        {
            yield return Pattern1();
        }
        yield return Pattern2();
    }

    private IEnumerator CheckDistance(GameObject nana, GameObject croissant)
    {
        while (nana != null && croissant != null)
        {
            if (Vector2.Distance(nana.transform.position, croissant.transform.position) <= 2f)
            {
                croissant.transform.DOKill();

                Destroy(nana);
                Destroy(croissant);

                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator Pattern1()
    {
        GameObject nana;
        GameObject croissant;

        int t = Random.Range(0,4); //0,1은 각각 위 아래 2,3은 각각 왼 오른쪽
        if (t == 0)
        {
            _position[0] = new Vector2(Random.Range(_randomPosition.upDownMin,_randomPosition.upDownMax),25f);
            nana = Instantiate(_patternPrefab[0] , _position[0] ,Quaternion.Euler(0f, 0f, 180f));
        }
        else if (t == 1)
        {
            _position[0] = new Vector2(Random.Range(_randomPosition.upDownMin,_randomPosition.upDownMax),-5f);
            nana = Instantiate(_patternPrefab[0] , _position[0] ,Quaternion.Euler(0f, 0f, 0f));
        }
        else if (t == 2)
        {
            _position[0] = new Vector2(-30f,Random.Range(_randomPosition.leftRightMin, _randomPosition.leftRightMax));
            nana = Instantiate(_patternPrefab[0] , _position[0]  ,Quaternion.Euler(0f, 0f, 270f));
        }
        else
        {
            _position[0] = new Vector2(30f,Random.Range(_randomPosition.leftRightMin, _randomPosition.leftRightMax));
            nana = Instantiate(_patternPrefab[0] , _position[0]  ,Quaternion.Euler(0f, 0f, 90f));
        }
        Vector2 direction = (_playerController.transform.position- nana.transform.position).normalized;
        _position[1] = (Vector2)_playerController.transform.position + direction * 50f;
        croissant = Instantiate(_patternPrefab[1] , _position[1] ,Quaternion.identity);
        StartCoroutine(CheckDistance(nana, croissant));

        Rigidbody2D rb = croissant.GetComponent<Rigidbody2D>();

        rb.linearVelocity = -direction * 25f;
        rb.angularVelocity = 600f;
        croissant.transform.DOScale(croissant.transform.localScale * 0.7f, Vector2.Distance(_position[1], nana.transform.position) / 25f).SetEase(Ease.OutQuad);

        yield return new WaitForSeconds(2f);
    }

    private IEnumerator Pattern2()
    {
        GameObject angryrin = Instantiate(_patternPrefab[2] ,_position[2] ,Quaternion.identity);
        yield return new WaitForSeconds(2f);
        yield return angryrin.transform.DOMove(new Vector2(50f, 0f),2f).SetRelative().WaitForCompletion();
        yield return angryrin.transform.DOMove(new Vector2(50f, 0f),1f).SetRelative().WaitForCompletion();
        Destroy(angryrin);
    }
}