using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Token : MonoBehaviour
{
	private bool _exists = false;
	public bool Exists
	{
		get	{ return _exists;	}
		set	{ _exists = value;	}
	}

	private SpriteRenderer _renderer = null;
	public SpriteRenderer Renderer
	{
		get	{ return _renderer ?? (_renderer = gameObject.GetComponent<SpriteRenderer>());	}
	}

	public bool Visible
	{
		get	{ return Renderer.enabled;	}
		set	{ Renderer.enabled = value;	}
	}

	public string sortingLayer
	{
		get { return Renderer.sortingLayerName;	}
		set	{ Renderer.sortingLayerName = value;	}
	}

	public int sortingOrder
	{
		get	{ return Renderer.sortingOrder;	}
		set	{ Renderer.sortingOrder = value;	}
	}

	public float X
	{
		set
		{
			Vector3 pos = transform.position;
			pos.x = value;
			transform.position = pos;
		}
		get	{ return transform.position.x;	}
	}
	public float Y
	{
		set
		{
			Vector3 pos = transform.position;
			pos.y = value;
			transform.position = pos;
		}
		get	{ return transform.position.y;	}
	}


	public float ScaleX
	{
		set
		{
			Vector3 scale = transform.localScale;
			scale.x = value;
			transform.localScale = scale;
		}
		get	{ return transform.localScale.x;	}
	}
	
	public float ScaleY
	{
		set
		{
			Vector3 scale = transform.localScale;
			scale.y = value;
			transform.localScale = scale;
		}
		get	{ return transform.localScale.y;	}
	}

	public float Scale
	{
		get
		{
			Vector3 scale = transform.localScale;
			return (scale.x + scale.y)/2.0f;
		}
		set
		{
			Vector3 scale = transform.localScale;
			scale.x = value;
			scale.y = value;
			transform.localScale = scale;
		}
	}

	private Rigidbody2D _rigidbody2D = null;
	public Rigidbody2D RigidBody 
	{
		get	{ return _rigidbody2D ?? (_rigidbody2D = gameObject.GetComponent<Rigidbody2D>());	}
	}
	
	public float VX
	{
		get	{ return RigidBody.velocity.x;	}
		set
		{
			Vector2 v = RigidBody.velocity;
			v.x = value;
			RigidBody.velocity = v;
		}
	}
	
	public float VY
	{
		get	{ return RigidBody.velocity.y;	}
		set
		{
			Vector2 v = RigidBody.velocity;
			v.y = value;
			RigidBody.velocity = v;
		}
	}	

	public float Direction
	{
		get
		{
			Vector2 v = _rigidbody2D.velocity;
			return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
		}
	}

	public float speed
	{
		get
		{
			Vector2 v = _rigidbody2D.velocity;
			return Mathf.Sqrt(v.x * v.x + v.y * v.y);
		}
	}
	
	public float GravityScale
	{
		get	{ return RigidBody.gravityScale;	}
		set { RigidBody.gravityScale = value;	}
	}

	public float Angle
	{
		set	{ transform.eulerAngles = new Vector3(0,0, value);	}
		get	{ return transform.eulerAngles.z;	}
	}

	private float _width = 0.0f;
	private float _height = 0.0f;

	public float SpriteWidth
	{
		get	{ return Renderer.bounds.size.x;	}
	}
	
	public float SpriteHeight
	{
		get	{ return Renderer.bounds.size.y;	}
	}

	private CircleCollider2D _circleCollider = null;
	public CircleCollider2D CircleCollider
	{
		get	{ return _circleCollider ?? (_circleCollider = GetComponent<CircleCollider2D>());	}
	}

	public float CollisionRadius
	{
		get { return CircleCollider.radius;	}
		set	{ CircleCollider.radius = value;	}
	}

	public bool CircleColliderEnabled
	{
		get	{ return CircleCollider.enabled;	}
		set { CircleCollider.enabled = value;	}
	}

	private BoxCollider2D _boxCollider = null;
	public BoxCollider2D BoxCollider
	{
		get	{ return _boxCollider ?? (_boxCollider = GetComponent<BoxCollider2D>());	}
	}

	public float BoxColliderWidth
	{
		get	{ return BoxCollider.size.x;	}
		set
		{
			var size = BoxCollider.size;
			size.x = value;
			BoxCollider.size = size;
		}
	}

	public float BoxColliderHeight
	{
		get	{ return BoxCollider.size.y;	}
		set
		{
			var size = BoxCollider.size;
			size.y = value;
			BoxCollider.size = size;
		}
	}

	public bool BoxColliderEnabled
	{
		get	{ return BoxCollider.enabled;	}
		set	{ BoxCollider.enabled = value;	}
	}




	public void AddPosition(float dx, float dy)
	{
		X += dx;
		Y += dy;
	}

	public void SetPosition(float x, float y)
	{
		Vector3 pos = transform.position;
		pos.Set(x, y, 0);
		transform.position = pos;
	}

	public void SetScale(float x, float y)
	{
		Vector3 scale = transform.localScale;
		scale.Set(x, y, (x + y) / 2);
		transform.localScale = scale;
	}

	public void AddScale(float d)
	{
		Vector3 scale = transform.localScale;
		scale.x += d;
		scale.y += d;
		transform.localScale = scale;
	}

	public void MulScale(float d)
	{
		transform.localScale *= d;
	}

	public void SetVelocity (float direction, float speed)
	{
		Vector2 v;
		v.x = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
		v.y = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;
		RigidBody.velocity = v;
	}

	public void SetVelocityXY(float vx, float vy)
	{
		Vector2 v;
		v.x = vx;
		v.y = vy;
		RigidBody.velocity = v;
	}

	/// 移動量をかける.
	public void MulVelocity(float d)
	{
		RigidBody.velocity *= d;
	}

	public void SetSprite (Sprite sprite)
	{
		Renderer.sprite = sprite;
	}
	
	public void SetColor(float r, float g, float b)
	{
		var c = Renderer.color;
		c.r = r;
		c.g = g;
		c.b = b;
		Renderer.color = c;
	}

	public void SetAlpha(float a)
	{
		var c = Renderer.color;
		c.a = a;
		Renderer.color = c;
	}

	public float GetAlpha()
	{
		var c = Renderer.color;
		return c.a;
	}

	public void SetSize(float width, float height)
	{
		_width = width;
		_height = height;
	}
	
	public void SetBoxColliderSize(float w, float h)
	{
		BoxCollider.size.Set(w,h);
	}

	public void ClampScreenAndMove(Vector2 v)
	{
		Vector2 min = GetWorldMin();
		Vector2 max = GetWorldMax();
		Vector2 pos = transform.position;
		pos += v;
		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

		transform.position = pos;
	}

	public void ClampScreen()
	{
		Vector2 min = GetWorldMin();
		Vector2 max = GetWorldMax();
		Vector2 pos = transform.position;

		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);
		
		transform.position = pos;
	}

	public bool IsOutside()
	{
		Vector2 min = GetWorldMin();
		Vector2 max = GetWorldMax();
		Vector2 pos = transform.position;
		if( (pos.x < min.x) || (pos.y < min.y) )
		{
			return true;			
		}
		if( (max.x < pos.x ) || (max.y < pos.y) )
		{
			return true;
		}
		return false;
	}

	public Vector2 GetWorldMin( bool noMergin = false)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
		if(noMergin != false)
		{
			return min;
		}
		
		min.x += _width;
		min.y += _height;
		return min;
	}

	public Vector2 GetWorldMax(bool noMergin = false)
	{
		Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
		if(noMergin != false)
		{
			return max;
		}
		
		max.x -= _width;
		max.y -= _height;
		return max;
	}

	public void DestroyObj()
	{
		Destroy(gameObject);
	}
	
	public virtual void Revive()
	{
		gameObject.SetActive(true);
		Exists = true;
		Visible = true;
	}

	public virtual void Vanish()
	{
		gameObject.SetActive(false);
		Exists = false;
	}






	//  プレハブ取得
	public static GameObject GetPrefab(GameObject prefab, string name)
	{
		if( prefab == null )
	{
		prefab = Resources.Load("Prefabs/" + name) as GameObject;
	}
		return prefab;
	}

	public static Type CreateInstance<Type>(GameObject prefab, Vector3 p, float direction = 0.0f, float speed = 0.0f) where Type : Token
	{
		GameObject g = Instantiate(prefab, p, Quaternion.identity) as GameObject;
		Type obj = g.GetComponent<Type>();
		obj.SetVelocity(direction, speed);
		return obj;
	}

	public static Type CreateInstance2<Type> (GameObject prefab, float x, float y, float direction =0.0f, float speed = 0.0f) where Type : Token
	{
		Vector3 pos = new Vector3(x, y, 0);
		return CreateInstance<Type>(prefab, pos, direction, speed);
	}



#if false
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
#endif

}
