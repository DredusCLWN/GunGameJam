using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController2 : MonoBehaviour
{
    public Light light;
    public float changeInterval = 0.1f;
    public float minIntensity = 0.9f;
    public float maxIntensity = 1.0f;

    private float nextChangeTime;
    private bool increasingIntensity;

    void Start () {
        nextChangeTime = Time.time + changeInterval;
        increasingIntensity = true;
    }

    void Update () {
        if (Time.time > nextChangeTime) {
            if (increasingIntensity) {
                light.intensity += 0.1f;
                if (light.intensity >= maxIntensity) {
                    increasingIntensity = false;
                }
            } else {
                light.intensity -= 0.1f;
                if (light.intensity <= minIntensity) {
                    increasingIntensity = true;
                }
            }

            nextChangeTime = Time.time + changeInterval;
        }
    }
}
