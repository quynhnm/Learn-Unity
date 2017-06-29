using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

    public float speed;
    public float titl;
    public Boundary boundary;
    private Rigidbody rb;
    private AudioSource audio;

    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public Transform shotSpawn4;

    public float fireRate;
//    public TouchPad touchPad;
    private float nextFire;
    private Quaternion calibrationQuaternion;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(shot, shotSpawn2.position, shotSpawn.rotation);
            Instantiate(shot, shotSpawn3.position, shotSpawn.rotation);
            Instantiate(shot, shotSpawn4.position, shotSpawn.rotation);
            audio.Play();
        }
    }

    void CalibrateAccellerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    Vector3 FixAccelleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }


    private void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Vector3 accelerationRaw = Input.acceleration;
        //Vector3 acceleration = FixAccelleration(accelerationRaw);
        //Vector3 movement = new Vector3(acceleration.x, 0.0f, acceleration.y);
        //Vector2 direction = touchPad.GetDirection();
        //Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);

        //rb.velocity = movement * speed;

        //rb.position = new Vector3(
        //    Mathf.Clamp(rb.position.x, 0, 1),
        //    0.0f,
        //    Mathf.Clamp(rb.position.z, 0, 1)
        // );
        if (Input.GetMouseButton(0)) { 
            Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0.05f, -6.0f));
            Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0.95f, 0));

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            pos = new Vector3(Mathf.Clamp(pos.x,min.x,max.x),0, Mathf.Clamp(pos.z + 2.0f, min.z, max.z));

            //pos.x = Mathf.Clamp(pos.x, min.x, max.x);
            //pos.z = Mathf.Clamp(pos.z, min.z, max.z);

            //transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -titl);
        }
    }


}
