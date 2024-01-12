using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedCoockie : Token
{

	private static GameObject _prefab = null;
	public static CrackedCoockie Add(float x, float y)
	{
		_prefab = GetPrefab(_prefab, "crackedcookie");
		return CreateInstance2<CrackedCoockie>(_prefab, x, y);
	}


    // Start is called before the first frame update
    IEnumerator Start()
    {
		float dir = Random.Range(0, 359);
		float spd = Random.Range(10.0f, 20.0f);
		SetVelocity(dir, spd);

		while( 0.01f < ScaleX )
		{
			yield return new WaitForSeconds(0.01f);
			MulScale(0.9f);
			MulVelocity(0.9f);
		}
		DestroyObj();
    }

}
