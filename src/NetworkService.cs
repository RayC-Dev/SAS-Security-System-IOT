static string strIPRas ;​
static IPAddress IPras = IPAddress.Parse(strIPRas);​
TcpListener Monpointecoute;​
string TrameOccupé;​
string TramePret;​
bool disponibilité = true;​
string Etat_msg = "";​
string ID = "";​
string nom = "";​
string prenom = "";​
bool demande_entree = false;

private async Task<String> Envoilan(String msg)​
{​
var ipserv = new Windows.Networking.HostName(Convert.ToString(IPserv));​
var fluxSocket = new Windows.Networking.Sockets.StreamSocket(); //établir une communication réseau via TCP​
await fluxSocket.ConnectAsync(ipserv, Portsrv); // Connexion au serveur​
Stream outputStream = fluxSocket.OutputStream.AsStreamForWrite(); // Permet  d’écrire les données vers le serveur​
Stream fluxentree = fluxSocket.InputStream.AsStreamForRead(); // Permet  de lire les données du serveur​
var fluxreception = new StreamReader(fluxentree); //utilisé pour lire les données du flux d'entrée​
var streamWriter = new StreamWriter(outputStream); //utilisé pour écrire des données dans le flux de sortie​
await streamWriter.WriteLineAsync(msg); // Ecrit une chaîne suivie d'une terminaison de ligne de manière asynchrone dans le flux​
await streamWriter.FlushAsync();   // Efface de façon asynchrone toutes les mémoires tampons pour ce flux​
String messagerecu = fluxreception.ReadLine();​
Debug.WriteLine(messagerecu);​
return messagerecu;​
}

private async void Ecoutelan()​
        {​
           Debug.WriteLine("Ecoute sur : " + strIPRas);​
           while (Monpointecoute != null)​
            {​
                Socket SocketEcoute = await Monpointecoute.AcceptSocketAsync();//Attend qu'un client se connecte et accepte la connexion​
                NetworkStream Fluxsocket = new NetworkStream(SocketEcoute, true);//crée un flux permettant la lecture​
                StreamReader chainerecu = new StreamReader(Fluxsocket); //Recuperation des données reçu sous forme de chaine de caractères​
                msgrecu = chainerecu.ReadLine();​
                Debug.WriteLine("j'ai reçu : " + msgrecu);​
                chainerecu.Dispose();//Ferme proprement les flux ouverts​
                Fluxsocket.Dispose();​
            }
			 try​
            {​
             char[] separateurs = new char[] { ':’ }; //crée un tableau avec comme seule valeur « : »​
             string[] TrameRecu = msgrecu.Split(separateurs, StringSplitOptions.None);//découpe de la trame avec comme séparateur le tableau qui contient « : »​
             if (TrameRecu.Length >= 4)​
               {​
                ID = TrameRecu[0]; //stockage des différents morceaux​
                Etat_msg = TrameRecu[1];​
                nom = TrameRecu[3];​
                prenom = TrameRecu[2];​
               }​
              }​
             catch (Exception)​
             {​
             }​
            if (Etat_msg == "A" & ID == IdConfig & disponibilité == true) //Si les paramètres sont bon alors​
            {​
             demande_entree = true;​
             Etat_SAS();​
            }
			}
		}
