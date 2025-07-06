using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D			theRB;
	public float				moveSpeed;

	

	public InputActionReference	moveInput;
	public InputActionReference	actionInput;
	public Animator				anim;

	public enum ToolType
	{
		plough,
		wateringCan,
		seeds,
		basket
	}

	public ToolType				currentTool;

	public float				toolWaitTime;
	public float				toolWaitCounter;

	public Transform			toolIndicator;

	bool						itemSwitched;
	public float				toolRange;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		toolRange = 1f;
		toolWaitTime = .5f;
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

		toolIndicator.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
		toolIndicator.position = new Vector3(toolIndicator.position.x, toolIndicator.position.y, 0);

		if (Vector3.Distance(toolIndicator.position, transform.position) > toolRange)
		{
			Vector2 direction = toolIndicator.position - transform.position;
			direction = direction.normalized * toolRange;

			toolIndicator.position = transform.position + new Vector3(direction.x, direction.y, 0f);
		}
		float x = Mathf.FloorToInt(toolIndicator.position.x) +.5f;
		float y = Mathf.FloorToInt(toolIndicator.position.y) +.5f;
		toolIndicator.position = new Vector3(x, y, 0f);
	}

	void UseTool()
	{
		// bunch of tools
		GrowBlock block = null;
		//block = FindFirstObjectByType<GrowBlock>();
		block = GridController.instance.GetBlockAt(toolIndicator.position.x -.5f, toolIndicator.position.y -.5f);

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
