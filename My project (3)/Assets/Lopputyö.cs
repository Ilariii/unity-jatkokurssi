using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lopputyö : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        AS = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Pelaajan kääntäminen
        Vector3 rotation = transform.up * Input.GetAxis("Horizontal");
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
        playerInput = transform.forward * Input.GetAxis("Vertical") * speed;

        playerInput.y = rb.velocity.y;

        // Onko pelaajan kiihtyvyys y -0.05 ja 0.05 välillä (eli suurinpiirtein 0)
        if (rb.velocity.y > -0.05f && rb.velocity.y < 0.05f)
        {
            // jos pelaaja painaa välilyöntiä
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // lisätään hahmolle voimaa YLÖSPÄIN kerrottuna hypyn voima arvolla
                rb.AddForce(Vector3.up * jumpForce);
                AS.PlayOneShot(jumpSound, 1);
                anim.Play("Jump", 0);
            }
        }

        anim.SetFloat("velocity", playerInput.magnitude);
    }
}
}
