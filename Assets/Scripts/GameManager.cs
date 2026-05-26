using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform respawnPoint;
    public bool hasKey = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}