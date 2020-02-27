using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float turnSpeed = 45f;
    public float jumpHeight = 1f;

    public float currentMoveSpeed;
    public float currentTurnSpeed;
    public float currentJumpHeight;

    public float xp = 0;
    public float xpForNextLevel = 10;
    public int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetXpForNextLevel();
        SetCurrentMoveSpeed();
        SetCurrentTurnSpeed();
        SetCurrentJumpHeight();

    }

    void SetXpForNextLevel()
    {
        xpForNextLevel = (10f + (level * level * 0.1f));
        Debug.Log("xpForNextLevel " + xpForNextLevel);
    }

    void SetCurrentMoveSpeed()
    {
        currentMoveSpeed = this.moveSpeed + (this.moveSpeed * 0.1f * level);
        Debug.Log("currentMoveSpeed = " + currentMoveSpeed);
    }

    void SetCurrentTurnSpeed()
    {
        currentTurnSpeed = this.turnSpeed + (this.turnSpeed * (level * 0.1f));
        Debug.Log("currentTurnSpeed = " + currentTurnSpeed);
    }

    void SetCurrentJumpHeight()
    {
        currentJumpHeight = this.jumpHeight + (this.jumpHeight * (level * 0.1f));
        Debug.Log("currentJumpHeight = " + currentJumpHeight);
    }

    void LevelUp()
    {
        xp = 0f;
        level++;
        Debug.Log("level" + level);
        SetXpForNextLevel();
        SetCurrentMoveSpeed();
        SetCurrentTurnSpeed();
        SetCurrentJumpHeight();
    }

    public void GainXP(int xpToGain)
    {
        xp += xpToGain;
        Debug.Log("Gained " + xpToGain + "XP, Current XP = " + xp + "XP needed to reach next level = " + xpForNextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (xp >= xpForNextLevel)
        {
            LevelUp();
        }

        if (Input.GetKey(KeyCode.W) == true) { this.transform.position += this.transform.forward * Time.deltaTime * this.moveSpeed; }
        if (Input.GetKey(KeyCode.S) == true) { this.transform.position -= this.transform.forward * Time.deltaTime * this.moveSpeed; }

        if (Input.GetKey(KeyCode.A) == true) { this.transform.Rotate(this.transform.up, Time.deltaTime * -this.turnSpeed); }
        if (Input.GetKey(KeyCode.D) == true) { this.transform.Rotate(this.transform.up, Time.deltaTime * this.turnSpeed); }

        if (Input.GetKey(KeyCode.Space) == true && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.01f)
        {
            this.GetComponent<Rigidbody>().velocity += Vector3.up * this.jumpHeight;
        }
    }
}
