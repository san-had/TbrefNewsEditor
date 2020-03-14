using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ScriptGenerator.Dto;
using ScriptGenerator.Extensibility;

namespace Editor
{
    public partial class Form1 : Form
    {
        private const string ConstEventsFileName = "const_events.txt";
        private const string ConstNewsFileName = "const_news.txt";

        private readonly IScriptGenerator scriptGenerator;

        public Form1(IScriptGenerator scriptGenerator)
        {
            InitializeComponent();

            LoadConstants();

            this.scriptGenerator = scriptGenerator;
        }

        private void LoadConstants()
        {
            txtEvents.Text = ReadingConstant(ConstEventsFileName);
            txtNews.Text = ReadingConstant(ConstNewsFileName);
        }

        private string ReadingConstant(string fileName)
        {
            string templateString = string.Empty;

            string filePath = $".\\Resources\\{fileName}";
            string fullPath = Path.GetFullPath(filePath);

            using (var streamReader = new StreamReader(File.OpenRead(fullPath), System.Text.Encoding.Default))
            {
                templateString = streamReader.ReadToEnd();
            }
            return templateString;
        }

        private InputDto LoadInputs()
        {
            var inputDto = new InputDto();
            inputDto.Verb = txtVerb.Text;
            inputDto.Events = txtEvents.Text;
            inputDto.News = txtNews.Text;
            return inputDto;
        }

        private void btnGenerateScript_Click(object sender, System.EventArgs e)
        {
            var inputDto = LoadInputs();

            var scriptDto = scriptGenerator.ScriptGeneration(inputDto);

            txtScript.Text = scriptDto.MainScript;
        }

        private void btnCopyScript_Click(object sender, System.EventArgs e)
        {
            txtScript.Focus();
            txtScript.Copy();
            txtScript.BackColor = Color.FromArgb(255, 255, 221);
        }
    }
}