using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
	[SerializeField] int damage = 100;
	public int Damage {
		get {return damage;}
	}

	private void OnTriggerEnter2D(Collider2D col){

		Hit();
	}

	private void Hit(){
		Destroy(gameObject);
	}

}
