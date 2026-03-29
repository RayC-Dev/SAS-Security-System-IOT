private GpioController Mongpc;​
private GpioPin CaptPresence;​
private GpioPin BpEntréeInt;​
private GpioPin BpSortieInt;​
private GpioPin BpSortieExt;​
private GpioPin CaptVentEntree;​
private GpioPin CaptVentSortie;​
private GpioPin AlimVentEntree;​
private GpioPin AlimVentSortie;  ​
int VCapteurPresence;​
int VBpEntréeInt;​
int VBpSortieInt;​
int VBpSortieExt;​
int VCaptVentEntree;​
int VCaptVentSortie;​

CaptPresence = Mongpc?.OpenPin(12);​
if (CaptPresence != null)​
{​
   CaptPresence.SetDriveMode(GpioPinDriveMode.InputPullUp);​
}​

BpEntréeInt = Mongpc?.OpenPin(26);​
if (BpEntréeInt != null)​
{
   BpEntréeInt.SetDriveMode(GpioPinDriveMode.InputPullUp);​
}​

BpSortieInt = Mongpc?.OpenPin(17); //initialisation des pins ​
if (BpSortieInt != null)​
{​
   BpSortieInt.SetDriveMode(GpioPinDriveMode.InputPullUp);​
}​

BpSortieExt = Mongpc?.OpenPin(18);​
if (BpSortieExt != null)​
{​
   BpSortieExt.SetDriveMode(GpioPinDriveMode.InputPullUp);​
}​

CaptVentEntree = Mongpc?.OpenPin(19);​
if (CaptVentEntree != null)​
{
   CaptVentEntree.SetDriveMode(GpioPinDriveMode.InputPullUp);​
}​

CaptVentSortie = Mongpc?.OpenPin(23);​
if (CaptVentSortie != null)​
{​
   CaptVentSortie.SetDriveMode(GpioPinDriveMode.InputPullUp);​
}​

AlimVentEntree = Mongpc?.OpenPin(6);​
if (AlimVentEntree != null)​
{​
   AlimVentEntree.SetDriveMode(GpioPinDriveMode.Output);​
   AlimVentEntree.Write(GpioPinValue.Low);​
}​

   AlimVentSortie = Mongpc?.OpenPin(25);​
if (AlimVentSortie != null)​
{​
   AlimVentSortie.SetDriveMode(GpioPinDriveMode.Output);​
}


 private void Page_Loaded(object sender, RoutedEventArgs e)​

        {​
            if (CaptPresence != null)​
            {​
                CaptPresence.DebounceTimeout = new TimeSpan(10000); // anti rebond​
                CaptPresence.ValueChanged += CaptPresence_ValueChanged; //active la surveillance des changements ​
            }​

            if (BpEntréeInt != null)​
            {​
                BpEntréeInt.DebounceTimeout = new TimeSpan(10000); ​
                BpEntréeInt.ValueChanged += BpEntréeInt_ValueChanged​
            }​

            if (BpSortieInt != null)​
            {​
                BpSortieInt.DebounceTimeout = new TimeSpan(10000); ​
                BpSortieInt.ValueChanged += BpSortieInt_ValueChanged; ​
            }​

            if (BpSortieExt != null)​
            {​
                BpSortieExt.DebounceTimeout = new TimeSpan(10000); ​
                BpSortieExt.ValueChanged += BpSortieExt_ValueChanged; ​
            }​

            if (CaptVentEntree != null)​
            {​
                CaptVentEntree.DebounceTimeout = new TimeSpan(10000); ​
                CaptVentEntree.ValueChanged += CaptVentEntree_ValueChanged; ​
            }​

            if (CaptVentSortie != null)​
            {​
                CaptVentSortie.DebounceTimeout = new TimeSpan(10000); ​
                CaptVentSortie.ValueChanged += CaptVentSortie_ValueChanged; ​
            }​

            Etat_SAS();​

        }

        private void CaptPresence_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)​
        {​
            if (CaptPresence.Read() == GpioPinValue.Low)​
            {​
                VCapteurPresence = 0;​
            }​
			
            else​
            {​
                VCapteurPresence = 1;​
            }​
            Etat_SAS();​
        }​
​
        private void BpEntréeInt_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)​
        {​
            if (BpEntréeInt.Read() == GpioPinValue.Low) // test que le bouton est appuyé​
            {​
                AlimVentEntree.Write(GpioPinValue.Low);​
                VBpEntréeInt = 1;​
            }​

            else​
            {​
                VBpEntréeInt = 0;​
            }​
            Etat_SAS();​
        }​

        private void BpSortieInt_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)​
        {​
            if (BpSortieInt.Read() == GpioPinValue.Low)​
            {​
                AlimVentSortie.Write(GpioPinValue.Low);​
                VBpSortieInt = 1;​
            }​

            else​
            {​
                VBpSortieInt = 0;​
            }​
            Etat_SAS();​
        }​

        private void BpSortieExt_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)​
        {​
            if (BpSortieExt.Read() == GpioPinValue.Low) ​
            {​
                AlimVentSortie.Write(GpioPinValue.Low);​
                VBpSortieExt = 1;​
            }​

            else​
            {​
                VBpSortieExt = 0;​
            }​
            Etat_SAS();​
        }​

        private void CaptVentEntree_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)​
        {​
            if (CaptVentEntree.Read() == GpioPinValue.Low)​
            {​
                VCaptVentEntree = 1;​
            }​

            else​
            {​
                VCaptVentEntree = 0;​
            }​
            Etat_SAS();​
        }​

​

        private void CaptVentSortie_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)​
        {​
            if (CaptVentSortie.Read() == GpioPinValue.Low) ​
            {​
                VCaptVentSortie = 1;​
            }​

            else​
            {​
                VCaptVentSortie = 0;​
            }​
            Etat_SAS();​
        }​
