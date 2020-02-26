using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //Ogólnie to tu mamy podstawowy movement gracza. Trzeba pamiętać żeby wyłączyć grawitację 
											//oraz ustawić blokadę osi 'z' przy Playerze. Do animacji wystarczy dodać parę linijek, 

{
	public int maxHealth = 4; //zycie ustawiane                                      //większa zabawa jest w samym Unity oraz w wykonaniu spriteów (z 4 na animację będą ok)
	public int currentHealth;

	public HealthBar healthBar;

	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;

	private void Start()
	{
		currentHealth = maxHealth;
		healthBar.MaximumHealth(maxHealth);
	}

	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		if (Input.GetKeyDown(KeyCode.Space))
			TakeDamage(1);
	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
	}
}