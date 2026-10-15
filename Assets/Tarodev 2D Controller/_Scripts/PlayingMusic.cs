using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class PlayingMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _bgm;
    [SerializeField] private TMP_Text _soundVolume;
    [SerializeField] private TMP_Text _pitchBgm;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _pitchSlider;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        _bgm.loop = true;
        _bgm.Play();
    }

    private void Update()
    {
        ChangeVolume(_soundSlider.value);
        ChangePitch(_pitchSlider.value);
        
        if (Time.timeScale == 0)
        {
            _bgm.Pause();
        }
        else
        {
            _bgm.UnPause();
        }
    }

    public void ChangeVolume(float volume)
    {
        _bgm.volume = volume;
        _soundVolume.text = Mathf.RoundToInt(volume * 100f).ToString();
    }

    public void ChangePitch(float pitch)
    {
        _bgm.pitch = pitch;
        _pitchBgm.text = pitch.ToString("0.0") + "X";
    }
}
