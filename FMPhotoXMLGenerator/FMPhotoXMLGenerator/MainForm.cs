using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace FMPhotoXMLGenerator
{
    public partial class MainForm : Form
    {
        private Processor _processor;
        private Data _data;
        
        public MainForm()
        {
            InitializeComponent();

            _data = new Data();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sports Interactive\\Football Manager 2024\\players\\headphoto");
            folderPathText.Text = Directory.Exists(path) ? path : string.Empty;
            fromIdText.Text = "2002000000";
            toIdText.Text = "2002500000";
            isRandomPlayerCheckBox.Checked = false;
            isRandomOrderCheckBox.Checked = false;
            progressBar.Text = string.Empty;
            progressBar.Maximum = 100;
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            _data.DirectorPath = folderPathText.Text;
            _data.fromId = long.Parse(fromIdText.Text);
            _data.toId = long.Parse(toIdText.Text);
            _data.IsRandomPlayer = isRandomPlayerCheckBox.Checked;
            _data.IsRandomOrder = isRandomOrderCheckBox.Checked;
            _processor = new Processor(_data);
            _processor.MessageBoxEvent += OnMessageBoxEvent;
            _processor.ProgressEvent += OnProgressEvent;
        }

        private void OnProgressEvent(float percentage)
        {
            progressBar.Value = (int)(progressBar.Maximum * percentage);
        }

        private void OnMessageBoxEvent(string message)
        {
            MessageBox.Show(message);
        }
        
        private bool CheckDirectorExist()
        {
            if (Directory.Exists(folderPathText.Text))
            {
                return true;
            }

            MessageBox.Show(Messages.DirectorNotExist);
            return false;
        }

        private bool CheckId()
        {
            if (_data.toId < _data.fromId)
            {
                MessageBox.Show(Messages.IdCompareError);
                return false;
            }

            long count = _data.toId - _data.fromId;

            if (count >= int.MaxValue)
            {
                MessageBox.Show(Messages.IdCountOverflow);
                return false;
            }

            return true;
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (Directory.Exists(folderPathText.Text))
            {
                folderBrowserDialog.SelectedPath = folderPathText.Text;
            }

            var result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.folderPathText.Text = folderBrowserDialog.SelectedPath;
                _data.DirectorPath = folderBrowserDialog.SelectedPath;
            }
        }
        
        private void genNewXmlButton_Click(object sender, EventArgs e)
        {
            if (CheckDirectorExist() && CheckId())
            {
                if (_processor.GenNewXml())
                {
                    MessageBox.Show(Messages.GenNewXmlSuccess);
                }
                else
                {
                    MessageBox.Show(Messages.GenNewXmlFail);
                }
            }
        }
        
        private void appendXmlButton_Click(object sender, EventArgs e)
        {
            if (CheckDirectorExist() && CheckId())
            {
                if (_processor.AppendId())
                {
                    MessageBox.Show(Messages.AppendIdSuccess);
                }
                else
                {
                    MessageBox.Show(Messages.AppendIdFail);
                }
            }
        }
        
        private void CopyFileButton_Click(object sender, EventArgs e)
        {
            if (CheckDirectorExist())
            {
                if (_processor.CopyXmlFile())
                {
                    MessageBox.Show(Messages.CopyXmlFileSuccess);
                }
                else
                {
                    MessageBox.Show(Messages.CopyXmlFileFail);
                }
            }
        }
        
        private void remappingButton_Click(object sender, EventArgs e)
        {
            if (CheckDirectorExist())
            {
                if (_processor.Remapping())
                {
                    MessageBox.Show(Messages.GenRemappingXmlSuccess);
                }
                else
                {
                    MessageBox.Show(Messages.GenRemappingXmlFail);
                }
            }
        }

        private void folderPathText_TextChanged(object sender, EventArgs e)
        {
        }

        private void isRandomPlayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _data.IsRandomPlayer = isRandomPlayerCheckBox.Checked;
        }

        private void fromIdText_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = fromIdText.SelectionStart;
            
            try
            {
                _data.fromId = long.Parse(fromIdText.Text);
            }
            catch (OverflowException exception)
            {
                MessageBox.Show(Messages.IdOverflow);
                fromIdText.Text = _data.fromId.ToString();
                fromIdText.SelectionStart = selectionStart - 1;
            }
            catch (Exception exception)
            {
                fromIdText.Text = _data.fromId.ToString();
                fromIdText.SelectionStart = selectionStart - 1;
            }
        }

        private void toIdText_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = toIdText.SelectionStart;

            try
            {
                _data.toId = long.Parse(toIdText.Text);
            }
            catch (OverflowException exception)
            {
                MessageBox.Show(Messages.IdOverflow);
                toIdText.Text = _data.toId.ToString();
                toIdText.SelectionStart = selectionStart - 1;
            }
            catch (Exception exception)
            {
                toIdText.Text = _data.toId.ToString();
                toIdText.SelectionStart = selectionStart - 1;
            }
        }

        private void isByFileNameOrderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _data.IsRandomOrder = isRandomOrderCheckBox.Checked;
        }
    }
}