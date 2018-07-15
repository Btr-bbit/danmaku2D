using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class testPlayer : Player {
	private Rigidbody2D rb;
	private Animator anim;
    private Transform pos;
	public float testForceModifier;
	public float maxSpeed;
	private const int LEFT = -1, RIGHT = 1;
	private int direction = LEFT;

    // Use this for initialization
    new void Start () {
        base.Start();

        dodgeIndicator.enabled = false;
		rb = GetComponent<Rigidbody2D>();
        pos = transform.Find("Sprites");
        anim = pos.gameObject.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        processDodge();
        if (invincibleLayer < 0)
        {
            invincibleLayer = 0;
        }
	}

    void FixedUpdate()
    {
        if (isDodging)
        {
            return;
        }
		
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		//限制速度不超过maxSpeed
		float l = rb.velocity.magnitude;
		if (l > maxSpeed) rb.velocity *= maxSpeed / l;
		anim.SetFloat("speed", l);


		//当输入和当前速度反向时，立即把那个速度分量设成反向0.4倍，去掉减速的过程
		if (x * rb.velocity.x < 0) rb.velocity = new Vector2(-0.4f * rb.velocity.x, rb.velocity.y);
		if (y * rb.velocity.y < 0) rb.velocity = new Vector2(rb.velocity.x, -0.4f * rb.velocity.y);

		rb.AddForce(new Vector2(x, y) * testForceModifier);

		int newDirection = (rb.velocity.x > 0) ? RIGHT : LEFT;

        //require l > 0.1 to avoid shaking when the velocity is low
		if (newDirection != direction && l > 0.1f){
			Vector3 s = pos.localScale;
			s.x *= -1;
			pos.localScale = s;
			direction = newDirection;
		}

	}

    private void processDodge()
    {
        if (isDodging)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            isDodging = true;
            dodgeIndicator.enabled = true;
            StartCoroutine(__processDodge());
        }
    }

    private IEnumerator __processDodge()
    {
        onPlayerDodge.Invoke();
        float passedTime = 0;
        moveSpeed = dodgeSpeed.Evaluate(passedTime)*moveBaseSpeed;
        invincibleLayer += 1;
        bool flag = false;
        while (passedTime < totalDodgeTime)
        {
            yield return new WaitForEndOfFrame();
            passedTime += Time.deltaTime;
            moveSpeed = dodgeSpeed.Evaluate(passedTime);
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            if ((!flag) && (passedTime > invincibleDodgeTime))
            {
                invincibleLayer -= 1;
                flag = true;
            }
        }
        isDodging = false;
        dodgeIndicator.enabled = false;
        moveSpeed = moveBaseSpeed;
    }

	private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject reward = collision.gameObject;
        if (reward.tag == "Supply")
        {
            Destroy(reward);
        }
        else if (reward.tag == "Treasure")
        {

        }
	}
}
