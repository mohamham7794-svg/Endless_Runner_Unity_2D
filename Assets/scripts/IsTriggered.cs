using UnityEngine;

public class IsTriggered : MonoBehaviour
{
    [SerializeField] SFXManager sFXManager;

    void Start()
    {
        if (sFXManager == null)
            sFXManager = FindFirstObjectByType<SFXManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Only react to the player
        Player player = collision.GetComponent<Player>();
        if (player == null) return;

        if (gameObject.CompareTag("Coin"))
        {
            player.collectedCoins++;
            if (sFXManager != null) sFXManager.PlaySFX("Coin");
        }
        else if (gameObject.CompareTag("AirJump"))
        {
            player.airJump = true;
            player.ActivateShield();   // remove this line if 2x shouldn't give a shield
        }
        else if (gameObject.CompareTag("Shield"))
        {
            player.ActivateShield();
        }

        Destroy(gameObject);   // the pickup disappears
       
    }
}