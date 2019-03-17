using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    public float speed = 1.5f;

    public Transform head;

    public KeyCode jumpButton = KeyCode.Space; // клавиша для прыжка
    public float jumpForce = 10; // сила прыжка
    public float jumpDistance = 1.2f; // расстояние от центра объекта, до поверхности

    private Vector3 direction;
    private int layerMask;
    private Rigidbody body;
  

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
        layerMask = 1 << gameObject.layer | 1 << 2;
        layerMask = ~layerMask;
    }

    void FixedUpdate()
    {
        // Ограничение скорости, иначе объект будет постоянно ускоряться
        if (Mathf.Abs(body.velocity.x) > speed)
        {
            body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * speed, body.velocity.y, body.velocity.z);
        }
        if (Mathf.Abs(body.velocity.z) > speed)
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * speed);
        }
    }

    bool GetJump() // проверяем, есть ли коллайдер под ногами
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, jumpDistance, layerMask))
        {
            return true;
        }

        return false;
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpButton) && GetJump())
        {
            body.velocity = new Vector2(0, jumpForce);
        }
    }
}

