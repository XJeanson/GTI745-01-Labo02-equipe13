using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{ 
    public PathCreator pathCreator;
    public float speed = 1f;
    float distanceTreavelled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTreavelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTreavelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTreavelled);
        
    }
}
