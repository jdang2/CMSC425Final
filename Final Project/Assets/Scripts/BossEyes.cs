using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEyes : MonoBehaviour
{
    public Slider eyeHP;

    public Slider bossHP;

    public Slider stencilHP;
    public void TakeDamage(float amount)
    {
        eyeHP.value -= amount;
        bossHP.value -= 1;
        stencilHP.value -= 1;
        if (eyeHP.value <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }
}
