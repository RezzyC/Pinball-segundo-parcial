using UnityEngine;

public class ParticulasFlipper : MonoBehaviour
{
    public ParticleSystem efectoParticulas;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (efectoParticulas != null)
            {
                ContactPoint contacto = collision.GetContact(0);

                ParticleSystem efecto = Instantiate(
                    efectoParticulas,
                    contacto.point,
                    Quaternion.identity
                );

                efecto.Play();

                Destroy(efecto.gameObject, 2f);
            }
        }
    }
}
