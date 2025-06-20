using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D theRB;
	public float moveSpeed;

	public InputActionReference moveInput;
	public InputActionReference actionInput;
	public Animator anim;

	public enum ToolType
	{
		plough,
		wateringCan,
		seeds,
		basket
	}

	public ToolType currentTool;

	public float toolWaitTime = .5f;
	public float toolWaitCounter;

	bool itemSwitched;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		UIController.instance.SwitchItem((int)currentTool);
	}

	// Update is called once per frame
	void Update()
	{
		itemSwitched = false;
		theRB.linearVelocity = moveInput.action.ReadValue<Vector2>().normalized * moveSpeed;

		if (theRB.linearVelocity.x < 0f)
			transform.localScale = new Vector3(-1f, 1f, 1f);
		else if (theRB.linearVelocity.x > 0f)
			transform.localScale = new Vector3(1f, 1f, 1f);

		if (Keyboard.current.tabKey.wasPressedThisFrame)
		{
			currentTool++;
			if ((int)currentTool >= Enum.GetValues(typeof(ToolType)).Length)
			{
				currentTool = ToolType.plough;
			}
			itemSwitched = true;
		}

		if (Keyboard.current.digit1Key.wasPressedThisFrame)
		{
			currentTool = ToolType.plough;
			itemSwitched = true;
		}
		if (Keyboard.current.digit2Key.wasPressedThisFrame)
		{
			currentTool = ToolType.wateringCan;
			itemSwitched = true;
		}
		if (Keyboard.current.digit3Key.wasPressedThisFrame)
		{
			currentTool = ToolType.seeds;
			itemSwitched = true;
		}
		if (Keyboard.current.digit4Key.wasPressedThisFrame)
		{
			currentTool = ToolType.basket;
			itemSwitched = true;
		}

		if (itemSwitched == true)
		{
			UIController.instance.SwitchItem((int)currentTool);
		}

		if (actionInput.action.WasPressedThisFrame())
		{
			UseTool();
		}

		if (toolWaitCounter > 0)
		{
			theRB.linearVelocity = Vector2.zero;
			toolWaitCounter -= Time.deltaTime;
		}
		else
		{
			anim.SetFloat("speed", theRB.linearVelocity.magnitude);
		}
	}

	void UseTool()
	{
		// bunch of tools
		GrowBlock block = null;
		block = FindFirstObjectByType<GrowBlock>();

		toolWaitCounter = toolWaitTime;

		if (block != null)
		{
			switch (currentTool)
			{
				case ToolType.plough:
					anim.SetTrigger("plough");
					block.PloughSoil();
					break;
				case ToolType.wateringCan:
					anim.SetTrigger("water");
					block.WaterSoil();
					break;
				case ToolType.seeds:
					block.PlantCrop();
					break;
				case ToolType.basket:
					block.HarvestCrop();
					break;
			}
		}
	}
}
