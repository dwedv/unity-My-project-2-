using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed =5f; // Speed of the player
    public float slowedSpeed = 1f; // ���ٺ���ٶ�
    public float jumpForce =800f ; // Jump force
    public float dashingPower = 20f;
    public float dashingTime = 0.1f;
    public float noDashTime = 1f;
    public bool shouldMove = true;
    public bool canDash = true;

    public bool isGrounded = true;
    //public bool isGronuded
    //{
    //    get { return isGronuded;}
    //}

    private bool getWeapon = true;
    private float currentSpeed = 5f;
    private int jumpCount = 0;
    private bool shouldJump = false;
    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isDashing;
    //private Transform player;
    //private float smoothSpeed = 0.125f;

    //[SerializeField] private GameObject bulletPrefab;
    //[SerializeField] private Transform bulletPosition;




    void Start()
    {
        //bulletPosition = transform.position;
        currentSpeed = speed;
        // Get the Rigidbody component from the player object
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check for jump input
        if (Input.GetKeyDown(KeyCode.UpArrow)&& jumpCount<=1)
        {
            shouldJump = true;
        }

        if (isDashing)
        {
            return;
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) && canDash))
        {
            StartCoroutine(Dash());
        }

        if((Input.GetKeyDown(KeyCode.F)&& getWeapon))
        {
            Fire();
        }

    }

    void FixedUpdate()
    {
        // Initialize movement orientation to right
        Vector3 movement = Vector3.right;

        if (shouldJump  && jumpCount <= 1)
        {
            Jump();
        }

        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (shouldMove)
        {
            transform.position += new Vector3(currentSpeed * Time.deltaTime,0,0);
        }

        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

    }

    public void Fire()
    {
        GameObject bullet = ObjectPoolManager.Instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = transform.position+new Vector3(10,0,0);
            bullet.SetActive(true); 
        }
    }

    // �������Capsule��ײʱ����
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Capsule")) 
        {
            currentSpeed = slowedSpeed;
            Invoke("RestoreSpeed", 1f); // ������ٳ���1��
        }
    }

    void RestoreSpeed()
    {
        currentSpeed = speed;
    }

    void Jump()
    {
        // Jump
        rb.AddForce(Vector3.up * jumpForce);
        shouldJump = false;
        isGrounded = false;
        jumpCount++;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    private IEnumerator Dash()
    {
        canDash = false;//���ڳ���У���״̬��Ϊ���ܳ��
        isDashing = true;//���ڳ����
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);//��̵��ٶ�
        yield return new WaitForSeconds(dashingTime);//���ʱ�ȴ�dashingTime��ʱ���ִ�к������
        isDashing = false;//�����ڳ��״̬�ص�
        yield return new WaitForSeconds(noDashTime);//�ȴ�noDashTime����ȴʱ������ʹ���´γ��
        canDash = true;//���״̬��Ϊ���Գ��
    }


}