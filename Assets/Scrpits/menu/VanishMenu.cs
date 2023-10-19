using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishMenu : MonoBehaviour
{
    [SerializeField] private GameObject sphere;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(sphere.transform.position, this.transform.position));

        if (Vector3.Distance(sphere.transform.position, this.transform.position) < 0.02)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
