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
	public SpriteRenderer theSP;
	public Sprite soilTilled;
	public Sprite soilWatered;

	public SpriteRenderer cropSP;
	public Sprite plantedSprite;
	public Sprite growing1Sprite;
	public Sprite growing2Sprite;
	public Sprite ripeSprite;

	public bool isWatered;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		/*if (Keyboard.current.eKey.wasPressedThisFrame)
		{
			AdvanceStage();

			SetSoilSprite();
		}*/

#if UNITY_EDITOR
		if (Keyboard.current.nKey.wasPressedThisFrame)
		{
			if (isWatered)
			{
				if (currentStage == GrowthStage.planted || currentStage == GrowthStage.growing1 || currentStage == GrowthStage.growing2)
				{
					AdvanceStage();
					UpdateCrop();
					isWatered = false;
					SetSoilSprite();
				}
			}
		}
#endif

	}

	public void AdvanceStage()
	{
		currentStage = (GrowthStage)(((int)currentStage + 1) % Enum.GetValues(typeof(GrowthStage)).Length);
	}

	public void SetSoilSprite()
	{
		if (currentStage == GrowthStage.barren)
		{
			theSP.sprite = null;
		}
		else
		{
			if (isWatered)
			{
				theSP.sprite = soilWatered;
			}
			else
			{
				theSP.sprite = soilTilled;
			}
		}
	}

	public void PloughSoil()
	{
		if (currentStage == GrowthStage.barren)
		{
			AdvanceStage();

			SetSoilSprite();
		}
	}

	public void WaterSoil()
	{
		isWatered = true;

		SetSoilSprite();
	}

	public void PlantCrop()
	{
		if (currentStage == GrowthStage.ploughed)
		{
			currentStage = GrowthStage.planted;

			UpdateCrop();
		}
	}

	private void UpdateCrop()
	{
		switch (currentStage)
		{
			case GrowthStage.planted:
				cropSP.sprite = plantedSprite;
				break;
			case GrowthStage.growing1:
				cropSP.sprite = growing1Sprite;
				break;
			case GrowthStage.growing2:
				cropSP.sprite = growing2Sprite;
				break;
			case GrowthStage.ripe:
				cropSP.sprite = ripeSprite;
				break;
		}
	}

	public void HarvestCrop()
	{
		if (currentStage == GrowthStage.ripe)
		{
			cropSP.sprite = null;
			currentStage = GrowthStage.ploughed;
			SetSoilSprite();
		}
	}
}
