using UnityEngine;



[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
public class SO_Attributes : ScriptableObject
{

    public int health;
    public int maxHealth;
    public int Ammo;
    public int moveSpeed;
    public int jumpForce;


}
