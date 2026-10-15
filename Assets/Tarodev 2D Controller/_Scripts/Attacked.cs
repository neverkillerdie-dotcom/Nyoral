using UnityEngine;
using TarodevController;
using System.Collections;

public class Attacked : MonoBehaviour
{
    public bool Dead { get; set; } = false;
    public int hp = 6;
    public Pattern pattern;

    private PlayerController playerController;
    public Vector2[] position;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioSource _audioSource;

    public bool 억까방지시스템 = false;

    public GameObject[] hpCells;
    /*public GameObject[] 연출;
    public GameObject[] 이펙트;
    public GameObject[] 이모지;*/

    public void RefreshHPBar()
    {
        for (int i = 0; i < hpCells.Length; i++)
        {
            if (i < hp)
            {
                hpCells[i].SetActive(true);
            }
            else
            {
                hpCells[i].SetActive(false);
            }

            Debug.Log("Element " + i +" / 부모: " + hpCells[i].transform.parent.name +" / 활성화: " + hpCells[i].activeSelf);
        }
    }

    private void Update()
    {
        RefreshHPBar();
        Debug.Log("현재 HP: " + hp);

        if (hp <= 0)
        {
            Debug.Log(gameObject.name + "의 Dead가 true 됨");
            Dead = true;
        }
    }
    //스크립트 하나 더 넣기 귀찮아서 여따가 벽에 밀리는 코드까지 같이 넣어여~~
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingWall"))
        {
            transform.position +=new Vector3(-15f * Time.fixedDeltaTime, 0f, 0f);
        }
    }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            if (pattern.ResetPosition[0])
            {
                playerController.transform.position = position[1];
            }
            else
            {
                playerController.transform.position = position[0];
            }
            hp--;
            if (hp > 0) _audioSource.PlayOneShot(_hitSound);
            Debug.Log(gameObject.name + "너 공격당함ㅋㅋㅋㅋ");
            return;
        }
        if (playerController.초특급무적타임 || collision.CompareTag("JumpOrb") || 억까방지시스템 || collision.CompareTag("MovingWall"))
        {
            return;
        }
        StartCoroutine(억까방지());
        hp--;
        if (hp > 0) _audioSource.PlayOneShot(_hitSound);
        else _audioSource.PlayOneShot(_deathSound);
        Debug.Log(gameObject.name + "너 공격당함ㅋㅋㅋㅋ");
    }

    private IEnumerator 억까방지()
    {
        억까방지시스템 = true;

        yield return new WaitForSeconds(0.3f);

        억까방지시스템 = false;
    }
}


