using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public float UseLine = 100f;

    [Range(0.01f, 10)] public float LineUsage = 0.1f;
    [Range(1, 100)] public int QtdLineUse = 3;

    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPosition;

    public int LineTotal = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the left button is pressed (performed once while pressed) will create a new line;
        //Se o botão esquerdo estiver pressionado(executará uma vez enquanto estiver pressionado)
        //irá criar uma nova linha;
        if(Input.GetMouseButtonDown(0) && LineTotal <= QtdLineUse){
            createLine();
            LineTotal ++;
        }
        //if left button is pressed will call the updateLine method and will pass the mouse position
        //se botao esquerdo estiver pressionado irá chamar o metodo updateLine e irá passar a posição do mouse
        if(Input.GetMouseButton(0) && UseLine > 0 && LineTotal <= QtdLineUse){
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(tempFingerPos, fingerPosition[fingerPosition.Count - 1]) > .1f){
                updateLine(tempFingerPos);
                UseLine -= LineUsage;
            }
        }
    }

    void createLine(){
        //Current line receives the value of the instantiated prefab
        //Current line recebe o valor do prefab instanciado
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        //LineRenderer and the edgeCollider receive the necessary values for each of the created Prefab
        //LineRenderer e o edgeCollider recebe os valores necessarios para cada um do Prefab criado
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        //Clear List
        //Limpa a List
        fingerPosition.Clear();
        //Pass Values from where you are clicked to list
        //Passa os Valores de onde está sendo clicado para list 
        fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //Sets the position of the vertex of the line to the position of the first click on the screen
        //Define a posição do vertice da linha para a posição do primeiro click na tela
        lineRenderer.SetPosition(0, fingerPosition[0]);
        //Creates the collider on the created line
        //Cria o colisor na linha criada
        edgeCollider.points = fingerPosition.ToArray();

    }

    void updateLine(Vector2 newFingerPos){
        //Adds a new position to the list
        //Adiciona uma nova posição a list
        fingerPosition.Add(newFingerPos);
        //Add another vertex to the line
        //Adiciona mais uma vertice a linha
        lineRenderer.positionCount++;
        //Sets the position of the vertex of the line to the click-on-screen position
        //Define a posição do vertice da linha para a posição de click na tela
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        //Creates the collider on the created line
        //Cria o colisor na linha criada
        edgeCollider.points = fingerPosition.ToArray();
    }
}
