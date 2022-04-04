using UnityEngine;

[CreateAssetMenu(fileName = "New Obstacle", menuName = "Obstacle")]
public class ObstacleData : ScriptableObject
{
    public int health;
    public Color color;
    public Vector3 scale;
}
