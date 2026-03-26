using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ammoText;
    public BombShooter shooter;

    void Update()
    {
        ammoText.text = "Bomb: " + shooter.currentAmmo + "/5";
    }
}