using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TreeHealthBar : MonoBehaviour
{

    [SerializeField]
    private Gradient ColorGradient;
    [SerializeField]
    Image lifeBar;
    [SerializeField]
    Slider lifeSlider;
    List<Damageable> damageables;
    int totalTreeHealth=0,actualTreeHealth=0;

    [SerializeField] UnityEvent OnEventComplete;
    private void OnEnable()
    {
        damageables = new List<Damageable>();
        var roots = GameObject.FindGameObjectsWithTag("Root");
        foreach (GameObject item in roots)
        {
            damageables.Add(item.GetComponent<Damageable>());
        }
        foreach (Damageable item in damageables)
        {
            totalTreeHealth += item.totalEndurance;
            actualTreeHealth += item.endurance;
            item.OnEventHit.AddListener(Hit);
        }
        lifeSlider.minValue = 0;
        lifeSlider.maxValue = totalTreeHealth;
        lifeSlider.value = actualTreeHealth;
    }

    private void Hit()
    {
        lifeSlider.value--;
        lifeBar.color = ColorGradient.Evaluate(1-(lifeSlider.value /lifeSlider.maxValue));
        if (lifeSlider.value == 0)
        {
            OnEventComplete?.Invoke();
        }
    }
}
