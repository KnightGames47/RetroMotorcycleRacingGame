using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    /*
     * Check points should only have a trigger collider and spawn point attached.
     * Upon Trigger enter, the race manager will update the active checkpoint.
     * It at any time the player goes off the course, or is despawned somehow, 
     * we will respawn the player at the listed spawn point for the active checkpoint.
     */
}
