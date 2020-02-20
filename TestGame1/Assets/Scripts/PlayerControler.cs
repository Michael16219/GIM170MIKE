using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;
    public float jumpHeight = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true) { this.transform.position += this.transform.forward * Time.deltaTime * this.moveSpeed; }
        if (Input.GetKey(KeyCode.DownArrow) == true) { this.transform.position -= this.transform.forward * Time.deltaTime * this.moveSpeed; }

        if (Input.GetKey(KeyCode.LeftArrow) == true) { this.transform.Rotate(this.transform.up, Time.deltaTime * -this.turnSpeed); }
        if (Input.GetKey(KeyCode.RightArrow) == true) { this.transform.Rotate(this.transform.up, Time.deltaTime * this.turnSpeed); }

        if (Input.GetKey(KeyCode.Space) == true && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.01f)
        {
            this.GetComponent<Rigidbody>().velocity += Vector3.up * this.jumpHeight;
        }
    }
}
