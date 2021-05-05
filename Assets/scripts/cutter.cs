using UnityEngine;

public class cutter : MonoBehaviour {

	void Update()
	{
		if (Input.GetMouseButton (0)) 
		{
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (hit.collider != null) 
			{
				if (hit.collider.tag == "link") 
				{
					Destroy (hit.collider.gameObject);
				} else if (hit.collider.tag == "hook") 
				{
					Destroy (hit.transform.parent.gameObject);
				}
			}
		}
	}
}
