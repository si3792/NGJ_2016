﻿using UnityEngine;
using System.Collections;

public class WaveSpawn : MonoBehaviour {
	public float restMean = 6f;
	public float waveMeanStart = 12f;
	public float waveGrowth = 1.05f;
	public float Enemy1SpawnMeanStart = 2f;
	public float Enemy1SpawnMeanExpGrowth = 1f;
	public float Enemy1SpawnMeanLinearGrowth = 1f;
	public float uniformPercent = 0.5f;
	public float spawnTimeMean = 0.75f;
	public int maxBugs = 50;
	public static int globalWave = 0;
	public static int bugCount = 0;
	public int thisBugCount;
	public GameObject Enemy1;
	float timeToWave;
	float timeToEmit;
	float timeToWait;
	bool inWave;
	// Use this for initialization
	void Start () {
		timeToWave = restMean*Random.Range(uniformPercent,1+uniformPercent);
		timeToEmit = 0f;
		timeToWait = 0f;
		inWave = false;
	}

	void Awake() {
		globalWave = 0;
		bugCount = 0;
	}

	void FixedUpdate()
	{
		thisBugCount = bugCount;
		if (inWave) {
			if (timeToEmit < 0f) {
				emitWave();
				timeToEmit = Random.Range(
                    spawnTimeMean * uniformPercent, spawnTimeMean * (1 + uniformPercent));
			}
			if (timeToWait < 0f) {
				inWave = false;
				waveMeanStart *= waveGrowth;
				Enemy1SpawnMeanStart *= Enemy1SpawnMeanExpGrowth;
				Enemy1SpawnMeanStart += Enemy1SpawnMeanLinearGrowth;
				if (Random.Range (0.0f, 1.0f) < 0.3) {
                    globalWave++;
                }
                timeToWave = restMean * Random.Range(uniformPercent, 1f + uniformPercent);
			}
			timeToWait -= Time.deltaTime;
			timeToEmit -= Time.deltaTime;
		} else {
			if (timeToWave < 0f) {
				inWave = true;
				timeToEmit = spawnTimeMean * Random.Range (uniformPercent, 1f + uniformPercent);
				timeToWait = waveMeanStart * Random.Range (uniformPercent, 1f + uniformPercent);
			}
			timeToWave -= Time.deltaTime;
		}
	}
	void emitWave()
	{
		int Enemy1Cnt = Mathf.RoundToInt(
            Enemy1SpawnMeanStart * Random.Range(uniformPercent, 1f + uniformPercent));
		for (int i = 0; i < Enemy1Cnt; i++) {
			if (bugCount < maxBugs) {
                var offset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                Instantiate(
                    Enemy1,
                    transform.position + offset, 
                    transform.rotation);
				bugCount++;
			}
		}

	}
	// Update is called once per frame
	void Update () {

	}
}
