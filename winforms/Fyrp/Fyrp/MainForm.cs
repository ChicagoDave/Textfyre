﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Textfyre.VM;

namespace FyreWinClient {
    public partial class MainForm : Form {
        private Engine vm;
        private Thread vmThread;

        private AutoResetEvent inputReadyEvent = new AutoResetEvent(false);
        private bool lineWanted = false;
        private bool keyWanted = false;
        private string inputLine = null;
        private string textLine = null;
        private string[] channelText = new string[18];
        private string chapter = "";
        private string location = "";
        private string time = "";
        //private string score = "";
        private string prompt = "> ";
        private Size saveSize;
        private Point saveLocation;
        private FormBorderStyle saveBorder;
        bool isFullScreen = false;
        bool resetPreferences = false;
        List<string> history = new List<string>();
        int historyIndex = 0;
        MemoryStream fileData;

        public MainForm() {
            InitializeComponent();
            Properties.Settings.Default.Reload();
            OpenFile();
        }

        private void SetPreferences() {
            Header.Font = Properties.Settings.Default.HeaderFooterFont;
            Header.Font = Properties.Settings.Default.HeaderFooterFont;
            Header.ForeColor = Properties.Settings.Default.HeaderForeColor;
            Header.BackColor = Properties.Settings.Default.HeaderBackColor;

            ScoreTime.Font = Properties.Settings.Default.HeaderFooterFont;
            ScoreTime.Font = Properties.Settings.Default.HeaderFooterFont;
            ScoreTime.ForeColor = Properties.Settings.Default.HeaderForeColor;
            ScoreTime.BackColor = Properties.Settings.Default.HeaderBackColor;

            tableLayoutPanel2.BackColor = Properties.Settings.Default.HeaderBackColor;

            TextWindow.Font = Properties.Settings.Default.GameFont;
            TextWindow.BackColor = Properties.Settings.Default.MainBackColor;
            TextWindow.ForeColor = Properties.Settings.Default.MainForeColor;
        }

        private void StartGame() {

            if (vmThread != null) {
                vmThread.Abort();
                vmThread.Join();
            }

            Header.Text = "";
            TextWindow.Clear();

            vm = new Engine(fileData);
            vm.OutputFilterEnabled = false;

            vm.LineWanted += new LineWantedEventHandler(vm_LineWanted);
            vm.KeyWanted += new KeyWantedEventHandler(vm_KeyWanted);
            vm.OutputReady += new OutputReadyEventHandler(vm_OutputReady);
            vm.SaveRequested += new SaveRestoreEventHandler(vm_SaveRequested);
            vm.LoadRequested += new SaveRestoreEventHandler(vm_LoadRequested);

            vmThread = new Thread(VMThreadProc);
            vmThread.IsBackground = true;
            vmThread.Start();
        }

        private void OpenFile() {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "FyreVM Files (*.ulx)|*.ulx";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                this.Close();

            fileData = new MemoryStream();

            FileStream fs;
            fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            int blockSize = 4096;
            int bytesRead;
            byte[] buffer = new byte[blockSize];

            fs.Position = 0;
            while (!(fs.Position == fs.Length))
            {
	            bytesRead = fs.Read(buffer, 0, blockSize);
	            fileData.Write(buffer, 0, bytesRead);
            }

            fs.Close();

            SetPreferences();
            StartGame();
        }

        private void MenuSave_Click(object sender, EventArgs e) {

        }

        private void MenuLoad_Click(object sender, EventArgs e) {

        }

        private void MenuExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void RequestLine() {
            lineWanted = true;
            keyWanted = false;

            TextWindow.Enabled = true;
            TextWindow.AppendText(String.Concat("\n", prompt, " "));
            textLine = "";
            inputLine = "";
            TextWindow.Focus();
        }

        private void RequestKey() {
            lineWanted = false;
            keyWanted = true;

            TextWindow.Enabled = true;
            textLine = "";
            inputLine = "";
            TextWindow.Focus();
        }

        private void TextWindow_KeyPress(object sender, KeyPressEventArgs e) {
            int promptLength = prompt.Length + 1;
            if (keyWanted) {
                GotInput(new string(e.KeyChar, 1));
                e.Handled = true;
            } else
                if (e.KeyChar == '\r' || e.KeyChar == '\n') {
                e.Handled = true;
            }

            if (e.KeyChar == '\b') {
                if (textLine == "") {
                    e.Handled = true;
                    return;
                }
                if (textLine.Length > 0) {
                    textLine = textLine.Substring(0, textLine.Length - 1);
                }
            } else {
                textLine += e.KeyChar.ToString();
                //TextWindow.AppendText(e.KeyChar.ToString());
            }
        }

        private void TextWindow_KeyDown(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.F11) {
                FullScreenToggle();
                return;
            }

            if (e.KeyCode == Keys.Up) {
                e.Handled = true;
                if (history.Count > 0) {
                    if (historyIndex > 0) {
                        historyIndex--;
                        ShowHistoryCommand();
                    }
                }
            }

