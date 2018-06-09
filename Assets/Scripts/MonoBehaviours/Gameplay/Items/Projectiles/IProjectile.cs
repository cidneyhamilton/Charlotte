using UnityEngine;

public interface IProjectile {

	Transform ProjectileSpawn { get; set; }

	void CastProjectile();

}
