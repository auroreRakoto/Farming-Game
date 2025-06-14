using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class GrowBlock : MonoBehaviour
{
    public enum GrowthStage
    {
        barren,
        ploughed,
        planted,
        growing1,
        growing2,
        ripe
    }

    public GrowthStage currentStage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            AdvanceStage();
        }
    }

    public void AdvanceStage()
    {
        currentStage = (GrowthStage)(((int)currentStage + 1) % Enum.GetValues(typeof(GrowthStage)).Length);

    }
}
