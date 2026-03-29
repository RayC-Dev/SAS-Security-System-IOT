var packageFolder = Windows.ApplicationModel.Package.Current.InstalledLocation; //Accès au dossier d'installation​
            StorageFile fileinitxt = await packageFolder.GetFileAsync("Config.txt");//Ouverture du fichier Config.txt​
            var inputStream = await fileinitxt.OpenReadAsync(); //Lecture du contenu du fichier​
            var classicStream = inputStream.AsStreamForRead();​
            var streamReader = new StreamReader(classicStream);​
            while (!streamReader.EndOfStream)​
            {​
                string ligne = streamReader.ReadLine(); ​
                char[] separateursLigne = new char[] { '=' };​
                string[] infoLigne = ligne.Split(separateursLigne, StringSplitOptions.None);​
                
				switch (infoLigne[0]) //recuperation des info du fichier de config​
                {​
                    case "ipServeur":​
                        strIPser = infoLigne[1];​
                        IPserv = IPAddress.Parse(strIPser);​
                    break;​

                    case "port":​
                    Portsrv = infoLigne[1];​
                    break;​

                    case "idBDD":​
                        IdConfig = infoLigne[1];​
                    break;​
​
                    case "Timer":​
                        DureeTimer = int.Parse(infoLigne[1]);​
                        break;​

                    case "idSAS":​
                        int idSAS = infoLigne[1];​
                        TrameOccupé = idSAS + ":O";​
                        TramePret = idSAS + ":P";​
                        CycleEntree = idSAS + ":E";​
                        CycleSortie = idSAS + ":S";​
                    break;
				}
			}