using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoPeopleController : MonoBehaviour
{
    public GameObject startObject;
    public GameObject endObject;
    public bool isReverse;
    // Use this for initialization
    void Start()
    {
        if (this.transform.rotation.eulerAngles.y == 0)
            isReverse = true;
        else
            isReverse = false;
        //person = this.GetComponent<GameObject>();
    }
    private void Update()
    {
        if (this.transform.position.z > startObject.transform.position.z)
        {
            if (isReverse == true)
                this.transform.Rotate(0, 180, 0);
            isReverse = false;
        }
        else if (this.transform.position.z < endObject.transform.position.z)
        {
            if (isReverse == false)
                this.transform.Rotate(0, 180, 0);
            isReverse = true;
        }
    }
}
