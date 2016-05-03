using UnityEngine;
using System.Collections;

public class psaiInit : MonoBehaviour {

	public GameObject go;
	public float Volume;

	private PsaiCoreManager psai;

	void Awake () {
		psai = Instantiate(go).GetComponent<PsaiCoreManager>();
	}

	void Start() {
	}

	// Update is called once per frame
	void Update () {
		if(GlobalData.musicOn) {
		psai.Volume = Volume;
		} else {
			psai.Volume = 0f;
		}
	}
}
