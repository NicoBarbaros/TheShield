using UnityEngine;
using System.Collections;

public class SpecialEffectsManager : MonoBehaviour {

	public static SpecialEffectsManager current;

	public ParticleSystem distroyEffect;
	public ParticleSystem attackEffect;
	public ParticleSystem fireEffect;

	void Awake()
	{
		if(current != null)
		{
			Debug.LogError("Multiple instances of SpecialEffectsManager!");
		}

		current = this;
	}

	public void Explosion(Vector3 position)
	{
		instantiate (distroyEffect, position);

	}
	public void Fire(Vector3 position)
	{
		instantiate (fireEffect, position);
	}
	public void Attack (Vector3 position)
	{
		instantiate (attackEffect, position);

	}
	
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 pos)
	{
		ParticleSystem newParticleSystem = Instantiate (prefab, pos, Quaternion.identity) as ParticleSystem;

		Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);

		return newParticleSystem;
	}
}
