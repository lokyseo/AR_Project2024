using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunLeftRightCollision : MonoBehaviour
{
    float moveSpeed;

    void Start()
    {
        moveSpeed = 500.0f;
    }

    void Update()
    {
        transform.localPosition += Vector3.down * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (collision.transform.tag == "Failed")
        {
            Destroy(this.gameObject);
        }
    }

}
