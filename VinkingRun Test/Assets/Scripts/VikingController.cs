using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class VikingController : MonoBehaviour
{
    public Vector3 MovingDirection;

    //MeshRenderer mr;
    Rigidbody rb;
    Animator animator;
    public float jumpAmount = 10;
    [SerializeField] float movingSpeed = 10f;
    bool isJump = false;
    bool run = false;
    public bool canRotate = false;
    private void Awake()
    {
        Debug.Log("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        Transform t = GetComponent<Transform>();
        t.position = Vector3.one;

        //mr = GetComponent<MeshRenderer>();

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");

        //move over time
        //transform.localPosition += movingSpeed * Time.deltaTime * MovingDirection;

        //change color over time
        //mr.material.color = new Color((int)Time.time % 2 * 255f, 255f, 255f);
        transform.localPosition += movingSpeed * Time.deltaTime * transform.forward;
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition -= movingSpeed * Time.deltaTime * transform.forward;
            run = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= movingSpeed * Time.deltaTime * transform.right;
            run = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * transform.right;
            run = true;
        }
        if (Input.GetKey(KeyCode.E) && canRotate)
        {
            transform.Rotate(0, 90, 0);
            canRotate = false;
        }
        if (Input.GetKey(KeyCode.Q) && canRotate)
        {
            transform.Rotate(0, -90, 0);
            canRotate = false;
        }
        isJump = false;
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isJump)
            {
                rb.AddForce(Vector3.up * jumpAmount);
                isJump = true;
            }
        }
        
        animator.SetBool("Run", run);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Plane")
        {
            isJump = false;
        }
    }
}
