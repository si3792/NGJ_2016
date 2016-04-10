using UnityEngine;
using psai.net;

public abstract class PsaiColliderBasedTrigger : PsaiSynchronizedTrigger
{
    /// <summary>
    /// the Collider of the Player object. When left blank, psai will try to find the Player object by tag or name.
    /// </summary>
    public Collider2D playerCollider;
    public Collider2D player2Collider;

    /// <summary>
    /// The Collider of the local object that should trigger the psai command. When left bank, psai will search the local GameObject and its children for a collider.
    /// </summary>
    public Collider2D localCollider;

    private void TryToAutoAssignPlayerCollider()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Pl1");
		GameObject player2obj = GameObject.FindGameObjectWithTag("Pl2");
		if (player2obj != null) {
			this.player2Collider = player2obj.GetComponent<Collider2D>();
            if (player2Collider == null)
            {
				player2Collider = player2obj.GetComponentInChildren<Collider2D>();
            }
		}
        if (playerObject == null)
        {
            string[] playerStrings = { "Player", "player", "PLAYER" , "Pl1" };
            foreach (string s in playerStrings)
            {
                playerObject = GameObject.Find(s);
                if (playerObject != null)
                    break;
            }
        }

        if (playerObject != null)
        {
            this.playerCollider = playerObject.GetComponent<Collider2D>();
            if (playerCollider == null)
            {
                playerCollider = playerObject.GetComponentInChildren<Collider2D>();
            }
        }


        #if !(PSAI_NOLOG)
        {
            if (this.playerCollider == null)
            {
                Debug.LogError(string.Format("psai: No Player Collider could be found for component {0}. Please assign the 'Player' tag to your player object, or assign the collider manually.", this.ToString()));
            }
            else
            {
                if (PsaiCoreManager.Instance.logTriggerScripts)
                {
                    Debug.Log(string.Format("psai: successfully auto-assigned Player Collider in component {0}", this.ToString()));
                }
            }
        }
        #endif

    }

    private void TryToAutoAssignLocalCollider()
    {
        if (localCollider == null)
        {
            localCollider = this.GetComponent<Collider2D>();
        }

        #if !(PSAI_NOLOG)
        {
            if (localCollider == null)
            {
                Debug.LogError(string.Format("psai: The game object lacks a local Collider component for psai Trigger: {0}", this.gameObject, this.ToString()));
            }
        }
        #endif
    }



    void Start()
    {
        if (playerCollider == null)
        {
            TryToAutoAssignPlayerCollider();
        }

        if (localCollider == null)
        {
            TryToAutoAssignLocalCollider();
        }
    }


}