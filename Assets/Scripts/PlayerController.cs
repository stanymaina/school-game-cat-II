using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GameObject topWall;
	public GameObject floor;
	public GameObject rightWall;
	public GameObject leftWall;

	// Use this for initialization
	void Start()
	{
          // StartCoroutine(SoundOut());
          // audioSource.Play();
	}

	void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		this.MovePlayer(moveHorizontal, moveVertical);
	}

	private void MovePlayer(float horizontalInput, float verticalInput)
	{
		float newPosX = transform.position.x + (horizontalInput*Time.deltaTime*speed);
		float newPosY = transform.position.y + (verticalInput*Time.deltaTime*speed);
		float offsetX = Mathf.Abs(transform.localScale.x) / 2.0f;
		float offsetY = Mathf.Abs(transform.localScale.y) / 2.0f;
		float minX = this.leftWall.transform.position.x + offsetX;
		float maxX = this.rightWall.transform.position.x - offsetX;
		float minY = this.floor.transform.position.y + offsetY;
		float maxY = this.topWall.transform.position.y - offsetY;
		float posX = Mathf.Clamp(newPosX, minX, maxX);
		float posY = Mathf.Clamp(newPosY, minY, maxY);

		transform.position = new Vector3(posX, posY, transform.position.z);
	}
    // IEnumerator SoundOut()
    // {
    //     while (keepPlaying){
    //         GetComponent<AudioSource>().PlayOneShot(awoogah);  
    //         Debug.Log("ChOO-ChOO");
    //         yield return new WaitForSeconds(carwait);
    //     }
    // }
}
