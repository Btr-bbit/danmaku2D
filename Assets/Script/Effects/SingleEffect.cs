using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleEffect : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
		if (info.normalizedTime >= 1.0f) Destroy(gameObject);
	}
}
