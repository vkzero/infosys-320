using UnityEngine;
using System.Collections;

public class myCubeScript : MonoBehaviour {
    private bool selected = false;

    // Use this for initialization
    void Start () {
 	}
	
    public void setSize(float size)
    {
        transform.localScale = new Vector3(size, size, size);
    }

	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown() {
        selected = !selected;
        if (selected) {
            transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
        } else {
            transform.localScale -= new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
