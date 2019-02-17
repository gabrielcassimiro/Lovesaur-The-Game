using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    public float minGroundNormalY = .65f;
    public float gravityModifier = 1f;

    // Variavel booleana para definir se o jogo começou
    public bool isPlaying;

    // Variavel para definir a velocidade desejavel
    protected Vector2 targetVelocity;
    // Variavel para definir se o objeto está no chão
    protected bool grounded;
    protected Vector2 groundNormal;
    // Armazena um Rigidbody do tipo 2D
    protected Rigidbody2D rb2d;
    // Variavel para definir a velocidade do objeto
    protected Vector2 velocity;
    // Variavel para filtrar que tipo de colisão sera permitida
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);

    // Minima distancia para poder 
    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    // Quando o objeto é ativado
    void OnEnable () {
        // O componente Rigidbody é pego pelo script
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Quando o jogo começa
    void Start () {
        // Ignora os objetos com trigger selecionado
        contactFilter.useTriggers = false;
        // Seta a layerMask que será registrados as colisões
        contactFilter.SetLayerMask (Physics2D.GetLayerCollisionMask (gameObject.layer));
        // Seta para usar a LayerMask
        contactFilter.useLayerMask = true;
    }

    // Todo Frame esse método é chamado
    void Update () {
        // Seta a velocidade desejável para zero
        targetVelocity = Vector2.zero;
        // Calcula a velocidade dependendo de como o script do objeto deseja
        ComputeVelocity ();
    }

    // Cria um método para ser sobrescrito nos scripts descendentes
    protected virtual void ComputeVelocity () {

    }

    // A cada um certo período de tempo fixo esse método é chamado
    void FixedUpdate () {
        // Adiciona a variavel de gravidade do scipt multiplicada pela gravidade fisica do unity 2D multiplicada pelo tempo do ultimo frame
        if(isPlaying){
            velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        }

        // Seta a velocidade para a velocidade desejada
        velocity.x = targetVelocity.x;

        // Seta a variavel booleana para falso
        grounded = false;

        // Variavel criada para armazenar a diferença de movimento desde o último frame
        Vector2 deltaPosition = velocity * Time.deltaTime;

        // Variavel para manter o objeto no chão
        Vector2 moveAlongGround = new Vector2 (groundNormal.y, -groundNormal.x);

        // Variavel criada para mover o objeto
        Vector2 move = moveAlongGround * deltaPosition.x;

        // Move o objeto apenas pelo chão
        Movement (move, false);

        // Seta a varivel de movimento para se mover para cima
        move = Vector2.up * deltaPosition.y;

        Movement (move, true);
    }

    void Movement (Vector2 move, bool yMovement) {
        float distance = move.magnitude;

        if (distance > minMoveDistance) {
            int count = rb2d.Cast (move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear ();
            for (int i = 0; i < count; i++) {
                hitBufferList.Add (hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++) {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY) {
                    grounded = true;
                    if (yMovement) {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot (velocity, currentNormal);
                if (projection < 0) {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }

}