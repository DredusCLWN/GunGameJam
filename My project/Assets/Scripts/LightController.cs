using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light;
    public float minTime = 5f;
    public float maxTime = 10f;
    public float onTime = 0.1f;
    public float offTime = 0.1f;
    public int minFlashes = 2;
    public int maxFlashes = 5;
    public float pauseTime = 2f;
    public AudioClip soundClip;

    private float nextBlinkTime;
    private bool isLightOn;
    private int numFlashes;
    private float nextPauseTime;
    private bool shouldBlink;
    private AudioSource audioSource;

    void Start () {
        nextBlinkTime = Time.time + Random.Range(minTime, maxTime);
        shouldBlink = true;
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {
        if (shouldBlink) {
            if (Time.time > nextBlinkTime) {
                if (isLightOn) {
                    light.enabled = false;
                    isLightOn = false;
                    audioSource.Stop();
                    nextBlinkTime = Time.time + offTime;
                } else {
                    light.enabled = true;
                    isLightOn = true;
                    numFlashes++;
                    nextBlinkTime = Time.time + onTime;
                    if (numFlashes == 1) {
                        audioSource.clip = soundClip;
                        audioSource.Play();
                    }
                }

                if (numFlashes >= maxFlashes) {
                    shouldBlink = false;
                    nextPauseTime = Time.time + pauseTime;
                }
            }
        } else {
            if (Time.time > nextPauseTime) {
                shouldBlink = true;
                numFlashes = 0;
                nextBlinkTime = Time.time + Random.Range(minTime, maxTime);
            }
        }
    }
}