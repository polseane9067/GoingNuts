﻿using UnityEngine;
using System.Collections;

public class enemyPatrol : MonoBehaviour {

	public Transform[] patrol;
	public float moveSpeed;
    public float rotateSpeed = 2.0f;
    public float pauseTime;
    public bool stops;
    public bool playerFound;

    int Currentpoint;
	bool rotating;

    float startTime;
	
	// Use this for initialization
	void Start () 
	{
		transform.position = patrol[0].position;
		Currentpoint = 0;
        startTime = pauseTime;
	}

    void Update()
    {
        if (!playerFound)
        {
            Quaternion newRotation;
            Vector3 offset = transform.position - patrol[Currentpoint].position;
            if (offset.magnitude <= 0.01)
            {
                if (stops)
                {
                    if (startTime <= 0)
                    {
                        Currentpoint++;
                        startTime = pauseTime;
                    }
                    startTime -= Time.deltaTime;
                }
                else
                    Currentpoint++;
            }

            if (Currentpoint >= patrol.Length)
                Currentpoint = 0;

            if (Currentpoint != 0)
                newRotation = Quaternion.LookRotation(patrol[Currentpoint - 1].transform.forward);
            else
                newRotation = Quaternion.LookRotation(patrol[patrol.Length - 1].transform.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 7);
            transform.position = Vector3.MoveTowards(transform.position, patrol[Currentpoint].position, moveSpeed * Time.deltaTime);
            
            if (!stops)
                StartCoroutine(TurnTowards(-transform.forward));
        }
    }
	
	IEnumerator TurnTowards(Vector3 lookAtTarget) 
	{    
		
		if(rotating == false) 
		{
			Quaternion newRotation = Quaternion.LookRotation(lookAtTarget - transform.position);
			newRotation.x = 0;
			newRotation.z = 0;
			
			for (float u = 0.0f; u <= 1.0f; u += Time.deltaTime * rotateSpeed) 
			{
				rotating = true;
				transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, u);
				
				yield return null;
			}
			rotating = false;
		}
	}
}