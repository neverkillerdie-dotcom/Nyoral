using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeathMessage : MonoBehaviour
{   
    [SerializeField] private TMP_Text _finalScore;
    [SerializeField] private TMP_Text _speech;
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Image _skinImage;

    public ScoreManager ScoreManager;

    private void OnEnable()
    {
        int[] _random = { 0, 0, 0, 1, 1, 2,};
        int _result = _random[Random.Range(0, _random.Length)];

        float _score = ScoreManager.currentScore / 100;
        string[] _text1 ={"그걸 죽냐", "넌 그냥 접어라", "당신은 바보입니다"};
        string[] _text2 ={"게임을 끄는것을 추천드립니다", "가끔힘들때가 있죠", "좀 더 분발하세요!"};
        string[] _text3 ={"이제는 일반인 취급이 가능한 실력이군요!", "노력하시면 더 높이올라가실수 있을거에요!", "쿠모린님이 이 게임을 플레이한다면 아마도 가능한 최고점수 일겁니다"};
        string[] _text4 ={"친구한테 행님이라 불릴 자격이 생겼습니다", "당신은 개발자의 최고기록을 뛰어넘었습니다!", "행님이라 불릴 자격을 얻었습니다!"};
        string[] _text5 ={"이제 당신은 일반인의 경지를 아득히 뛰어넘었습니다!", "인간인지 의심이 가기 시작합니다", "린에 대한 이해도가 부족합니다"};
        string[] _text6 ={"로봇입니까?", "행님이라 부르겠습니다", "당신은 이 게임을 감히 클리어했다고 말해도 됩니다!"};
        //아직 대사 안넣음

        _skinImage.sprite = _playerSprite.sprite;
        _finalScore.text = "Your Score:" +  ((int)ScoreManager.currentScore).ToString();

        if (_score <= 5) { _speech.text = _text1[_result]; _rank.text = "Rank:F"; }
        else if (_score <= 15) { _speech.text = _text2[_result]; _rank.text = "Rank:D"; }
        else if (_score <= 50) { _speech.text = _text3[_result]; _rank.text = "Rank:C"; }
        else if (_score <= 100) { _speech.text = _text4[_result]; _rank.text = "Rank:B"; }
        else if (_score <= 500) { _speech.text = _text5[_result]; _rank.text = "Rank:A"; }
        else { _speech.text = _text6[_result]; _rank.text = "Rank:S"; }
    }
}