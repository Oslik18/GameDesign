using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public static int count_object = 0;
    public TextMeshProUGUI count_destroy_objects;
    private AudioSource sound;
    private int count_sound = 0;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        count_destroy_objects.text = count_object.ToString();
        if (count_object != count_sound)
        {
            sound.Play();
            count_sound++;
        }

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rocks"))
        {
            Debug.Log("Collision OnCollisionEnter: :" + collision.gameObject.name);
        }

    }

}
