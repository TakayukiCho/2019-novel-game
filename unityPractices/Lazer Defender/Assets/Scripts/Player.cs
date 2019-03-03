using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour {

	[SerializeField] float moveSpeed;
	[SerializeField] float padding;
	[SerializeField] Projectile projectile;

	[SerializeField] int hp = 100;

	Coroutine shootingCoroutine;

	float XMin;
	float XMax;
	float YMin;
	float YMax;

	private void OnTriggerEnter2D(Collider2D col){
		hp -= col.GetComponent<DamageDealer>().Damage;
		if(hp <= 0){
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		var camera = Camera.main;
		XMin = camera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
		XMax = camera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
		YMin = camera.ViewportToWorldPoint(new Vector3(0,0,0)).y + padding;
		YMax = camera.ViewportToWorldPoint(new Vector3(0,1,0)).y - padding;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			shootingCoroutine = StartCoroutine(ShootCoroutine());
		}else if (Input.GetKeyUp(KeyCode.Space)){
			StopCoroutine(shootingCoroutine);
		}

		Move();
	}
	private void Move(){
		var deltaMoveSpeed = Time.deltaTime * moveSpeed;
		var newXPos = Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * deltaMoveSpeed, XMin, XMax);
		var newYPos = Mathf.Clamp(transform.position.y + Input.GetAxis("Vertical") * deltaMoveSpeed, YMin, YMax);
		transform.position = new Vector2(newXPos, newYPos);
	}

	private IEnumerator ShootCoroutine(){
		while(true){
			var laser = Instantiate(projectile, transform.position, transform.rotation);
			laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
			yield return new WaitForSeconds(0.2f);
		}
	}

	private void OnCollisionEnter2D(Collision2D col){
		hp -= col.gameObject.GetComponent<DamageDealer>().Damage;
		if(hp < 1){
			Destroy(gameObject);
		}
	}

	private void Shoot(){
		if(Input.GetKey(KeyCode.Space)){
			var laser = Instantiate(projectile, transform.position, transform.rotation);
			laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
		}
	}
}
