
namespace FS80H.Scanner;

public partial class Form1 : Form
{
    private Futronic _futronic;
    private bool _isInitialized = false;


    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_FormClosing(object sender, EventArgs e)
    {
        if (_isInitialized)
        {
            _futronic.SetDiodesStatus(false, false);
            txtLogs.AppendText("Fingerprint scanner disposed. \r\n");
        }
    }

    private void btn_Start_Capture_Click(object sender, EventArgs e)
    {
        _futronic = new Futronic();
        _isInitialized = _futronic.Init();
        if (_isInitialized)
        {
            _futronic.SetDiodesStatus(true, false);
            txtLogs.AppendText("Fingerprint scanner connected. \r\n");
            Thread.Sleep(200);
            _futronic.SetDiodesStatus(false, false);
            Thread.Sleep(50);
            _futronic.SetDiodesStatus(true, false);
            Thread.Sleep(200);
            _futronic.SetDiodesStatus(false, false);

        }
        else
        {
            _futronic.SetDiodesStatus(false, true);
            txtLogs.AppendText("Failed to connect to Fingerprint scanner. \r\n");
        }
    }

    private void btn_Complete_Capture_Click(object sender, EventArgs e)
    {
        if (_isInitialized)
        {
            // Capture fingerprint
            var fingerprintBitMap = _futronic.ExportBitMap();
            Fingerprint.Image = fingerprintBitMap;

            var isFingerprint = _futronic.IsFinger();
            if (isFingerprint)
            {
                _futronic.SetDiodesStatus(true, false);
                txtLogs.AppendText("Fingerprint captured successfully. \r\n");
                Thread.Sleep(1500);
                _futronic.SetDiodesStatus(false, false);
            }
            else
            {
                _futronic.SetDiodesStatus(false, true);
                txtLogs.AppendText("Invalid fingerprint. \r\n");
                Thread.Sleep(1500);
                _futronic.SetDiodesStatus(false, false);
            }
        }
        else
        {
            txtLogs.AppendText("Fingerprint scanner not connected. \r\n");
        }
    }
    private void btn_Download_Click(object sender, EventArgs e)
    {
        var image = Fingerprint.Image;
        if (image != null)
        {
            var saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
                RestoreDirectory = true,
                Filter = "WSQ|*.wsq",
                Title = "Save an Image File"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveFileDialog.FileName);
                txtLogs.AppendText("Fingerprint saved successfully as " + saveFileDialog.FileName + ".  \r\n");
            }
        }
    }
}

