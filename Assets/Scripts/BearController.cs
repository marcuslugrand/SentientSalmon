using UnityEngine;

public class BearController : MonoBehaviour {

    public string salmonTag;
    public float spottingRange;
    public float speed;

    private GameObject[] salmonObjects;
    private GameObject target;
    private float closestDistance;
    private Rigidbody2D rb;
    private Animator anim;
    public Vector3 startingPosition { get; set; }

    private static readonly int HorizontalVelocityHash = Animator.StringToHash("HorizontalVelocity");
    private static readonly int VerticalVelocityHash = Animator.StringToHash("VerticalVelocity");

    // Awake() called before Start(). Need this for setting spawn locations
    void Awake()
    {
        startingPosition = GetComponent<Transform>().position; 
    }

    void Start() {
        salmonObjects = GameObject.FindGameObjectsWithTag(salmonTag);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // call the FindClosestSalmon function once every second
        InvokeRepeating(nameof(FindClosestSalmon), 0f, 0.5f);
    }

    // OnEnable() sets values saved in sim settings. in this case the speed and spotting range of the bear AI
    void OnEnable()
    {
        speed = PlayerPrefs.GetFloat("bearSpeed", 1f);
        spottingRange = PlayerPrefs.GetFloat("spottingRange", 9f);
    }

    private void FindClosestSalmon() {
        //salmonObjects = GameObject.FindGameObjectsWithTag(salmonTag);

        closestDistance = Mathf.Infinity;

        foreach (GameObject salmonObject in salmonObjects) {
            float distance = Vector3.Distance(transform.position, salmonObject.transform.position);

            if (distance < closestDistance) {

                closestDistance = distance;
                target = salmonObject;
            }
        }
    }

    void Update() {
        if (target != null && closestDistance <= spottingRange) {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;

            // set the animator's velocity parameters based on the bear's velocity
            anim.SetFloat(HorizontalVelocityHash, rb.velocity.x);
            anim.SetFloat(VerticalVelocityHash, rb.velocity.y);
        } else {
            // stop the bear if there is no target
            rb.velocity = Vector2.zero;
            anim.SetFloat(HorizontalVelocityHash, 0f);
            anim.SetFloat(VerticalVelocityHash, 0f);
        }
    }

    void OnDrawGizmosSelected() {
        // Draw a wireframe circle to represent the bear's spotting range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spottingRange);
    }
}
