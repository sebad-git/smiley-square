using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {

	public float DESTROY_TIME=1f;

	void Start () { Destroy (gameObject, DESTROY_TIME); }

}
