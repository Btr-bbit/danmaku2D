using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    public GameObject runAnimation;
    public float animDelay;

	// Use this for initialization
	void Start () {
        StartCoroutine(generateRunAnimation());
    }
	
	// Update is called once per frame
	void Update () {

	}

    private IEnumerator generateRunAnimation()
    {
        if (runAnimation != null)
        {
            while (true)
            {
                Vector3 moveDirection = getMoveDirection();
                Debug.Log(moveDirection);
                if (moveDirection != Vector3.zero)
                {
                    Quaternion rot = Quaternion.identity;
                    rot.SetFromToRotation(Vector3.right, moveDirection);
                    Instantiate(runAnimation, gameObject.transform.position, rot);
                }
                yield return new WaitForSeconds(animDelay);
            }
        }
    }

    private Vector3 getMoveDirection()
    {
        return gameObject.GetComponent<Player>().moveDirection;
    }
}
