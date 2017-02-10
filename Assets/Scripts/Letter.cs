using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Esta classe deve ser atrelada a cada objeto do tipo letras, e conterá uma lista que armazenará as letras associadas a ela
/// </summary>
public class Letter : MonoBehaviour {

    // Valor de cada letra do alfabeto
    public char value;

    // Lista de Objetos do tipo letras associados ao objeto associado a este script
    public List<Letter> Related = new List<Letter>();

    // Diz se o cubo atual está conectado ou não 
    public bool isConnected;

    // Salva o script do Objeto do gerenciador do jogo
    private GameManager gameManager;

    void Start()
    {
        //Salva o componente GameManager na variável gameManager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    
    /// <summary>
    /// Método da API do Unity que representa um Game Loop mais apurado, executa o tempo inteiro
    /// </summary>
    void FixedUpdate()
    {
        // Variáveis associadas ao Raycast que é explicado abaixo
        Vector3 ahead = transform.right;
        Vector3 rayStart = transform.position;
        Ray ray = new Ray(rayStart, ahead);
        RaycastHit hit;

        // Gera um raio em linha reta em uma direção, no caso, do lado direito e identifica objetos que contem o componente do tipo Colisor ( BoxCollider, MeshCollider e etc.. )
        // Quando um objeto é encontrado pelo Raio, o código executa dentro do if  
        if (Physics.Raycast(ray, out hit, 3))
        {

                 // Caso haja letras relacionadas com essa, executa a instrução logo abaixo   
                if(Related.Count > 0)
                // Para cada letra associada, verifica se a letra que está à direita possui o valor igual a elas.
                foreach(Letter ltr in Related)
                {
                    // Verifica se a letra atingida pelo raio é igual a um das que estão salvas na associação
                    if (hit.transform.gameObject.GetComponent<Letter>().value == ltr.value)
                    {
                        // Verifica se todas as letras estão uma do lado da outra conforme a palavra
                        gameManager.CheckWord();

                        //Caso a letra a direita seja igual a uma das associas, marca ela como conectada
                        isConnected = true;
                    }
            
                   
                }
           
                // Exibe um raio na janela de Edição para Debug ( verifica se o raio está certo )
               Debug.DrawRay(rayStart, ahead * 3, Color.magenta);


        }
        else
        {
            // Caso a letra a direita não esteja associada a esta, marca como não conectada
            isConnected = false;
        }

    }

}
