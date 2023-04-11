using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Metal"))
        {
            UI_Scenes.metal_sources++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Wood"))
        {
            UI_Scenes.wood_sources++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Rocks"))
        {
            UI_Scenes.rocks_sources++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Tools"))
        {
            UI_Scenes.other_sources++;
            Destroy(collision.gameObject);
        }
    }

}
