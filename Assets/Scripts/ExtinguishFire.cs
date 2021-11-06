using UnityEngine;

public class ExtinguishFire : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        int firesChildPos = 0;
        ParticleSystem fire = other.transform.GetChild(firesChildPos).GetComponent<ParticleSystem>();
        fire.maxParticles--;
    }
}
