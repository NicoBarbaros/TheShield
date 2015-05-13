using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 1;
	public bool isEnemy = true;
	private int tempHp;

	void Start()
	{
		tempHp = hp;
	}

	void Update()
	{
		if(!GetComponent<Renderer>().isVisible)
		{
			isEnemy = false;
		}

		else
		{
			isEnemy = true;
		}
	}
	IEnumerator Example() {
		print(Time.time);
		yield return new WaitForSeconds(5);
		print(Time.time);
	}
	public void Damage(int damageCount)
	{

		if(hp <= 0)
		{
			// Run explosion
			SpecialEffectsManager.current.Explosion(transform.position);
			gameObject.SetActive(false);
			hp = tempHp;
		}

		else
		{
			SpecialEffectsManager.current.Attack(transform.position);
			hp -= damageCount;
			this.gameObject.GetComponent<AudioSource>().Play();
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(otherCollider.gameObject.tag == "Projectiles")
		{
			// Is This a shot?
			ShootScript shot = otherCollider.gameObject.GetComponent<ShootScript> ();
			// Avoid friendly fire
			if(shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
				//Destroy the shot
				shot.gameObject.SetActive(false);
			}

		}

		if (otherCollider.gameObject.tag == "Player") 
		{
			SpecialEffectsManager.current.Explosion(transform.position);
			gameObject.SetActive(false);;
		}

		if(otherCollider.gameObject.tag == "Planet")
		{
			SpecialEffectsManager.current.Explosion(transform.position);
			SpecialEffectsManager.current.Fire(transform.position);
			gameObject.SetActive(false);
		}
	}
}
