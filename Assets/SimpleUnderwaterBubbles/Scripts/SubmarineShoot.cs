using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineShoot : MonoBehaviour {

    [SerializeField]
    private GameObject TorpedoPrefab;
    [SerializeField]
    private float realodTime = 10.0f;
    [SerializeField]
    private Vector3 torpedoOffset = new Vector3(0, -.3f, 0);

    private bool canShoot = true;

    public float RealodTime
    {
        get
        {
            return realodTime;
        }

        set
        {
            realodTime = value;
        }
    }

    public GameObject TorpedoPrefab1
    {
        get
        {
            return TorpedoPrefab;
        }

        set
        {
            TorpedoPrefab = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canShoot)
        {
            Shoot();
        }
    }

    protected void Shoot()
    {
        //Instantiate is a time-consuming function. If you need high performance, you should consider replacing this part with an object pool
        GameObject torpedo = Instantiate<GameObject>(TorpedoPrefab1);
        torpedo.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f) + torpedoOffset; //z - 0.1 to let the torpedo spawn behind the submarine
        torpedo.transform.localScale = transform.localScale; //Scale torpedo with submarine
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(realodTime);
        canShoot = true;
    }
}
