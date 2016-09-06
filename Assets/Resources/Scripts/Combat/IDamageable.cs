using UnityEngine;
using System.Collections;

public enum TeamSide {
   Players,
   Enemies
};

public interface IDamageable {
	TeamSide Team { get; }
	float Health { get; }
	void Damage(float damageReceived);
	void Kill(bool shouldDestroyObject);
}
