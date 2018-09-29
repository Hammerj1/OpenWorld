using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools {
    public static Vector3 RandomVector()
    {
        return new Vector3(Random.Range(0, 10), 5, Random.Range(0, 10));
    }
	
}
