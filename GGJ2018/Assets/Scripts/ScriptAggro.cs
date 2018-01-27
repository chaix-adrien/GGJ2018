using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAggro : MonoBehaviour {
	public int aggro = 10;
	public int increaseAggro = 5;
	public float aggroInterval = 1.0f;
	private float elapsed;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsed += Time.fixedDeltaTime;
        if (elapsed >= aggroInterval)
        {
			elapsed = elapsed % aggroInterval;
            bool hasObject = GetComponent<ScriptPlayer>().hasObject;
            if (hasObject && aggro < 100)
            {
                aggro += increaseAggro;
                if (!hasObject && aggro > 10)
                {
                    aggro -= increaseAggro;
                }
            }
        }
    }
	public int addAggro(int addedAggro){
		if (addedAggro+ aggro > 100) {
			aggro = 100;
		} else {
			aggro+=addedAggro;
		}
		return(aggro);
	}
}
