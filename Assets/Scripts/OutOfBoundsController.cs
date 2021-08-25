using UnityEngine;
using System.Collections;

public class OutOfBoundsController : MonoBehaviour
{
	public GameObject ball;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.Equals(ball))
		{
			BallController ballController = ball.GetComponent(typeof(BallController)) as BallController;
			if (null != ballController)
			{
				ballController.MoveToOriginalPosition();
			}
		}
	}
}
