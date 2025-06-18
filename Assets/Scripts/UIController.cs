using UnityEngine;

public class UIController : MonoBehaviour
{
	public static UIController instance;
	void Awake()
	{
		instance = this;
	}


	public GameObject[] toolBarItems;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		DisplayToolBar();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void DisplayToolBar()
	{
		for (int i = 0; i < toolBarItems.Length; i++)
		{
			toolBarItems[i].transform.position = new Vector3(500 + 150 * i, 100, 0);
		}
	}

	void AddOrRemoveToolItem()
	{

	}

	public void SwitchItem(int selected)
	{
		foreach (GameObject item in toolBarItems)
		{
			Transform activeIconTransform = item.transform.Find("ActiveIcon");
			if (activeIconTransform != null)
				activeIconTransform.gameObject.SetActive(false);
			if (item == toolBarItems[selected])
			{
				activeIconTransform.gameObject.SetActive(true);
			}
		}
	}
}
