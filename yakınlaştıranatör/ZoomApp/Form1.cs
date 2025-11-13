using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
// GEREKLİ DÜZELTME: Kültür (CultureInfo) için eklendi
using System.Globalization;

namespace ZoomApp
{
    public partial class Form1 : Form
    {
        [DllImport("Magnification.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool MagInitialize();

        [DllImport("Magnification.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool MagUninitialize();

        [DllImport("Magnification.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool MagSetFullscreenTransform(float magLevel, int xOffset, int yOffset);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // =================================================================
        // "HACK" YÖNTEMİ (DPI KAYMASINI ÇÖZMEK İÇİN EKLENDİ)
        // =================================================================
        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(int nIndex);

        public const int SM_CXSCREEN = 0; // Fiziksel ekran genişliği
        public const int SM_CYSCREEN = 1; // Fiziksel ekran yüksekliği
        // =================================================================


        private float zoom = 1.0f;
        private int xOffset = 0, yOffset = 0;
        private double zoomStep = 0.01;

        private Keys zoomInKey = Keys.Add;
        private Keys zoomOutKey = Keys.Subtract;

        public Form1()
        {
            InitializeComponent();

            if (!MagInitialize())
                MessageBox.Show("Magnification API başlatılamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hotkeyleri kaydet
            if (!RegisterHotKey(this.Handle, 1, 0, zoomInKey))
                MessageBox.Show("Zoom In kısayolu kaydedilemedi! Muhtemelen çakışıyor.");
            if (!RegisterHotKey(this.Handle, 2, 0, zoomOutKey))
                MessageBox.Show("Zoom Out kısayolu kaydedilemedi! Muhtemelen çakışıyor.");

            // Tuş seçimleri
            comboBoxZoomIn.DataSource = Enum.GetNames(typeof(Keys));
            comboBoxZoomOut.DataSource = Enum.GetNames(typeof(Keys));
            comboBoxZoomIn.SelectedItem = zoomInKey.ToString();
            comboBoxZoomOut.SelectedItem = zoomOutKey.ToString();

            // Zoom step seçenekleri
            comboBoxStep.Items.AddRange(new object[] { "0.001", "0.005", "0.01", "0.02", "0.05", "0.1", "0.2", "0.3", "0.5", "1.0" });
            comboBoxStep.SelectedIndex = 2; // varsayılan 0.01
        }

        private void comboBoxStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            // DÜZELTME: "0.01" gibi (noktalı) değerlerin Türkçe
            // sistemlerde (virgül bekleyen) düzgün çalışması için.
            if (double.TryParse(comboBoxStep.SelectedItem.ToString(),
                                System.Globalization.NumberStyles.Float,
                                System.Globalization.CultureInfo.InvariantCulture,
                                out double step))
            {
                zoomStep = step;
            }
        }

        private void ZoomAroundScreenCenter(double newZoom)
        {
            if (newZoom < 1.0) newZoom = 1.0;

            // =================================================================
            // "HACK" UYGULAMASI:
            // =================================================================
            // Screen.PrimaryScreen.Bounds (sanal çözünürlük) yerine
            // GetSystemMetrics (fiziksel çözünürlük) kullanıyoruz.
            // Bu, DPI kaymasını engeller.
            double screenW = GetSystemMetrics(SM_CXSCREEN);
            double screenH = GetSystemMetrics(SM_CYSCREEN);
            // =================================================================

            double anchorX = screenW / 2.0;
            double anchorY = screenH / 2.0;

            double srcX = xOffset + (anchorX / zoom);
            double srcY = yOffset + (anchorY / zoom);

            double newXOffset = srcX - (anchorX / newZoom);
            double newYOffset = srcY - (anchorY / newZoom);

            double maxX = Math.Max(0, screenW - (screenW / newZoom));
            double maxY = Math.Max(0, screenH - (screenH / newZoom));

            xOffset = (int)Math.Round(Math.Min(Math.Max(newXOffset, 0), maxX));
            yOffset = (int)Math.Round(Math.Min(Math.Max(newYOffset, 0), maxY));

            zoom = (float)newZoom;
            ApplyTransform();
        }

        private void ApplyTransform()
        {
            if (!MagSetFullscreenTransform(zoom, xOffset, yOffset))
                MagSetFullscreenTransform(1.0f, 0, 0);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();
                if (id == 1) ZoomAroundScreenCenter(zoom + zoomStep);
                else if (id == 2) ZoomAroundScreenCenter(zoom - zoomStep);
            }
            base.WndProc(ref m);
        }

        private void btnSetZoomIn_Click(object sender, EventArgs e)
        {
            UnregisterHotKey(this.Handle, 1);
            zoomInKey = (Keys)Enum.Parse(typeof(Keys), comboBoxZoomIn.SelectedItem.ToString());
            if (!RegisterHotKey(this.Handle, 1, 0, zoomInKey))
                MessageBox.Show("Zoom In kısayolu kaydedilemedi! Muhtemelen çakışıyor.");
        }

        private void btnSetZoomOut_Click(object sender, EventArgs e)
        {
            UnregisterHotKey(this.Handle, 2);
            zoomOutKey = (Keys)Enum.Parse(typeof(Keys), comboBoxZoomOut.SelectedItem.ToString());
            if (!RegisterHotKey(this.Handle, 2, 0, zoomOutKey))
                MessageBox.Show("Zoom Out kısayolu kaydedilemedi! Muhtemelen çakışıyor.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            zoom = 1.0f;
            xOffset = 0;
            yOffset = 0;
            ApplyTransform();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxZoomOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelZoomOut_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
            MagUninitialize();
            base.OnFormClosed(e);
        }
    }
}
