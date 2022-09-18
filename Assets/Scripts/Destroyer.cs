using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject _player;
    public GameObject _platformPrefabs;
    private GameObject _myPlatform;
    public GameObject _jumpPlatformPrefabs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1,7) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(_jumpPlatformPrefabs, new Vector2(Random.Range(-4.5f, 4f), _player.transform.position.y + (15 + Random.Range(0.2f, 1f))), Quaternion.identity);
            }
            else
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4f), _player.transform.position.y + (15 + Random.Range(0.2f, 1f)));
            }
        }
        else if (collision.gameObject.name.StartsWith("JumpPlatform"))
        {
            if (Random.Range(1, 7) <= 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4f), _player.transform.position.y + (15 + Random.Range(0.2f, 1f)));
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(_platformPrefabs, new Vector2(Random.Range(-4.5f, 4f), _player.transform.position.y + (15 + Random.Range(0.2f, 1f))), Quaternion.identity);
            }
        }


        //random platform ve jump force vermesi icin alternatif kod 
        //if (Random.Range(1,6) > 1)
        //{
        //    myPlatform = (GameObject)Instantiate(platformPrefabs, new Vector2(Random.Range(-10f, 10f), player.transform.position.y + (14 + Random.Range(0.2f, 1f))), Quaternion.identity);
        //}
        //else
        //{
        //    myPlatform = (GameObject)Instantiate(jumpPlatformPrefabs, new Vector2(Random.Range(-10f, 10f), player.transform.position.y + (14 + Random.Range(0.2f, 1f))), Quaternion.identity);
        //}
        //Destroy(collision.gameObject);
    }
}