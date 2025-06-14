using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	private Transform	target;

	public  Transform	clampMin;
	public  Transform	clampMax;


	private Camera		cam;
	private float		halfWidth;
	private float		halfHeight;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		target = FindAnyObjectByType<PlayerController>().transform;

		clampMin.SetParent(null);
		clampMax.SetParent(null);

		cam = GetComponent<Camera>();
		halfHeight = cam.orthographicSize;
		halfWidth = cam.orthographicSize * cam.aspect;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

		Vector3 clampedPosition = transform.position;

		clampedPosition.x = Mathf.Clamp(clampedPosition.x, clampMin.position.x + halfWidth, clampMax.position.x - halfWidth);
		clampedPosition.y = Mathf.Clamp(clampedPosition.y, clampMin.position.y + halfHeight, clampMax.position.y - halfHeight);

		transform.position = clampedPosition;
	}
}
