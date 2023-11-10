using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTL : MonoBehaviour
{
  
    const float ttl = 9F;
    float lifeTime = ttl;
  
  //life time for the spike ball
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            lifeTime = ttl;
            gameObject.SetActive(false);
        }
    }
}
