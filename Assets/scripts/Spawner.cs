using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //singleton instance
    public static Spawner instance {  get; private set; }

    //referances to planes prefab
    public GameObject redPlane;
    public GameObject OrangePlane;
    public GameObject greenPlane;

    //turret position
    private Vector3 turretPosition;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void setTurretPosition(Vector3 p_turretPosition)
    {
        turretPosition = p_turretPosition;
    }

    public void spawnPlane(GameObject plane)
    {
        // create an empty gameobject to work with transform
        GameObject planeSpawnPoint = new GameObject();

        //random height
        float extraheight = Random.Range(0.5f, 1.5f);

        //random depth
        float extraDepth = Random.Range(0.5f, 1.5f);

        //create the spawn point
        Vector3 planeSpawnPosition = new Vector3(0.0f, this.turretPosition.y + extraheight, this.turretPosition.z + extraDepth);

        //set position of the spawn
        planeSpawnPoint.transform.position = planeSpawnPosition;

        //instance the plane a the spawn
        Instantiate(plane, planeSpawnPoint.transform);
    }

    public void spawnRedPlane()
    {
        spawnPlane(redPlane);
    }
    
    public void spawnOrangePlane()
    {
        spawnPlane(OrangePlane);
    }

    public void spawnGreenPlane()
    {
        spawnPlane(greenPlane);
    }

    public void spawnRedPlaneAfterTime(float time)
    {
        Invoke("spawnRedPlane", time);
    }

    public void spawnOrangePlaneAfterTime(float time)
    {
        Invoke("spawnOrangePlane", time);
    }

    public void spawnGreenPlaneAfterTime(float time)
    {
        Invoke("spawnGreenPlane", time);
    }
}
