using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

	[SerializeField] GameObject enemyingPrefab;
	public GameObject EnemyPrefab {
		get {return enemyingPrefab;}
	}
	[SerializeField] GameObject pathPrefab;

	public List<Transform> WaveWaypoints {
	  get { return pathPrefab.transform.Cast<Transform>().ToList(); }
	}
	[SerializeField] public float timeBetweenSpawns {get;} = 0.5f;
	[SerializeField] public float spawnRandomFactor {get; } = 0.3f;
	[SerializeField] public int enemyQuantity {get; } = 5;

	[SerializeField] float FeededMoveSpeed = 2f;
	 public float moveSpeed { get {return FeededMoveSpeed;}}
}
