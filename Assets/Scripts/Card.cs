using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Card : MonoBehaviour
{
    public Deck deck;     //indica de qual baralho a crata faz parte
    public Sprite sprite1, sprite2; //sprites da frente e veros da carta
    
    public int value;       //indica um valor para carta caso seja necess�rio para jogabilidade
    public string ident;    //identificador da carta
    public string suit;     //naipe ou grupo do qual a carta faz parte
    
    public bool isHidden;   //booleano que indica se a carta est� escondida ou revelada

    /*esse m�todo est� associado ao collider do GameObject das cartas e � respons�vel
     * por selecion�-los para o gameManager*/
    public void OnMouseDown()
    {
        GameObject.Find("gameManager").GetComponent<gameManager>().SelectCard(gameObject);
    }

    public void ShowCard()
    {
        FindObjectOfType<AudioManager>().Play("Flip"); // Som de virar a carta
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        isHidden = false;
    }
    public void HideCard()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        isHidden = true;
    }

    /*esse m�todo � respons�vel por montar a string associada ao GameObject da carta;
     *� utilizado para carregar a sprite da face revelada dessa carta*/
    public override string ToString()
    {
        return ident + "_" + suit;
    }

}
