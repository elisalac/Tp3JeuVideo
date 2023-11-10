using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpikeTrapMotion : MonoBehaviour
{
    [SerializeField] Vector3 rotationPerSeconds = new Vector3(100, 0, 0);
    [SerializeField] Space space = Space.Self;    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationPerSeconds * Time.deltaTime, space);
    }
}
