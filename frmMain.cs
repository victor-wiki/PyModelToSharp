using Python.Runtime;
using System.Diagnostics;
using System.Reflection;

namespace PyModelToSharp
{
    public partial class frmMain : Form
    {
        private bool inited = false;

        public frmMain()
        {
            InitializeComponent();

            ComboBox.CheckForIllegalCrossThreadCalls = false;
            TextBox.CheckForIllegalCrossThreadCalls = false;
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
            var pythonPaths = this.GetPythonPaths();

            if (pythonPaths.Any())
            {
                this.cboPythonPath.Items.AddRange(pythonPaths.ToArray());

                this.cboPythonPath.SelectedIndex = 0;                
            }          
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            this.Convert();
        }

        private void Convert()
        {
            string pythonPath = this.cboPythonPath.Text.Trim();

            if (string.IsNullOrEmpty(pythonPath))
            {
                MessageBox.Show("Python interpreter can't be empty!");
                return;
            }

            string packagesPath = this.txtPackagesPath.Text.Trim();

            if (string.IsNullOrEmpty(packagesPath))
            {
                MessageBox.Show("Path of site-packages can't be empty!");
                return;
            }

            string saveFolder = this.txtSaveFolder.Text.Trim();

            if (string.IsNullOrEmpty(saveFolder))
            {
                MessageBox.Show("Save Path can't be empty!");
                return;
            }

            string modelName = this.txtModelName.Text.Trim();

            if (string.IsNullOrEmpty(modelName))
            {
                MessageBox.Show("Model Name can't be empty!");
                return;
            }

            this.txtMessage.Clear();
            this.cboPythonPath.Enabled = false;

            Task.Run(() => { this.Execute(); });
        }

        private void Execute()
        {
            string pythonPath = this.cboPythonPath.Text;

            List<string> packagesPaths = new List<string>();

            packagesPaths.AddRange(this.txtPackagesPath.Text.Trim().Split(';'));

            packagesPaths.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            string modelName = this.txtModelName.Text.Trim();
            string saveFolder = this.txtSaveFolder.Text.Trim();

            try
            {
                this.AppendMessage("initing...");

                if(!this.inited)
                {
                    string pythonDllPath = new DirectoryInfo(Path.GetDirectoryName(pythonPath))
                                 .GetFiles("python*.dll").OrderByDescending(item => item.Name)
                                 .Select(item => item.FullName).FirstOrDefault();

                    Runtime.PythonDLL = pythonDllPath;

                    PythonEngine.Initialize();                   
                }               

                PythonEngine.PythonPath = string.Join(";", packagesPaths);

                if(!this.inited)
                {
                    PythonEngine.BeginAllowThreads();
                }

                this.inited = true;

                this.AppendMessage("inited.");

                using (Py.GIL())
                {
                    dynamic exportsd = Py.Import(@"exportsd");

                    dynamic torch = Py.Import("torch");

                    this.AppendMessage("importing transformers...");

                    dynamic main = Py.Import(@"main");

                    this.AppendMessage("transformers imported.");

                    this.AppendMessage("loading model...");

                    string fileName = $"{modelName.Replace("/", "--")}.dat";
                    string filePath = Path.Combine(saveFolder, fileName);

                    dynamic ctc_model = main.get_model(modelName);

                    this.AppendMessage("model loaded.");

                    dynamic builtins = Py.Import("builtins");

                    dynamic f = builtins.open(filePath, "wb");

                    this.AppendMessage("converting model...");

                    exportsd.save_state_dict(ctc_model.to("cpu").state_dict(), f);

                    f.close();

                    this.AppendMessage("model converted.");

                    this.AppendMessage($"the exported dat file name is: {fileName}");                  

                    MessageBox.Show("Converted.");
                }
            }
            catch (Exception ex)
            {
                this.AppendMessage(ex.Message, true);

                MessageBox.Show(ex.Message);
            }            
        }

        private void AppendMessage(string message, bool isError = false)
        {
            int start = this.txtMessage.Text.Length;

            if (start > 0)
            {
                this.txtMessage.AppendText(Environment.NewLine);
            }

            this.txtMessage.AppendText(message);

            this.txtMessage.Select(start, this.txtMessage.Text.Length - start);
            this.txtMessage.SelectionColor = isError ? Color.Red : Color.Black;

            this.txtMessage.SelectionStart = this.txtMessage.TextLength;

            this.txtMessage.ScrollToCaret();
        }

        private List<string> GetPythonPaths()
        {
            var result = new List<string>();

            try
            {
                var start = new ProcessStartInfo
                {
                    FileName = "py",
                    Arguments = "-0p",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(start))
                using (var reader = process.StandardOutput)
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            result.Add(line.Split(' ').LastOrDefault().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        private void btnOpenPackagesPath_Click(object sender, EventArgs e)
        {
            string interpreterPath = this.cboPythonPath.Text.Trim();

            if (!string.IsNullOrEmpty(interpreterPath) && File.Exists(interpreterPath))
            {
                if (this.txtPackagesPath.Text.Trim().Length == 0)
                {
                    this.folderBrowserDialog1.InitialDirectory = Path.GetDirectoryName(interpreterPath);
                }
            }

            var result = this.folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.txtPackagesPath.Text = string.Join(";", this.folderBrowserDialog1.SelectedPaths);
            }
        }

        private void btnOpenSavePath_Click(object sender, EventArgs e)
        {
            var result = this.folderBrowserDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.txtSaveFolder.Text = this.folderBrowserDialog2.SelectedPath;
            }
        }

        private void cboPythonPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboPythonPath.SelectedIndex >= 0 && File.Exists(this.cboPythonPath.Text) && this.txtPackagesPath.Text.Trim().Length == 0)
            {
                string defaultSitePackagesPath = Path.Combine(Path.GetDirectoryName(this.cboPythonPath.Text), "Lib/site-packages");

                if (Directory.Exists(defaultSitePackagesPath))
                {
                    this.txtPackagesPath.Text = defaultSitePackagesPath;
                }
            }          
        }       
    }
}
