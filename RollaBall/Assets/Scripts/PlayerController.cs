using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public static int antiAliasing;

	private Rigidbody rb;

	public GameObject Pickup;
    public ModeController GamePlay;
    Collider other;
    

	void Start ()
	{
		QualitySettings.antiAliasing = 2;
		rb = GetComponent<Rigidbody>();      
	}

	void FixedUpdate ()
	{
        Vector3 vector = new Vector3();
        if (Application.isEditor)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);
        }
        else
        {
			vector.x = Input.acceleration.x;
			vector.y = Input.acceleration.z;
            vector.z = Input.acceleration.y;
		}


        // Physics.gravity = 5.0f * vector.normalized;

	}

}