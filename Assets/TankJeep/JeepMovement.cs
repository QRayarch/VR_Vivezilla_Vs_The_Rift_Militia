using UnityEngine;
using System.Collections;

public class JeepMovement : MonoBehaviour {

    Rigidbody rb;

    public float accAmount;
    public float maxSpeed;
    public float turnSpeed;
    public float drift;

    bool onGround;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision) {
        onGround = true;
    }

    void OnCollisionExit(Collision collision) {
        onGround = false;
    }


    public void MoveFwd(float amount){
        Vector3 target = rb.velocity;


        target += transform.forward * accAmount * Time.deltaTime * amount;
        rb.velocity = target;

        float t = rb.velocity.magnitude;
        if (t > maxSpeed)
        {
            rb.velocity = rb.velocity / t * maxSpeed;
        }

        //Debug.Log(rot);
        //Debug.Log(onGround);
        Vector3 drag = rb.velocity * (1.0f - Vector3.Dot(rb.velocity.normalized, transform.forward)) * drift;
        rb.velocity -= drag;


    }

    public void doRotation(float rotAmount)
    {
        if (rotAmount > 0.8f)
        {
            Quaternion temp = transform.rotation;
            temp = Quaternion.LookRotation(transform.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, temp, turnSpeed * rotAmount * Time.deltaTime);
        }
        else if (rotAmount < -0.5f)
        {
            Quaternion temp = transform.rotation;
            temp = Quaternion.LookRotation(-transform.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, temp, turnSpeed * (-rotAmount) * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update() {
        bool reverse = false;
        Vector3 target = rb.velocity;
        //if (Input.anyKey && onGround) {
        //    Vector3 target = rb.velocity;
        //    if (Input.GetKey(KeyCode.W)) {
        //        target += transform.forward * accAmount * Time.deltaTime;                
        //    }
        //    if(Input.GetKey(KeyCode.D)) {
        //        Quaternion temp = transform.rotation;
        //        temp = Quaternion.LookRotation(transform.right);
        //        transform.rotation = Quaternion.Slerp(transform.rotation,temp,turnSpeed * Time.deltaTime);
        //    }
        //    if(Input.GetKey(KeyCode.A)) {
        //        Quaternion temp = transform.rotation;
        //        temp = Quaternion.LookRotation(-transform.right);
        //        transform.rotation = Quaternion.Slerp(transform.rotation,temp,turnSpeed * Time.deltaTime);
        //    }
        //    if (Input.GetKey(KeyCode.S)) {
        //        target += -transform.forward * accAmount * Time.deltaTime * 0.75f;         
        //        reverse = true;       
        //        Debug.Log("reverse");
        //    }
        //    rb.velocity = target;
        //    float t = rb.velocity.magnitude;
        //    if(t > maxSpeed) {
        //        rb.velocity = rb.velocity/t * maxSpeed;
        //    }
        //}
    }
}
