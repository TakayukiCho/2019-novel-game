using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

	WaveConfig waveConfig;
	List<Transform> waypoints;
	int nextIndex = 0;
	[SerializeField] float moveSpeed = 2f;

	// Use this for initialization
	void Start () {

		waypoints = waveConfig.WaveWaypoints;
		transform.position = waypoints[nextIndex].position;
		nextIndex++;
	}

	public void SetWaveConfig(WaveConfig waveConfigArg){
		waveConfig = waveConfigArg;
	}

	// Update is called once per frame
	void Update () {
		if(nextIndex + 1 <= waypoints.Count){
			var nextWayPoint = waypoints[nextIndex].position;
			var step = waveConfig.moveSpeed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, nextWayPoint, step);
			if(transform.position == waypoints[nextIndex].position){
				nextIndex++;
			}
		} else{
			Destroy(gameObject);
		}
	}
}
