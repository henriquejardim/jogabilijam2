using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour {

	public int health = 1;
	public UnityEvent dead;
    public UnityEvent hurt;

    private float m_CurrentHealth = 0;

	void Start () {
		m_CurrentHealth = health;
	}

	public void TakeDamage(float amount){

		m_CurrentHealth -= amount;

        if (hurt != null)
            hurt.Invoke();

		if (m_CurrentHealth <= 0 && dead != null)
			dead.Invoke ();
	}
}
