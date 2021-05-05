using UnityEngine;

public class collect : MonoBehaviour {

	private HingeJoint2D joint;
	private bool closer = false, ended = false;
	private weight Weight;
	private Rigidbody2D rb, weightRB;
	private LineRenderer rend;

	void Awake()
	{
		rend = GetComponent<LineRenderer> ();
		rend.SetPosition (0, transform.position);
		rend.SetPosition (1, transform.position);
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Pickup")) 
		{
			Weight = other.GetComponent<weight> ();
			Win ();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("Pickup")) 
		{
			closer = false;
		}
	}

	void Catch()
	{
		weightRB = Weight.GetComponent<Rigidbody2D> ();
		weightRB.gravityScale = 0;
		closer = true;
	}

	void Win()
	{
		Catch ();
	}

	void Update()
	{
		if (!closer || ended)
			return;

		weightRB.bodyType = RigidbodyType2D.Static;

		Transform target = Weight.transform;

		if (target.position.x > transform.position.x) 
		{
			Weight.transform.Translate (Vector2.left * Time.deltaTime);
		}
		else if (target.position.x < transform.position.x) 
		{
			Weight.transform.Translate (-Vector2.left * Time.deltaTime);
		}
		if (target.position.y > transform.position.y) 
		{
			Weight.transform.Translate (Vector2.down * Time.deltaTime);
		}
		else if (target.position.y < transform.position.y) 
		{
			Weight.transform.Translate (Vector2.up * Time.deltaTime);
		}

		if ((target.position - transform.position).magnitude < 0.5f && !ended) 
		{
			ended = true;
			rend.SetPosition (1, transform.position);
			FindObjectOfType<win> ().Win ();
			Destroy (target.gameObject);
			return;
		}

		Vector3 dir = Weight.transform.position;


		rend.SetPosition (1, dir);
	}
}
