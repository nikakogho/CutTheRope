using UnityEngine;

public class rope : MonoBehaviour {

	public bool generateOnStart = true;
	public Rigidbody2D hook;
	Rigidbody2D previousRB;
	public GameObject linkPrefab;
	private weight Weight;

	public int links = 7;

	void OnEnable()
	{
		Weight = FindObjectOfType<weight> ();
		previousRB = hook;
		if(generateOnStart)
		GenerateRope ();
	}

	void OnDisable()
	{
		for (int i = 1; i < transform.childCount; i++) 
		{
			Destroy (transform.GetChild (i).gameObject);
		}
	}

	void GenerateRope()
	{
		for (int i = 0; i < links; i++) 
		{
			GameObject link = Instantiate (linkPrefab, transform);

			HingeJoint2D joint = link.GetComponent<HingeJoint2D> ();

			joint.connectedBody = previousRB;

			if (i < links - 1)
			{
				previousRB = link.GetComponent<Rigidbody2D> ();
			} else 
			{
				Weight.ConnectRopeToEnd(link.GetComponent<Rigidbody2D>());
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Pickup") && !generateOnStart) 
		{
			GenerateRope ();
			GetComponent<CircleCollider2D> ().enabled = false;
		}
	}
}
