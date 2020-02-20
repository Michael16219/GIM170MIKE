using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public float spinSpeed = 100f;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0f, 0f, Time.deltaTime * this.spinSpeed);
    }
    private void onTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
