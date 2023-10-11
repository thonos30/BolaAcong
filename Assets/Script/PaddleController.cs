using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float kecepatan;
    public string axis;
    public float batasAtas;
    public float batasBawah;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
        transform.Translate(0,gerak,0);
        float nextPos = transform.position.y + gerak;
    if (nextPos > batasAtas )
        {
            gerak = 0;
        }
        if (nextPos < batasBawah)
        {
            gerak = 0;
        }
    }
}
