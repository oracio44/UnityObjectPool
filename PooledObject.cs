using UnityEngine;

public class PooledObject : MonoBehaviour {
    public ObjectPool Pool;

    bool ReturningToPool = false;

    protected void OnEnable()
    {
        ReturningToPool = false;
    }

    public void ReturnToPool () {
		if (Pool) {
            if (!ReturningToPool)
            {
                Pool.AddObject(gameObject);
                ReturningToPool = true;
            }
        }
		else {
			Debug.Log("I die!");
			Destroy(gameObject);
		}
	}
}