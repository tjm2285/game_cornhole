using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{

    private GameObject _prefab;
    private Vector3 _direction;
    private bool isMouseDown = false;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        _prefab = Resources.Load<GameObject>("projectile");
        _direction = transform.forward;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;


        }


        if(isMouseDown)
        {
            speed+=0.4f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(speed);
            //transform.LookAt(Input.mousePosition);
            Vector3 mouse = Input.mousePosition;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                                                                mouse.x,
                                                                mouse.y,
                                                                transform.position.y));
            Vector3 forward = mouseWorld - transform.position;
            transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
            _direction = transform.forward;
            GameObject projectile = Instantiate<GameObject>(_prefab);



            projectile.transform.position = transform.position + _direction * 2;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = _direction * speed;
            speed = 0;
            isMouseDown = false;
        }
    }
}