            if (e.KeyCode == Keys.Down) {
                e.Handled = true;
                if (historyIndex < (history.Count - 1)) {
                    historyIndex++;
                    ShowHistoryCommand();
                }
            }

            if (e.KeyCode == Keys.Escape) {
                e.Handled = true;
                RemoveCommand();
            }

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) {
                e.Handled = true;

                if (keyWanted) {
                    GotInput("\n");
                } else if (lineWanted) {
                    GotInput(textLine);
                }
            }

            if (e.KeyCode == Keys.Back && textLine == "")
                e.Handled = true;

            if (e.KeyCode != Keys.PageUp && e.KeyCode != Keys.PageDown)
                TextWindow.SelectionStart = TextWindow.Text.Length;
        }

        /// <summary>
        /// carat = > position
        /// erase everything after carat
        /// add command
        /// </summary>
        private void ShowHistoryCommand() {
            RemoveCommand();
            TextWindow.AppendText(history[historyIndex]);
            textLine = history[historyIndex];
        }

        private void RemoveCommand() {
            int carat = TextWindow.Text.Length - 1;
            if (TextWindow.Text.Substring(carat - 1, 1) != ">") {
                for (int position = carat; position > -1; position--) {
                    if (TextWindow.Text[position] == '>') {
                        carat = position + 2; // include space
                        break;
                    }
                }
                TextWindow.SelectionStart = carat;
                TextWindow.SelectionLength = TextWindow.Text.Length - carat;
                TextWindow.Cut();
                textLine = "";
            }
        }

        private void GotInput(string line) {
            TextWindow.SelectionStart = TextWindow.Text.LastIndexOf(">");
            int endLine = TextWindow.Text.IndexOf('\n', TextWindow.SelectionStart, TextWindow.Text.Length-1-TextWindow.SelectionStart);
            if (endLine == -1) endLine = TextWindow.Text.Length;
            TextWindow.SelectionLength = endLine - TextWindow.SelectionStart;
            TextWindow.SelectionFont = new Font(Properties.Settings.Default.GameFont, FontStyle.Bold);
            TextWindow.AppendText("\r\n");
            TextWindow.SelectionFont = new Font(Properties.Settings.Default.GameFont, FontStyle.Regular);
            inputLine = line;
            textLine = "";
            history.Add(inputLine);
            historyIndex = history.Count;
            inputReadyEvent.Set();
        }

        private void HandleOutput(Dictionary<OutputChannel, string> package) {
            string text;

            if (package.TryGetValue(OutputChannel.Title, out text)) {
                channelText[(int)OutputChannel.Title] = text.Trim();
            }

            if (package.TryGetValue(OutputChannel.Prologue, out text)) {
                channelText[(int)OutputChannel.Prologue] = text.Trim();

                TextWindow.AppendText(String.Format("{0}\r\n", text));
            }

            if (package.TryGetValue(OutputChannel.Credits, out text)) {
                channelText[(int)OutputChannel.Credits] = text.Trim();

                TextWindow.AppendText(String.Concat(text.Trim().Replace("&#169;","@"),"\r\n\r\n"));
            }

            if (package.TryGetValue(OutputChannel.Main, out text)) {
                channelText[((int)OutputChannel.Main)] = text;

                TextWindow.AppendText(String.Concat(text.Trim(),"\r\n"));
            }

            if (package.TryGetValue(OutputChannel.Location, out text)) {
                channelText[(int)OutputChannel.Location] = text.Trim();

                location = text;
            }

            if (package.TryGetValue(OutputChannel.Score, out text)) {
                channelText[(int)OutputChannel.Score] = text.Trim();

                //score = ""; // ignore for Secret Letter String.Format("Score: {0}", text);
            }

            if (package.TryGetValue(OutputChannel.Time, out text)) {
                channelText[(int)OutputChannel.Time] = text.Trim();

                time = String.Format("Turn: {0}", text);
            }

            if (package.TryGetValue(OutputChannel.Hints, out text)) {
                channelText[(int)OutputChannel.Hints] = text.Trim();
            }

            if (package.TryGetValue(OutputChannel.Help, out text)) {
                channelText[(int)OutputChannel.Help] = text.Trim();
            }

            if (package.TryGetValue(OutputChannel.Map, out text)) {
                channelText[(int)OutputChannel.Map] = text.Trim();
            }

            if (package.TryGetValue(OutputChannel.Progress, out text)) {
                channelText[(int)OutputChannel.Progress] = text.Trim();
            }

            if (package.TryGetValue(OutputChannel.Theme, out text)) {
                channelText[(int)OutputChannel.Theme] = text.Trim();
            }

            if (package.TryGetValue(OutputChannel.Prompt, out text)) {
                channelText[(int)OutputChannel.Prompt] = text.Trim();

                prompt = text;
            }

            if (package.TryGetValue(OutputChannel.Conversation, out text)) {
                TextWindow.AppendText("\r\n");
                channelText[(int)OutputChannel.Conversation] = text.Trim();

                if (text.Length > 0) {
                    string[] delim = new string[] {"\n"};
                    string[] clines = text.Split(delim, StringSplitOptions.RemoveEmptyEntries);

                    int num = 0;
                    foreach (string cline in clines) {
                        num++;
                        TextWindow.AppendText(string.Format("{0}. {1}\r\n", num, cline));
                    }
                }
            }

            if (package.TryGetValue(OutputChannel.Sound, out text)) {
                channelText[(int)OutputChannel.Sound] = text.Trim();
            }

            if (package.TryGetValue(OutputChannel.Chapter, out text)) {
                channelText[(int)OutputChannel.Chapter] = text.Trim();

                chapter = text;
            }

            if (package.TryGetValue(OutputChannel.Death, out text)) {
                channelText[(int)OutputChannel.Death] = text.Trim();
            }

            Header.Text = String.Format("{0} - {1}", chapter, location);
            ScoreTime.Text = String.Format("{0}", time);

            if (resetPreferences) {
                resetPreferences = false;
                SetPreferences();
            }
            TextWindow.ScrollToCaret();
        }

        /// <summary>
        /// Handle large text...pause for each page
        /// </summary>
        /// <param name="text"></param>
        //private void More(string text) {
            
        //}

        private void ArrangeInput(object sender, EventArgs e) {
            // we don't care about the > prompt in the WinForms version...
        }

        private Stream RequestSaveStream() {
            using (SaveFileDialog dlg = new SaveFileDialog()) {
                dlg.Title = "Select Save File";
                dlg.Filter = "Textfyre save files (*.tfq)|*.tfq";

                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return null;
                else {
                    RichTextBox temp = new RichTextBox();
                    temp.AppendText(TextWindow.Text);
                    temp.SelectionStart = temp.Text.Length - 7;
                    temp.SelectionLength = 7;
                    temp.Cut();
                    temp.AppendText("> restore\n");
                    temp.SaveFile(string.Concat(dlg.FileName,".tfx"));
                    temp = null;
                    return new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                }
            }
        }

        private Stream RequestLoadStream() {
            using (OpenFileDialog dlg = new OpenFileDialog()) {
                dlg.Title = "Load a Saved Game";
                dlg.Filter = "Textfyre save files (*.tfq)|*.tfq";

                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return null;
                else {
                    TextWindow.LoadFile(string.Concat(dlg.FileName, ".tfx"));
                    SetPreferences();
                    return new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                }
            }
        }

        private void GameFinished() {
            this.Close();
        }

        #region VM Thread

        private void VMThreadProc(object dummy) {
            try {
                vm.Run();
                this.Invoke(new Action(GameFinished));
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void vm_LineWanted(object sender, LineWantedEventArgs e) {
            this.Invoke(new Action(RequestLine));
            inputReadyEvent.WaitOne();
            e.Line = inputLine;
        }

        private void vm_KeyWanted(object sender, KeyWantedEventArgs e) {
            this.Invoke(new Action(RequestKey));
            inputReadyEvent.WaitOne();
            e.Char = inputLine[0];
        }

        private void vm_OutputReady(object sender, OutputReadyEventArgs e) {
            this.Invoke(
                new Action<Dictionary<OutputChannel, string>>(HandleOutput),
                e.Package);
        }

        private void vm_SaveRequested(object sender, SaveRestoreEventArgs e) {
            e.Stream = (Stream)this.Invoke(new Func<Stream>(RequestSaveStream));
        }

        private void vm_LoadRequested(object sender, SaveRestoreEventArgs e) {
            resetPreferences = true;
            e.Stream = (Stream)this.Invoke(new Func<Stream>(RequestLoadStream));
        }
        #endregion

        private void MenuPreferences_Click(object sender, EventArgs e) {
            Preferences prefWindow = new Preferences();
            DialogResult result = prefWindow.ShowDialog();
            if (result == DialogResult.OK) {
                SetPreferences();
                Properties.Settings.Default.Save();
            }
        }

        private void TextWindow_LinkClicked(object sender, LinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void FullScreenToggle() {
            if (!isFullScreen) {
                saveSize = this.Size;
                saveLocation = this.Location;
                saveBorder = this.FormBorderStyle;
                menuStrip1.Visible = false;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Size = Screen.PrimaryScreen.Bounds.Size;
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
                isFullScreen = true;
            } else {
                menuStrip1.Visible = true;
                this.Size = saveSize;
                this.Location = saveLocation;
                this.FormBorderStyle = saveBorder;
                isFullScreen = false;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void openMenuItem_Click(object sender, EventArgs e) {
            OpenFile();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            this.CenterToScreen();
            this.TopMost = false;
            this.TopMost = true;
            this.TopMost = false;
            this.BringToFront();
        }

    }
}
