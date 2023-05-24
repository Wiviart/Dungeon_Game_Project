using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillerZone : MonoBehaviour
{

    CameraController cameraController;

    CultistBlueMagician cultistBlueMagician;

    private void Awake()
    {
        cameraController = FindAnyObjectByType<CameraController>();
        cultistBlueMagician = FindAnyObjectByType<CultistBlueMagician>();
    }

    float speedMove = 3f;
    // Update is called once per frame
    void Update()
    {
        if (!cultistBlueMagician.GetIsFallingWater() || transform.position.x < 6f)
        {
            if (transform.position.x < 72f && !cameraController.GetIsMovie())
            {
                KillerMovement();
            }
        }

        if (cultistBlueMagician.GetIsFallingWater() && transform.position.x > 6f)
        {
            transform.position = new Vector2(6f, transform.position.y);
        }
    }

    void KillerMovement()
    {
        Vector2 vector2 = transform.position;
        vector2.x += speedMove * Time.deltaTime;
        transform.position = vector2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}