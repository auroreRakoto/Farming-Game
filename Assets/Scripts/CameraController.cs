using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	private Transform	target;

	public  WorldData   worldData;


	private Camera		cam;
	private float		halfWidth;
	private float		halfHeight;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		target = FindAnyObjectByType<PlayerController>().transform;

        //clampMin.transform.position = new Vector3(worldData.);

		//clampMin.SetParent(null);
		//clampMax.SetParent(null);

		cam = GetComponent<Camera>();
		halfHeight = cam.orthographicSize;
		halfWidth = cam.orthographicSize * cam.aspect;
	}

	// Update is called once per frame
	void Update()
    {
        // Follow the target
        Vector3 newPosition = target.position;

        // Clamp the camera to stay within bounds
        newPosition.x = Mathf.Clamp(newPosition.x, worldData.origin.x + halfWidth, worldData.origin.x + worldData.width - halfWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, worldData.origin.y + halfHeight, worldData.origin.y + worldData.height - halfHeight);

        // Keep original Z (camera depth)
        newPosition.z = transform.position.z;

        // Apply the position
        transform.position = newPosition;
    }

}
