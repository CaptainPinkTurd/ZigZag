using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovementScript : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 5f;
    public static Animator animator;
    private float rotateValue = -90f;
    private bool startDelay = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (animator.GetBool("gameStarted"))
        {
            rb.transform.position += new Vector3(speed, 0f, Mathf.Abs(speed)) * Time.deltaTime;
            // rb.velocity = new Vector3(speed, 0f, Mathf.Abs(speed)); wrong 
        }
        if (rb.velocity.y < -1f)
        {
            animator.SetBool("isFalling", true);
            Invoke("ReactivateGame", 2f);
        }
        else
        {
            animator.SetBool("isFalling", false);
            CancelInvoke("ReactivateGame");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Camera.main.transform.Translate(new Vector3(0f, 1f, 1f) * Mathf.Abs(speed/2) * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (startDelay)
            {
                ScoreScript.score++; //score is being updated every frame in the scorescript update function
                rb.transform.Rotate(Vector3.up, rotateValue);
                speed = -speed;
                rotateValue = -rotateValue;
            }
            else
            {
                startDelay = true;
            }
                     
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (animator.GetBool("gameStarted"))
        {
            if (collision.gameObject.CompareTag("Road"))
            {
                Destroy(collision.gameObject, 1f);
            }
        }            
    }
    private void ReactivateGame()
    {
        SceneManager.LoadScene(0);
        animator.SetBool("isFalling", false);
        animator.SetBool("gameStarted", false);
    }
}
