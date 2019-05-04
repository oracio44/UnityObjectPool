Add the ObjectPool to an empty game object, and specify the object to pool.
Ensure that the object you wish to keep a pool of extends "PooledObject" instead of MonoBehavior in the component scripts.

When retrieving an item from the pool, you will call "GetObject()" from the pool to get the next available object.
When done with an object, instead of using destory, use "ReturnToPool()";