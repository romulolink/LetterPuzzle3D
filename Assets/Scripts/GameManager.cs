using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Está classe tem como responsabilidade gerenciar todo o gameplay
/// </summary>
public class GameManager : MonoBehaviour {

	// Lista de objetos do tipo Letras que estarão associados aos cubos
    // Colocar aqui todas as letras disponíveis no Alfabeto e depois desativar as que não precisar naquela cena
    public List<Letter> letters = new List<Letter>();

    // Palavra usada para o Puzzle
    public string Word = "AVIAO";

    // Propriedade do C#, mas dada é do que a contração dos métodos set e get 
    public GameObject MessageModal { get; private set; }


    /// <summary>
    /// Método da API do Unity que executa na inicialização do game automaticamente, uma vez. 
    /// </summary>
    void Start () {

        // Método que gera as associações de cada letra automaticamente, de acordo com a variável palavara ( word )
        GenerateRelatedLetters();

        // Pesquisa na cena o objeto da janela que exibirá mensagem de sucesso
        MessageModal = GameObject.Find("Message");

        // Desativa de início a janela de mensagem de sucesso
        MessageModal.SetActive(false);
        	
	}


    /// <summary>
    /// Percorre cada elemento da lista de letras a qual deverá possuir os objetos associados pelo Unity manualmente via drag and drop no painel inspetor.
    /// Este método salva em cada componente letra nos cubos os outros objetos (letras) associados a ele para verificação no gameplay.
    /// </summary>
    void GenerateRelatedLetters()
    {

        int i = 0;

        foreach (Letter ltr in letters)
        {
            for(i = 0; i < Word.Length - 1; i++)
            if (ltr.value == Word[i])
            {
               
                ltr.Related.Add(GetLetterFromValue(Word[i+1]));
              
            }
           

        }

    }


    /// <summary>
    /// Método que encontra um objeto do tipo letra após passar como parâmetro o valor da letra (exe. a, b ,c ,d)
    /// </summary>
    /// <param name="value"> letra a ser pesquisada </param>
    /// <returns></returns>
    private Letter GetLetterFromValue(char value)
    {
        foreach (Letter ltr in letters)
        {
            if (ltr.value == value)
                return ltr;

        }

        return null;
    }


    // Checa as letras que estão próximas das corretas de acordo com a geração de associações feitas automaticamente.
    public void CheckWord()
    {
        // variável local que conta as letras
        int totalConected = 0;

        // Para cada letra, verifica se está conectada, caso esteja, soma no total
        foreach (Letter ltr in letters)
            if (ltr.isConnected)
                totalConected++;

        // Caso todoas as letras estejam associadas corretamente, ativa janela de sucesso
        if (totalConected == Word.Length - 1)
        {
            Debug.Log("Palavra montada com sucesso");
            MessageModal.SetActive(true);
        }
            

    }
}
