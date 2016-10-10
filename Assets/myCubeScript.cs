using UnityEngine;
using System.Collections;

public class myCubeScript : MonoBehaviour {



    // Use this for initialization
    void Start () {
 	}
	
    public void setSize(float size)
    {
        this.transform.localScale = new Vector3(size, size, size);
    }

	// Update is called once per frame
	void Update () {


	}
}
