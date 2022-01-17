using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapons")]

public class GunObject : ItemObject
{
    public int gunDamage;											// Set the number of hitpoints that this gun will take away from shot objects with a health script
	public float fireRate;										    // Number in seconds which controls how often the player can fire
	public float weaponRange;									    // Distance in Unity units over which the player can fire
	public float hitForce;										    // Amount of force which will be added to objects with a rigidbody shot by the player
	public Transform gunEnd;										// Holds a reference to the gun end object, marking the muzzle location of the gun
	public ParticleSystem muzzleFlash;
	public AudioSource shootEffect;
    public int maxAmmo;											    // MaxAmmo is max ammo capacity.

    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
