using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HumanController : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody rb;
    public Animation anim;
    public GameObject icecream, trash, friend;
    public Animation anim2;

    public AudioSource audioSource;
    public AudioClip aClip;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // anim = GetComponent<Animation>();

    }
    // Update is called once per frame
    void Update()
    {
        if (!anim.IsPlaying("Wave") && (!anim.IsPlaying("Smell")
            && (!anim.IsPlaying("HandShake") && (!anim.IsPlaying("Dance") && (!anim.IsPlaying("IceCream"))))))
        {
            icecream.SetActive(false);
            trash.SetActive(false);
            friend.SetActive(false);

            float x = CrossPlatformInputManager.GetAxis("Horizontal");
            float y = CrossPlatformInputManager.GetAxis("Vertical");

            Vector3 movement = new Vector3(x, 0, y);

            rb.velocity = movement * speed;

            if (x != 0 && y != 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
            }

            if (x != 0 && y != 0)
            {
                anim.Play("Walk");

            }
            else
            {
                anim.Play("Idle");
            }
        }
    }

    public void Wave()
    {
        audioSource.Stop();
        anim.Play("Wave");
    }

    public void Smell()
    {
        audioSource.Stop();
        anim.Play("Smell");
        friend.SetActive(false);
        icecream.SetActive(false);
        trash.SetActive(true);
    }

    public void HandShake()
    {
        audioSource.Stop();
        anim.Play("HandShake");
        trash.SetActive(false);
        icecream.SetActive(false);
        friend.SetActive(true);
        anim2.Play("HandShake");
    }

    public void IceCream()
    {
        audioSource.Stop();
        anim.Play("IceCream");
        friend.SetActive(false);
        trash.SetActive(false);
        icecream.SetActive(true);
    }

    public void Dance()
    {
        anim.Stop("Dance");
        audioSource.Stop();
        audioSource.clip = aClip;
        audioSource.Play();

        anim.Play("Dance");
        friend.SetActive(false);
        trash.SetActive(false);
        icecream.SetActive(false);
    }
}

