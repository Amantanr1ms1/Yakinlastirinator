using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZoomApp
{
    static class Program
    {
        // =================================================================
        // NİHAİ DPI ÇÖZÜMÜ (KAYMAYI ENGELLEYEN KOD)
        // =================================================================

        // Windows 10 (Creators Update ve sonrası) için en modern yöntem
        [DllImport("user32.dll")]
        private static extern bool SetThreadDpiAwarenessContext(IntPtr dpiContext);

        // Windows 8.1/Vista için eski yöntem
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        // DPI Farkındalık seviyeleri
        private static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new IntPtr(-4);
        private static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = new IntPtr(-3);
        private static readonly IntPtr DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = new IntPtr(-2);

        /// <summary>
        /// Uygulamanın ana giriş noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Windows'a DPI-duyarlı olduğumuzu söylüyoruz.
            // Bu, Screen.PrimaryScreen.Bounds'un bize FİZİKSEL pikselleri
            // vermesini sağlar (kaymayı engeller).
            // Bu kod, Application.EnableVisualStyles()'dan ÖNCE çağrılmalıdır.
            try
            {
                if (Environment.OSVersion.Version >= new Version(10, 0, 15063))
                {
                    // Win 10 Creators Update ve sonrası
                    SetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
                }
                else if (Environment.OSVersion.Version >= new Version(6, 3, 0))
                {
                    // Win 8.1
                    SetProcessDPIAware();
                }
            }
            catch
            {
                // Bir sorun olursa (eski Windows vb.) devam et
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}