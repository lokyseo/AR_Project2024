using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    Vector3 direction;
    float destroyTime;
    void Start()
    {
        destroyTime = 5.0f;
        float randnum = Random.Range(-0.5f, 0.5f);

        if (this.transform.position.x < 0)
        {
            direction = Vector3.right + new Vector3(0, randnum, 0);
        }
        else if (this.transform.position.x > 0)
        {
            direction = Vector3.left + new Vector3(0, randnum, 0);
        }
        else if (this.transform.position.y < 0)
        {
            direction = Vector3.up + new Vector3(randnum, 0, 0);
        }
        else if (this.transform.position.y > 0)
        {
            direction = Vector3.down + new Vector3(randnum, 0, 0);
        }
    }

    void Update()
    {
        transform.Translate(direction * 5.0f * Time.deltaTime);

        destroyTime -= Time.deltaTime;
        if(destroyTime <=  0)
        {
            Destroy(gameObject);
        }
    }
}
