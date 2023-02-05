using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RootListener : MonoBehaviour
{
    [SerializeField]
    ChannelNavmeshSO channelNavmeshSO;
    [SerializeField]
    private Gradient ColorGradient;
    [SerializeField]
    Image lifeBar;
    [SerializeField]
    GameObject rootSlider;
    Slider mySlider;
    private Damageable dmg;

    private void Awake()
    {
        mySlider = rootSlider.GetComponent<Slider>();

    }
    private void OnEnable()
    {
        channelNavmeshSO.OnEventInteractable += AddDamageEvent;
        channelNavmeshSO.OnEventPoint += CloseBar;
        var roots = GameObject.FindGameObjectsWithTag("Root");
        foreach (GameObject item in roots)
            item.GetComponent<Interactable>().OnEventSelect.AddListener(OpenBar);
    }


    private void OnDisable()
    {
        channelNavmeshSO.OnEventPoint -= CloseBar;
        var roots = GameObject.FindGameObjectsWithTag("Root");
        foreach (GameObject item in roots)
            item.GetComponent<Interactable>().OnEventSelect.RemoveListener(OpenBar);

    }
    private void CloseBar(Vector3 v3)
    {
        Debug.Log("cerrado el canvas");
        rootSlider.SetActive(false);
    }

    private void OpenBar()
    {
        Debug.Log("abierto el canvas");
        rootSlider.SetActive(true);
    }




    private void AddDamageEvent(Interactable root)
    {
        Debug.Log(root.name + " recibio impacto");
        dmg = root.GetComponent<Damageable>();
        mySlider.minValue = 0;
        mySlider.maxValue = dmg.totalEndurance;
        mySlider.value = dmg.endurance;
        if (dmg.endurance == 0)
            rootSlider.SetActive(false);
        dmg.OnEventHit.AddListener(UpdateBar);
    }

    private void UpdateBar()
    {
        mySlider.value = dmg.endurance;
    }
}