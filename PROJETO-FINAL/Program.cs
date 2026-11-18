using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using ViceCityCentral.Data;
using ViceCityCentral.Services;
using ViceCityCentral.Views;
using ViceCityCentral.Views.Components;

namespace ViceCityCentral
{
    internal static class Program
    {
        /// <summary>Ponto de entrada da aplicação.</summary>
        [STAThread]
        private static void Main()
        {
            var cultura = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = cultura;
            Thread.CurrentThread.CurrentUICulture = cultura;
            CultureInfo.DefaultThreadCurrentCulture = cultura;
            CultureInfo.DefaultThreadCurrentUICulture = cultura;

            // Qualquer erro não tratado vira uma mensagem amigável (e é registrado em logs/erros.log).
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) =>
                Mensagem.Erro(null, "Ocorreu um erro inesperado:\n\n" + e.Exception.Message, e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                if (e.ExceptionObject is Exception ex) RegistroErros.Registrar(ex);
            };

#if !MONO
            Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseInitializer.Inicializar();
                ConfiguracaoService.Instancia.Carregar();
            }
            catch (Exception ex)
            {
                RegistroErros.Registrar(ex);
                MessageBox.Show(
                    "Não foi possível inicializar o banco de dados.\n\n" + ex.Message +
                    "\n\nVerifique se a pasta do programa permite gravação e se o arquivo Database/vice_city.sql existe.",
                    "Vice City Central — Erro ao iniciar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm());
        }
    }
}
