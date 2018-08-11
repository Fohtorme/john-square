using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    // Camera target
    public GameObject target;
    private GameObject currentTarget;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        defineTarget();
	}

    // Define camera target
    void defineTarget()
    {
        if (target == null) return;
        if (target == currentTarget) return;
        Debug.Log("Camera defined to " + target.name);
        currentTarget = target;
        this.gameObject.transform.SetParent(target.transform);
        this.gameObject.transform.localPosition = new Vector3(0, 0, -5);
        this.gameObject.transform.localRotation = new Quaternion();
    }
}
