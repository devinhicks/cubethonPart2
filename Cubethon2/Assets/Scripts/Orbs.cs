using UnityEngine;

public class Orbs : MonoBehaviour
{
    public GameManager gm; // access GameManager script
    public GameObject orb;

    void OnTriggerEnter()
    {
        gm.collected++; // increment number of orbs collected
        orb.SetActive(false); // set mesh to inactive to "destroy" orb
        Debug.Log(gm.collected);
    }
}
