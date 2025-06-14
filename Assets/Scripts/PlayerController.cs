using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D theRB;
	public float moveSpeed;

	public InputActionReference moveInput;
	public InputActionReference actionInput;
	public Animator anim;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		theRB.linearVelocity = moveInput.action.ReadValue<Vector2>().normalized * moveSpeed;

		if (theRB.linearVelocity.x < 0f)
			transform.localScale = new Vector3(-1f, 1f, 1f);
		else if (theRB.linearVelocity.x > 0f)
			transform.localScale = new Vector3(1f, 1f, 1f);

		if (actionInput.action.WasPressedThisFrame())
		{
			UseTool();
		}

		anim.SetFloat("speed", theRB.linearVelocity.magnitude);
	}

	void UseTool()
	{
		// bunch of tools
		GrowBlock block = null;
		block = FindFirstObjectByType<GrowBlock>();

		block.PloughSoil();
	}
}
