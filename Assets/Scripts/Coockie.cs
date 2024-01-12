using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coockie : Token
{
	public static int Count { get; private set; } = 0;
	
	// Start is called before the first frame update
	void Start()
	{
		Count++;

		SetSize(SpriteWidth /2, SpriteHeight / 2);

		float dir = Random.Range(0, 359);
		float speed = 2;
		SetVelocity(dir, speed);
	}

    // Update is called once per frame
	void Update()
	{
		Vector2 min = GetWorldMin();
		Vector2 max = GetWorldMax();

		if( (X < min.x) || (max.x < X))
		{
			VX *= -1;
			ClampScreen();
        }
		if( (Y < min.y) || (max.y < Y)) 
		{
			VY *= -1;

			ClampScreen();
		}
    }

	public void OnMouseDown()
	{
		for (int cnt = 0; cnt < 32; cnt++)
		{
			CrackedCoockie.Add(X, Y);
		}
		Count--;
		DestroyObj();
	}
}
