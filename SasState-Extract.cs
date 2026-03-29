private ThreadPoolTimer tempo1;​
int etat = 40;​
string CycleEntree;​
string CycleSortie;​
string cycle = "none";​
bool entrée_etat = true;​
string Temps = "";​


private async void FinTimer(ThreadPoolTimer minuteur) // action en fin de timer
{
Debug.WriteLine("minuteur terminée");
Temps = "ecoulee"; //Changement d’état du drapeau
await Dispatcher.RunAsync(CoreDispatcherPriority.High,
() =>
{
});
Etat_SAS();
}
		
		
private async void Etat_SAS()​
{​
Debug.WriteLine("Numero d'etat : " + etat);​

switch (etat)​
{​

case 0:​
if (entrée_etat == true)​
{​
// ------ ENTRY ------------------------​
entrée_etat = false;​
// ------- Fin ENTRY ------------------​
}​

// ------- DO -------------------------​
// ------- Fin DO ---------------------​

if (demande_entree == true | VBpSortieExt == 1) // si bouton de sortie actionné ou carte presentée a l'entrée ​
{​
// ------- EXIT -----------------------​
  if (VBpSortieExt == 1)​
 {​
    AlimVentSortie.Write(GpioPinValue.Low);​
    cycle = "sortie";​
    Task<String> reponseTrame = Envoilan(TrameOccupé); ​
    Await  Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,() =  > {TbBjrsEtNom.Text = "Bonjour";}) // rafraichit les instructions a l’ecran​
    disponibilité = false;​
    entrée_etat = true;​
    etat = 8;​
 }
 if (demande_entree == true)​
 {​
     demande_entree = false;​
     AlimVentEntree.Write(GpioPinValue.Low);​
     cycle = "entree";​
	Task<String> reponseTrame = Envoilan(TrameOccupé);​
	disponibilité = false;​
	entrée_etat = true;​
	TimeSpan duree = TimeSpan.FromSeconds(10);​
	tempo1 = ThreadPoolTimer.CreateTimer(FinTimer, duree);​
	etat = 1;​
 }	// ------- Fin EXIT ------------------​
}​
break:

case 1:​
if (entrée_etat == true)​
{​
// ------ ENTRY ------------------------​
entrée_etat = false;​
// ------- Fin ENTRY ------------------​
}​
// ------- DO -------------------------​
// ------- Fin DO ---------------------​
if (demande_entree == true | VBpSortieExt == 1)​
{​
// ------- EXIT -----------------------​
 if ((VCaptVentEntree == 0 & Temps == "ecoulee") | VCaptVentEntree == 1)​
  {​
     entrée_etat = true;​
     if (VCaptVentEntree == 1)​
    {​
      tempo1.Cancel();​
      await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,()=>{​
      TbInstruction.Text = "Vous pouvez entrer";​
      TbBjrsEtNom.Text = "Bonjour " + nom + " " + prenom;});​
      etat = 2;​
    }
	 if (VCapteurPresence == 0 & Temps == "ecoulee")​

   {​
      Temps = "";​
      Task<String> reponseTrame = Envoilan(TramePret);​
      disponibilité = true;​
      etat = 0;​
      await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>​ {
      TbInstruction.Text = " ";​
      TbBjrsEtNom.Text = " ";});​
    }​
    AlimVentEntree.Write(GpioPinValue.High);​
  }​
}
break;