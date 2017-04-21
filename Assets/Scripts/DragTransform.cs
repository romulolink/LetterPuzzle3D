using UnityEngine;

/// <summary> 
/// Está classe fornece suporte ao mecanismo de arrastar e soltar ( Drag n' Drop) de acordo com a API do Unity
/// Todos os métodos abaixo são da API do Unity
/// </summary>
class DragTransform : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
  
    // Evento que executa quando o cursor do mouse está em cima do objeto 
    //  Troca a cord
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    // Evento que executa quando o cursor do mouse está em cima do objeto
    //  Troca a cor novamente
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    // Evento que executa quando um objeto é tocado ou clicado
    // Calcula a distância entre o objeto e a câmera
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    //  Evento que executa quando um objeto é soltado
    void OnMouseUp()
    {
        dragging = false;
    }

    // Método da API do Unity que representa o Game Loop, executa o tempo inteiro 
    void Update()
    {
      

        // Caso o objeto esteja sendo segurado) = 
        if (dragging)
        {
            //  Calcula a direção do raio baseado na posição do mouse referente a câmera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            // Pega a posição do raio baseado na distância da câmera e do objeto 
            Vector3 rayPoint = ray.GetPoint(distance);

            // Atualiza a posição do objeto baseada no ponto calculado e mantém a posição y do objeto a mesma para o objeto não subir nem descer ao ser arrastado. 
            transform.position = new Vector3(rayPoint.x, transform.position.y, rayPoint.z);
        }
    }
}
