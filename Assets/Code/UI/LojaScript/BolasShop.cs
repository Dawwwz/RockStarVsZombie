using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BolasShop : MonoBehaviour {

	public static BolasShop instance;

	public List<Bolas> bolasList = new List<Bolas>();
	public List<GameObject> bolaSuporteList = new List<GameObject> ();
	public List<GameObject> compraBtnList = new List<GameObject> ();



	public GameObject baseBolaItem;
	public Transform conteudo;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		
		FillList ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FillList()
	{
		foreach(Bolas b in bolasList)
		{
			GameObject itensBola = Instantiate (baseBolaItem) as GameObject;
			itensBola.transform.SetParent (conteudo, false);
			BolasSuporte item = itensBola.GetComponent<BolasSuporte> ();

			item.bolaID = b.bolasID;
			item.bolaPreco.text = b.bolasPreco.ToString ();
			item.btnCompra.GetComponent<CompraBola> ().bolasIDe = b.bolasID;

			//Lista CompraBtn
			compraBtnList.Add(item.btnCompra);

			//Lista bolaSuporteList

			bolaSuporteList.Add(itensBola);

			if(PlayerPrefs.GetInt("BTN"+item.bolaID) == 1)
			{
				b.bolasComprou = true;
			}

			if(PlayerPrefs.HasKey("BTNS"+item.bolaID) && b.bolasComprou)
			{
				item.btnCompra.GetComponent<CompraBola> ().btnText.text = PlayerPrefs.GetString ("BTNS"+item.bolaID);
			}

			if (b.bolasComprou == true) {
				item.bolaSprite.sprite = Resources.Load<Sprite> ("Sprites/" + b.bolasNomeSprite);
				item.bolaPreco.text = "Comprado!";

				if(PlayerPrefs.HasKey("BTNS"+item.bolaID) == false)
				{
					item.btnCompra.GetComponent<CompraBola>().btnText.text = "Usando";
				}


			} else {

				item.bolaSprite.sprite = Resources.Load<Sprite> ("Sprites/" + b.bolasNomeSprite + "_cinza");
			}
		}
	}

	public void UpdateSprite(int bola_id)
	{
		for(int i = 0; i < bolaSuporteList.Count;i++)
		{
			BolasSuporte bolasSuportScript = bolaSuporteList [i].GetComponent<BolasSuporte> ();

			if(bolasSuportScript.bolaID == bola_id)
			{
				for(int j = 0; j < bolasList.Count;j++)
				{
					if(bolasList[j].bolasID == bola_id)
					{
						if (bolasList [j].bolasComprou == true) {
							bolasSuportScript.bolaSprite.sprite = Resources.Load<Sprite> ("Sprites/" + bolasList [j].bolasNomeSprite);
							bolasSuportScript.bolaPreco.text = "Comprado!";
							SalvaBolasLojaInfo (bolasSuportScript.bolaID);
						} else {

							bolasSuportScript.bolaSprite.sprite = Resources.Load<Sprite> ("Sprites/" + bolasList [j].bolasNomeSprite + "_cinza");
						}
					}

				}
			}
		}
	}

	void SalvaBolasLojaInfo(int idBola)
	{
		for(int i = 0; i < bolasList.Count; i++)
		{
			BolasSuporte bolasSup = bolaSuporteList [i].GetComponent<BolasSuporte> ();

			if(bolasSup.bolaID == idBola)
			{
				PlayerPrefs.SetInt ("BTN"+bolasSup.bolaID,bolasSup.btnCompra ? 1 : 0);
			}
		}
	}

	public void SalvaBolasLojaText(int idBola, string s)
	{
		for(int i = 0; i < bolasList.Count; i++)
		{
			BolasSuporte bolasSup = bolaSuporteList [i].GetComponent<BolasSuporte> ();

			if(bolasSup.bolaID == idBola)
			{
				PlayerPrefs.SetString ("BTNS"+bolasSup.bolaID,s);


			}
		}
	}


}
