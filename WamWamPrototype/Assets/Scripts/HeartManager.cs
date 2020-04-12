using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private float numberOfHearts = 6.0f;
    public FloatValue playerCurrentHealth;

    void Start()
    {
        InitializeHearts();
        playerCurrentHealth.runtimeValue = playerCurrentHealth.initialValue;
    }

    public void InitializeHearts()
    {
        for (int i = 0; i < numberOfHearts; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.runtimeValue;
        for (int i = 0; i < numberOfHearts; i++)
        {
            if (i <= tempHealth - 1)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i >= tempHealth)
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
