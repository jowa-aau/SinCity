
    using System.Xml.Linq;
    using Framework.Manager;
    using Framework.Types;
    using UnityEngine;

    public class AntBehaviorController : MonoBehaviour
    {

        private Vector2 position;
        private float speed = 10f;
        private float x;
        private float y;
        private SpriteRenderer renderer;
        private float timer;
        private bool goToMiddle = false;
        private bool inSkill = false;
        private GameManager gm;


        private void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            speed = Random.Range(10, 50);
            position = gameObject.transform.position;
            x = Random.Range(-1000, 1000);
            y = Random.Range(-1000, 1000);
            gm = GameManager.Instance;
            InputManager.OnButton0 += HandleButton0Event;
            
        }

        private void Update()
        {
            float step = (speed * Time.deltaTime)/100;
            Vector2 newPosition = new Vector2(position.x + x, position.y + y);
            
            transform.position = Vector2.MoveTowards(transform.position, newPosition, step);

            timer += Time.deltaTime;
            if (timer >= 1)
            {
                timer = 0;
                renderer.flipX = !renderer.flipX;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enviroment")) {
                x = 0;
                y = 0;
                goToMiddle = true;
            } else if (other.gameObject.layer == LayerMask.NameToLayer("Spawn")) {
                x = Random.Range(-1000, 1000);
                y = Random.Range(-1000, 1000);
                goToMiddle = false;
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Skill")) {

                inSkill = true;
            }
        }

       private void OnTriggerExit(Collider other)
       {
            if (other.gameObject.layer == LayerMask.NameToLayer("Skill")) {
                inSkill = false;
            }
        }
       
       private void HandleButton0Event(InputManagerEventType type)
       {
           if (type == InputManagerEventType.ButtonUp && inSkill) {
               gm.removeAnts(1);
               Destroy(this.gameObject);
           }
       }
    }
