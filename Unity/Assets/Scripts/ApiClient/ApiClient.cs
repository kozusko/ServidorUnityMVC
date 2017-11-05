using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{
    const string baseUrl = "http://localhost:52250/API";
    TextChar textChar;

	// Use this for initialization
	void Start ()
    {
        
        StartCoroutine(GetItensApiAsync());
        textChar = GameObject.Find("Text").GetComponent<TextChar>();
	}

    private IEnumerator PostItemApiAsync()
    {
        WWWForm form = new WWWForm();

        form.AddField("Nome", "");
        form.AddField("Descricao", "");
        form.AddField("Sexo", "");
        form.AddField("Planeta", "");


        using (UnityWebRequest request = UnityWebRequest.Post(baseUrl + "/Characters", form))
        {
            // obsoleto (Unity 2017.1)
            //yield return request.Send();

            // (Unity 2017.2)
            yield return request.SendWebRequest();


            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Envio do item efetuado com sucesso");
            }

        }
    }

    IEnumerator GetItensApiAsync()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Characters");
        
        // obsoleto (Unity 2017.1)
        //yield return request.Send();

        // (Unity 2017.2)
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string response = request.downloadHandler.text;
            //Debug.Log(response);

            //byte[] bytes = request.downloadHandler.data;

            Character[] characters = JsonHelper.getJsonArray<Character>(response);

            foreach (Character i in characters)
            {
                
                textChar.PrintOnScreen(i);
            }

        }
    }

    public void ImprimirItem(Character i)
    {
        Debug.Log("======= Dados Objeto ==========");

        Debug.Log("Id: " + i.CharacterID);
        Debug.Log("Nome: " + i.Nome);
        Debug.Log("Descrição: " + i.Descricao);
        Debug.Log("Sexo: " + i.Sexo);
        Debug.Log("Planeta: " + i.Planeta);
    }
}
