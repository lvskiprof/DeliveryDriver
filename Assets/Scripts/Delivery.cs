using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
	[SerializeField]
	Color32 hasPackageColor = new Color32(255, 0, 255, 255);
	[SerializeField]
	Color32 noPackageColor = new Color32(255, 255, 255, 255);
	[SerializeField]
	float delayDestroy = 0.2f;
	bool havePackage = false;
	SpriteRenderer spriteRenderer;
	DeliveryDriver deliveryDriver;

	// Start is called before the first frame update
	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		deliveryDriver = GetComponent<DeliveryDriver>();
	}   // Start()
	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collided with " + collision.gameObject.name);
		if (collision.gameObject.CompareTag("Bump"))
		{
			Debug.Log("Dropping speed after hitting " + collision.gameObject.name);
			deliveryDriver.hitBump();
		}   // else-if
		else if (collision.gameObject.CompareTag("Boost"))
		{
			Debug.Log("Raising speed after hitting " + collision.gameObject.name);
			deliveryDriver.hitBoost();
		}   // else-if	}   // OnCollisionEnter2D()
	}   // OnCollisionEnter2D()
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (havePackage && collision.CompareTag("Customer"))
		{
			Debug.Log("Delivered package to " + collision.gameObject.name);
			spriteRenderer.color = noPackageColor;
			havePackage = false;
		}	// if
		else if (!havePackage && collision.CompareTag("Package"))
		{
			Debug.Log("Picked up package from " + collision.gameObject.name);
			spriteRenderer.color = hasPackageColor;
			Destroy(collision.gameObject, delayDestroy);
			havePackage = true;
		}	// else-if
	}   // OnTriggerEnter2D()
}   // class Delivery