using UnityEngine;
using System.Collections;

	public class PlayerHitVisual: MonoBehaviour
	{
	private GameObject player;
	private SpriteRenderer spriteRenderer;
	private GameObject camera;
	private CameraShake cameraShake;

    private void Awake()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		spriteRenderer = player.GetComponent<SpriteRenderer>();
		camera = GameObject.FindGameObjectWithTag("Camera");
		cameraShake = camera.GetComponent<CameraShake>();
    }

	public void OnPlayerHit() 
	{
		StartCoroutine(makePlayerRed());
		cameraShake.Shake(0.5f, 0.2f);
	}

	IEnumerator makePlayerRed() 
	{ 
		spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.5f);
		spriteRenderer.color = Color.white;
	}

	}
