/*
 * Created by SharpDevelop.
 * User: William
 * Date: 07/05/2018
 * Time: 15:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ConversionHexadecimal
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Le code de  la conversion Hexadécimal est pareil juste excepté
			// Le fait que pour les nombres de 10 à 15, il faudra attribuer les lettres A à F à ceux ci.
			// En première partie le traitment binaire et vers la fin le traitement hexadécimal
			char recommencer = 'o';
			do
				{
				
				
				/*********      TRAITEMENT BINAIRE  *************/
				/*********                          *************/
				
				
				string chaineBinaire ="";
				
				//La variable chaine binaire servira à enregistrer les bit, une fois réalisée a 100%
				
				// Pour convertir un nombre en binaire il faut le décomposer aux nombre uniquement qui se suivent
				// en multipliant successivement par deux le chiffre 1.
				
				//On enregistre le nombre dans une variable
				Console.Write("Taper un nombre: ");
				int nombreAconvertir = Convert.ToInt16(Console.ReadLine());
				
				//on retire le plus haut nombre successif de 1 inferieur au égal au nombre à convertir
				//avec une autre variable nbSoustrait
				
				int nbSoustrait = 1; bool ok = true;// boolean pour sortir de la condition si le travail est fini
				
				
				int sauvegarde = nombreAconvertir; // on sauvergarde la valeur
				do{
					
					if(nombreAconvertir==0)// si le nombre binaire est 0 
					{
						
						chaineBinaire+="0";
						break;
						
					}
					
					
					if(nombreAconvertir==1)// si le nombre binaire est 1
					{
						
						chaineBinaire+="1";
						break;
						
					}
					
					nbSoustrait*=2;
					if(nbSoustrait>nombreAconvertir)// une fois dépassé on divise par deux pour avoir le bon nombre
						// et on l'enlève au nombre a convertir
					{
						//On commence à incrémenter la chaune avec 1 bit
						
						
						
						
						chaineBinaire+="1";
						nbSoustrait/=2;
						nombreAconvertir -= nbSoustrait;
						
						
						
						
						
						
						//Pour ajouter un zero, le nombre doit être égal un a nombre successif et supérieur au nombre a convertir
						// on prend une variable qui prend la valeur du nombre soustrait et le divise par deux en respectant la condition
						int CopieNbSoutrait = nbSoustrait;
						do
						{
							CopieNbSoutrait/=2;
							
							if(CopieNbSoutrait>nombreAconvertir)
							{
								chaineBinaire+="0";
							}
							
						}while(CopieNbSoutrait>nombreAconvertir);
						
						//la condition devant fausse par nécessité incrémente un zéro de trop
						// il faut toujours en enlever un
						
						
						// maintenant on réinitialise la variable nbSoustrait pour effectuer un autre tour  si nécessaire
						// et une autre soustraction
						nbSoustrait=1;
						
						
						
						
					}
					
					
					
					if(nbSoustrait==nombreAconvertir)// Si le nombre à convertir est égale a un nombre successif
						// dès le premier tour ou si le reste après la soustraction du premier if est aussi égale
						// alors on incrémente la chaine et le travail est terminé
					{
						chaineBinaire+="1"; 
						
						//il faut ajouter des zero à la fin si le nombre a convertir restant et successif à la fois est au minimum 2
						//Il faut diviser une variable = au nombre succesif jusqu'a un
						
						int Copie= nombreAconvertir; bool petitOk= false;
						
						do// tant qu'on a pas atteint le nombre un on ajoute un zero jusqu'a l'atteindre
						{
							Copie/=2;
							if(Copie>0)
							{
								chaineBinaire+="0";
							}
							
							else
							{
								petitOk=true;
							}
							
						}while(!petitOk);
						
						ok = false;
					}
					
					
					
					
					
				}while(ok);
				
				
				
				
				/*********      TRAITEMENT HEXADECIMAL    *************/
				/*********                                *************/
				
				
				//On aura besoin d'une variable pour stocker le résultat en hexadécimal base 16 donc
				string chaineHexa ="";
				//On aura besoin d'une variable qui se multiplie par deux à chaque tour car la règle du 1,2,4,8
				// Elle aura donc 1 pour commencer
				int jeMeMultiplie = 1;
				//On aura besoin d'une variable qui stock l'addition des bits à 1 pour 1,2,4,8
				// Elle se réinitialisera une fois un groupe de 4 bit effectué dans la boucle
				
				int addition = 0;
				// Avant tout on inverse la chaîne binaire car elle n'est pas dans le bon sens pour le traitement hexa
				// résultat dans une autre variable
				
				// INVERSION **************/
				
					string chaineBinaireInverse = ""; 
					
					for(int i=chaineBinaire.Length - 1 ; i>=0; i--)
					{
						chaineBinaireInverse+= chaineBinaire[i];
					}
					
					
				
				// INVEERSION FINI *********/
				
				// Il faut une variable qui indique la fin d'un groupe de 4 bit elle s'incrémentera à chaque tour et réinitialiser poru un nouveau groupe
				
				int finGroupe = 0; 
				// Cette variable sera utilie pour prendre la chaien hexa dans le bon sens une bonne fois pour toute
				string chaineHexaBonsens = "";
				
				for(int i=0; i<chaineBinaireInverse.Length; i++)
				{
					
					
					if(chaineBinaireInverse[i]=='1')
					{
						addition += jeMeMultiplie;
					}
					
					jeMeMultiplie*=2;
					
					finGroupe++;
					
					if(i== chaineBinaireInverse.Length-1 || finGroupe==4)// On prépare l'affection de la bonne lettre ou des bon nombres
						
					{
						switch(addition) 
						{
							
							case 10 : chaineHexa+="A"; 
							break;
							case 11	: chaineHexa+="B"; 
							break;
							case 12 : chaineHexa+="C"; 	
							break;
							case 13 : chaineHexa+="D"; 
							break;
							case 14 : chaineHexa+="E"; 
							break;
							case 15 : chaineHexa+="F"; 
							break;
							default : chaineHexa+=addition.ToString(); 
							break;
						}
						
						 //Il faut réinitialiser finGroupe
						 finGroupe=0;
						 // Et les autres variables jeMeMultiplie et addition pour les préparer a un nouveau groupe
						 
						 jeMeMultiplie=1; addition = 0;
					}
					
					
					
				}
				//N'oublions une fois cela fait de réinverser la chaine Hexa une bonne fois pour toute
						 // car elle est dans le mauvais sens
						 
			
						 for (int j = chaineHexa.Length-1; j>=0; j--)
						 {
						 	
						 	chaineHexaBonsens+=chaineHexa[j];
						 }
						
				
				
				Console.WriteLine(sauvegarde+" vaut "+chaineHexaBonsens+"  en hexadecimal.");
				
				
				
				Console.WriteLine("Recommencer ? 'o' pour Oui 'n' pour Non.");
				recommencer=Convert.ToChar(Console.ReadLine());
				
				}while(recommencer=='o');
			}
		}
	
}