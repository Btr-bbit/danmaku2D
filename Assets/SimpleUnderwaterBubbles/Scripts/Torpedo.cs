using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : MonoBehaviour {

    Rigidbody2D rb;
    [SerializeField]
    private float speed = 10.0f;

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    // Use this for initialization
    void Start () {
       
	}

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed ,0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
