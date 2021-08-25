using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
	public float initialVelocityScalar;

	private Rigidbody rigidBody;
	private Vector3 originalPosition;

	/// <summary>
	/// Moves to original position.
	/// Stops motion.
	/// </summary>
	public void MoveToOriginalPosition()
	{
		this.transform.position = this.originalPosition;
		this.rigidBody.velocity = Vector3.zero;
    }
	
	void Start()
	{
		this.rigidBody = this.GetComponent<Rigidbody>();
		this.originalPosition = this.transform.position;
	}

	void FixedUpdate()
	{
		this.StartIfStopped();
		this.KickInZ();
	}
	
	private Vector3 CreateVelocityVector()
	{
		Vector3 vector = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(0.1f, 1));
		vector.Normalize();
		return vector*this.initialVelocityScalar;
	}

	private void StartIfStopped()
	{
		if (this.rigidBody.velocity == Vector3.zero)
		{
			this.rigidBody.velocity = this.CreateVelocityVector();
		}
	}

	private void KickInZ()
	{
		Vector3 currentVelocity = this.rigidBody.velocity;
		if (currentVelocity.z < this.initialVelocityScalar)
		{
			this.rigidBody.velocity = new Vector3(currentVelocity.x, currentVelocity.y, Mathf.Sign(currentVelocity.z)*this.initialVelocityScalar);
		}
	}
}
