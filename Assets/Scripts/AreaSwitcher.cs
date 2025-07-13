using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaSwitcher : MonoBehaviour
{
	public WorldData	worldData;

	public Transform	startPoint;
	public bool			inside;

	void Start()
	{
		PlayerController.instance.transform.position = startPoint.position;
	}
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			if (!inside)
				SceneManager.LoadScene(worldData.houseScene);
			else
				SceneManager.LoadScene(worldData.outsideScene);
		}
	}
}
