using UnityEngine;

public class PooledObject : MonoBehaviour {
    public ObjectPool Pool;

    bool ReturningToPool = false;

    //if overridden, ensure to call Base.OnEnable()
    protected void OnEnable()
    {
        ReturningToPool = false;
    }

    public void ReturnToPool () {
		if (Pool) {
            if (!ReturningToPool) //Ensure object is not returned to the pool multiple times at once
            {
                Pool.AddObject(gameObject); //Object will be disabled and returned to pool
                ReturningToPool = true;
            }
        }
		else {
			Debug.Log("I die!");
			Destroy(gameObject);
		}
	}
}