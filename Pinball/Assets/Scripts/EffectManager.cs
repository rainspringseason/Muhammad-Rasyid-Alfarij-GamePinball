using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }

    public GameObject bumperEffect;
    public GameObject switchEffect;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayBumperEffect(Vector3 spawnPosition)
    {
        GameObject particle = Instantiate(bumperEffect, spawnPosition, Quaternion.identity);
    }

    public void PlaySwitchEffect(Vector3 spawnPosition)
    {
        GameObject particle = Instantiate(switchEffect, spawnPosition, Quaternion.identity);
    }
}
