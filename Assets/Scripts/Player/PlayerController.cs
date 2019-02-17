using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject {

    public float maxSpeed = 7f;
    public float jumpTakeOffSpeed = 7f;

    protected override void ComputeVelocity () {
        // Criar uma variavel para controlar a movimentação
        Vector2 move = Vector2.zero;

        // Modificar o valor X da variavel de movimentação, para mover o jogador
        move.x = Input.GetAxis ("Horizontal");

        // Se o botão do pulo for apertado e o jogador estiver no chão
        if (Input.GetButtonDown ("Jump") && grounded) {
            // A velocidade de pulo é atribuida ao valor Y da variavel de velocidade 
            velocity.y = jumpTakeOffSpeed;
        // Se o botão de pulo for solto
        } else if (Input.GetButtonUp ("Jump")) {
            // Se o valor Y da velocidade vertical for maior que 0
            if (velocity.y > 0) {
                // Diminui pela metade a velocidade vertical
                velocity.y = velocity.y * 0.5f;
            }
        }

        // Seta a velocidade desejada, para o movimento horizontal vezes a velocidade máxima
        targetVelocity = move * maxSpeed;
    }
}