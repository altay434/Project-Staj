using System.Collections;
using UnityEngine;
using ninjahero.events;
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawner;
    [SerializeField] private GameEvent OnFireEvent;

    [SerializeField] private BulletData bulletData;
    [SerializeField] private PlayerData playerData;
    private void Start()
    {
        StartCoroutine(FireBullet());
    }

    private IEnumerator FireBullet()
    {
        //while
        for (int i = 0; i < playerData.NumberOfShots; i++)
        {
            OnFireEvent.Invoke();

            if (!playerData.DiagonalShot)
            {
                ObjectPooler.Instance.SpawnFromPool("bullet", bulletSpawner.position, transform.rotation);
            }
            else
            {
                ObjectPooler.Instance.SpawnFromPool("bullet", bulletSpawner.position, transform.rotation * Quaternion.Euler(0, 30, 0));
                ObjectPooler.Instance.SpawnFromPool("bullet", bulletSpawner.position, transform.rotation * Quaternion.Euler(0, -30, 0));
                ObjectPooler.Instance.SpawnFromPool("bullet", bulletSpawner.position, transform.rotation);
                //Instantiate(bulletData.BulletObject, bulletSpawner.position, transform.rotation * Quaternion.Euler(0, 30, 0));  // �imdilik sadece 3 at��l�k bir kod ama shot say�s�na g�re otomatik a��
                //Instantiate(bulletData.BulletObject, bulletSpawner.position, transform.rotation * Quaternion.Euler(0, -30, 0)); // ayarlayan bir kod yaz�labilir.
                //Instantiate(bulletData.BulletObject, bulletSpawner.position, transform.rotation);
            }

            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(playerData.FireInterval);
        yield return FireBullet();
    }
}
