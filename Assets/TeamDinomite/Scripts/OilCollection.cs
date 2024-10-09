using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilCollection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {

            Destroy(gameObject); // Deletes the original food object upon collision

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
