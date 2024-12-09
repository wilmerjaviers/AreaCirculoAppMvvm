using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AreaCirculoAppMvvm.ViewModels
{
    public partial class AreaCirculoViewModel : ObservableObject
    {
        [ObservableProperty]
        private double _radio;

        [ObservableProperty]
        private double _area;

        [ObservableProperty]
        private string _radioTexto = string.Empty;

        [ObservableProperty]
        private string _resultadoTexto = string.Empty;

        [ObservableProperty]
        private bool _esAreaPrecisa;

        [RelayCommand]
        private void Calcular()
        {
            try
            {
                
                if (double.TryParse(RadioTexto, out double radio))
                {
                    Radio = radio;
                    Area = CalcularArea(Radio);
                    ResultadoTexto = $"El Área es de: {Area:F4} {(EsAreaPrecisa ? "(Precisión Alta)" : "(Aproximación)")}";
                }
            }
            catch (Exception ex)
            {
                ResultadoTexto = $"Error: {ex.Message}";
            }
        }

        private double CalcularArea(double radio)
        {
            if (EsAreaPrecisa)
            {
                
                return Math.Round(Math.PI * Math.Pow(radio, 2), 4);
            }
            else
            {
                
                return Math.PI * radio * radio;
            }
        }

        [RelayCommand]
        private void Limpiar()
        {
            RadioTexto = string.Empty;
            ResultadoTexto = string.Empty;
            Radio = 0;
            Area = 0;
            EsAreaPrecisa = false;
        }

    }
}