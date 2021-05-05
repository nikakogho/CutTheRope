using UnityEngine;

public class weight : MonoBehaviour {

	public float distanceFromChainEnd = -0.6f;

	public void ConnectRopeToEnd(Rigidbody2D endRb)
	{
		HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D> ();

		joint.autoConfigureConnectedAnchor = false;
		joint.connectedBody = endRb;
		joint.anchor = Vector2.zero;
		joint.connectedAnchor = new Vector2 (0, distanceFromChainEnd);
	}
}
