using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAggro : MonoBehaviour {
	public int aggro = 10;
    public int decreaseAggro = 5;
    public int increaseAggro = 5;
    public int minAggro = 10;
    public int maxAggro = 100;
    public bool decreasing = false;
    public bool increasing = true;
    
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
                if (increasing)
                    aggro += increaseAggro;
                if (aggro > maxAggro)
                    aggro = maxAggro;
                if (decreasing)
                    aggro -= decreaseAggro;
                if (aggro < minAggro)
                    aggro = minAggro;
        }
    }
	public int addAggro(int addedAggro){
		aggro += addedAggro;
        if (aggro > maxAggro)
            aggro = maxAggro;
        if (aggro < minAggro)
            aggro = minAggro;
		return(aggro);
	}
    public int reduceAggro(int subAggro){
		addAggro(subAggro);
		return(aggro);
	}
}
