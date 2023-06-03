using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundBE : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Устанавливаем начальное значение слайдера в соответствии с текущей громкостью
        volumeSlider.value = audioSource.volume * 100;
    }

    public void OnVolumeChanged()
    {
        // Метод вызывается при изменении значения слайдера
        audioSource.volume = volumeSlider.value / 100f;
    }
}
