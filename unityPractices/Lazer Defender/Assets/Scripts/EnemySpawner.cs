using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField] WaveConfig[] waves;
	int startingWave = 0;

	[SerializeField] bool looping = false;

	// Use this for initialization
	IEnumerator Start () {
		do {
			var currentWave = waves[startingWave];
			yield return StartCoroutine(SpawnAllWaves());
		} while(looping);
	}

	private IEnumerator SpawnAllWaves(){
		foreach (var wave in waves){
			yield return StartCoroutine(SpawnAllEnemiesInWave(wave));
		}
	}

	private IEnumerator SpawnAllEnemiesInWave(WaveConfig wave){
		for (int i = 0; i < wave.enemyQuantity; i++){
			var enemy = Instantiate(
				wave.EnemyPrefab,
				wave.WaveWaypoints[0].transform.position,
				Quaternion.identity
			);

			enemy.GetComponent<EnemyPathing>().SetWaveConfig(wave);

			yield return new WaitForSeconds(wave.timeBetweenSpawns);
		}
	}

}
