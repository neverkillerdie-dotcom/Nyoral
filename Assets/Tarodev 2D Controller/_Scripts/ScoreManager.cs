using UnityEngine;
using TMPro;

[System.Serializable]
public class ScoreData
{
    public float minYposition;
    public float maxYposition;
    public float scorePerSecond;
}

public class ScoreManager : MonoBehaviour
{
    public ScoreData[] scoreData = new ScoreData[5];
    [SerializeField] private TMP_Text _score;

    public Transform player;

    public float currentScore = 0f;

    private int current = 0;

    private void Update()
    {
        float playerY = player.position.y;

        for (int i = 0; i < scoreData.Length; i++)
        {
            if (playerY >= scoreData[i].minYposition && playerY < scoreData[i].maxYposition)
            {
                current = i;
                break;
            }
        }

        _score.text = "score:" + ((int)currentScore).ToString();

        if (Time.timeScale == 0f)
        {
            return;
        }

        if (Time.timeScale == 1f)
        {
            currentScore += scoreData[current].scorePerSecond * Time.deltaTime;
        }
    }
}