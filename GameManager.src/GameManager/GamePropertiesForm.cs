using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GameManager {
    public partial class GamePropertiesForm : Form {
        private static Regex autoCopySwitch = new Regex(@"/c\d*", RegexOptions.IgnoreCase);
        private static Regex removeRepSymbolsSwitch = new Regex(@"/ks\d*", RegexOptions.IgnoreCase);
        private static Regex suppressRepPhrasesSwitch = new Regex(@"/kf\d*:?\d*", RegexOptions.IgnoreCase);
        private static Regex alwaysOnTopSwitch = new Regex(@"/t", RegexOptions.IgnoreCase);
        private static Regex splitParamsSwitch = new Regex(@"/b[\d:]*", RegexOptions.IgnoreCase);
        private static Regex doubleWhitespace = new Regex(@"\s+");

        private Game game;
        private bool suppressEventHandlers = false;

        public GamePropertiesForm(Game game) {
            this.game = game;

            InitializeComponent();
            InitializeAgthOptions();
            InitializeResolutionOptions();

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }
        }

        private string GetDefaultAgthOptions() {
            var options = Settings.Instance.AgthDefaultParameters;

            if (Settings.Instance.UseHCodeForWolfGames && game.WolfRpgMakerVersion != null) {
                if (game.WolfRpgMakerVersion == "Unknown") {
                    game.WolfRpgMakerVersion = IOUtility.GetWolfRpgVersion(game.Path);
                }

                if (game.WolfRpgMakerVersion != null) {
                    options += " " + IOUtility.GetWolfRpgAgthParams(game.WolfRpgMakerVersion);
                }
            }
            return options;
        }

        private void InitializeAgthOptions() {
            if (game.AgthParameters == null) {
                options.Text = GetDefaultAgthOptions();
            }
            else {
                options.Text = game.AgthParameters;
            }

            useAgth.Checked = game.RunWithAgth.HasValue ? game.RunWithAgth.Value : Settings.Instance.LaunchGamesWithAgth;
            useChiiTrans.Checked = game.RunWithChiiTrans.HasValue ? game.RunWithChiiTrans.Value : Settings.Instance.LaunchGamesWithChiiTrans;
            ParseAgthParameters();
        }

        private static List<ScreenResolution> supportedResolutions = ScreenUtility.GetSupportedResolutions().Reverse().ToList();

        private void InitializeResolutionOptions() {
            resolutionList.Items.Add("Use default");
            resolutionList.Items.Add("No change");

            foreach (var resolution in supportedResolutions) {
                resolutionList.Items.Add(resolution.ToString());
            }

            if (game.CustomResolution == null) {
                if (!game.UseCustomResolution) {
                    resolutionList.SelectedIndex = 0;
                }
                else {
                    resolutionList.SelectedIndex = 1;
                }
            }
            else {
                int index = resolutionList.Items.IndexOf(game.CustomResolution.ToString());
                resolutionList.SelectedIndex = index == -1 ? 0 : index;
            }
        }

        /// <summary>
        /// Makes the checkboxes and text fields match the game's AGTH parameters.
        /// </summary>
        private void ParseAgthParameters() {
            suppressEventHandlers = true;
            autoCopyDelay.Text = "150";
            removeRepsCount.Text = "1";
            traceParam1.Text = "32";
            traceParam2.Text = "16";
            splitParam1.Text = "4";
            splitParam2.Text = "24";
            splitParam3.Text = "1000";

            var match = autoCopySwitch.Match(options.Text);

            if (match.Success) {
                autoCopy.Checked = true;

                if (match.Length > 2) {
                    autoCopyDelay.Text = match.Value.Substring(2);
                }
            }
            else {
                autoCopy.Checked = false;
            }

            match = removeRepSymbolsSwitch.Match(options.Text);

            if (match.Success) {
                removeRepSymbols.Checked = true;

                if (match.Length > 3) {
                    removeRepsCount.Text = match.Value.Substring(3);
                }
            }
            else {
                removeRepSymbols.Checked = false;
            }

            match = suppressRepPhrasesSwitch.Match(options.Text);

            if (match.Success) {
                suppressRepPhrases.Checked = true;
                var colonIndex = match.Value.IndexOf(':');

                if (match.Length > 3) {
                    if (colonIndex > 0) {
                        traceParam1.Text = match.Value.Substring(3, colonIndex - 3);
                        traceParam2.Text = match.Value.Substring(colonIndex + 1);
                    }
                    else {
                        traceParam1.Text = match.Value.Substring(3);
                    }
                }
            }
            else {
                suppressRepPhrases.Checked = false;
            }

            match = splitParamsSwitch.Match(options.Text);

            if (match.Success) {
                int firstColonIndex = match.Value.IndexOf(':');

                if (match.Length > 2) {
                    if (firstColonIndex > 0) {
                        int secondColonIndex = match.Value.IndexOf(':', firstColonIndex + 1);

                        if (firstColonIndex != secondColonIndex - 1) {
                            splitParam1.Text = match.Value.Substring(2, firstColonIndex - 2);

                            if (secondColonIndex > 0) {
                                splitParam2.Text = match.Value.Substring(firstColonIndex + 1, secondColonIndex - firstColonIndex - 1);
                                splitParam3.Text = match.Value.Substring(secondColonIndex + 1);
                            }
                            else {
                                splitParam2.Text = match.Value.Substring(firstColonIndex + 1);
                            }
                        }
                    }
                    else {
                        splitParam1.Text = match.Value.Substring(2);
                    }
                }
            }

            alwaysOnTop.Checked = alwaysOnTopSwitch.IsMatch(options.Text);
            suppressEventHandlers = false;
        }

        /// <summary>
        /// Prevents the user from entering non-digits into a text field.
        /// </summary>
        private void numericTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void autoCopy_CheckedChanged(object sender, EventArgs e) {
            if (suppressEventHandlers) {
                return;
            }
            else if (autoCopy.Checked) {
                if (autoCopySwitch.IsMatch(options.Text)) {
                    options.Text = autoCopySwitch.Replace(options.Text, "/c" + autoCopyDelay.Text);
                }
                else {
                    if (options.Text.Length != 0) {
                        options.Text += " ";
                    }
                    options.Text += "/c" + autoCopyDelay.Text;
                }
            }
            else {
                //Remove the command line switch and trim whitespaces in the resulting string
                options.Text = doubleWhitespace.Replace(autoCopySwitch.Replace(options.Text, ""), " ").Trim();
            }
        }

        private void autoCopyDelay_TextChanged(object sender, EventArgs e) {
            if (!suppressEventHandlers) {
                options.Text = autoCopySwitch.Replace(options.Text, "/c" + autoCopyDelay.Text);
            }
        }

        private void removeRepSymbols_CheckedChanged(object sender, EventArgs e) {
            if (suppressEventHandlers) {
                return;
            }
            else if (removeRepSymbols.Checked) {
                if (removeRepSymbolsSwitch.IsMatch(options.Text)) {
                    options.Text = removeRepSymbolsSwitch.Replace(options.Text, "/ks" + removeRepsCount.Text);
                }
                else {
                    if (options.Text.Length != 0) {
                        options.Text += " ";
                    }
                    options.Text += "/ks" + removeRepsCount.Text;
                }
            }
            else {
                options.Text = doubleWhitespace.Replace(removeRepSymbolsSwitch.Replace(options.Text, ""), " ").Trim();
            }
        }

        private void removeRepsCount_TextChanged(object sender, EventArgs e) {
            if (!suppressEventHandlers) {
                options.Text = removeRepSymbolsSwitch.Replace(options.Text, "/ks" + removeRepsCount.Text);
            }
        }

        private void suppressRepPhrases_CheckedChanged(object sender, EventArgs e) {
            if (suppressEventHandlers) {
                return;
            }
            else if (suppressRepPhrases.Checked) {
                if (suppressRepPhrasesSwitch.IsMatch(options.Text)) {
                    options.Text = suppressRepPhrasesSwitch.Replace(options.Text, "/kf" + traceParam1.Text + ":" + traceParam2.Text);
                }
                else {
                    if (options.Text.Length != 0) {
                        options.Text += " ";
                    }
                    options.Text += "/kf" + traceParam1.Text + ":" + traceParam2.Text;
                }
            }
            else {
                options.Text = doubleWhitespace.Replace(suppressRepPhrasesSwitch.Replace(options.Text, ""), " ").Trim();
            }
        }

        private void traceParam1_TextChanged(object sender, EventArgs e) {
            if (!suppressEventHandlers) {
                options.Text = suppressRepPhrasesSwitch.Replace(options.Text, "/kf" + traceParam1.Text + ":" + traceParam2.Text);
            }
        }

        private void traceParam2_TextChanged(object sender, EventArgs e) {
            if (!suppressEventHandlers) {
                options.Text = suppressRepPhrasesSwitch.Replace(options.Text, "/kf" + traceParam1.Text + ":" + traceParam2.Text);
            }
        }

        private void alwaysOnTop_CheckedChanged(object sender, EventArgs e) {
            if (suppressEventHandlers) {
                return;
            }
            else if (alwaysOnTop.Checked) {
                if (!alwaysOnTopSwitch.IsMatch(options.Text)) {
                    if (options.Text.Length != 0) {
                        options.Text += " ";
                    }
                    options.Text += "/t";
                }
            }
            else {
                options.Text = doubleWhitespace.Replace(alwaysOnTopSwitch.Replace(options.Text, ""), " ").Trim();
            }
        }

        private void updateSplitParams() {
            if (suppressEventHandlers) {
                return;
            }
            else if (splitParamsSwitch.IsMatch(options.Text)) {
                options.Text = splitParamsSwitch.Replace(options.Text, "/b" + splitParam1.Text + ":" + splitParam2.Text + ":" + splitParam3.Text);
            }
            else {
                if (options.Text.Length != 0) {
                    options.Text += " ";
                }
                options.Text += "/b" + splitParam1.Text + ":" + splitParam2.Text + ":" + splitParam3.Text;
            }
        }

        private void splitParam1_TextChanged(object sender, EventArgs e) {
            updateSplitParams();
        }

        private void splitParam2_TextChanged(object sender, EventArgs e) {
            updateSplitParams();
        }

        private void splitParam3_TextChanged(object sender, EventArgs e) {
            updateSplitParams();
        }

        private void okButton_Click(object sender, EventArgs e) {
            game.RunWithAgth = useAgth.Checked;
            game.RunWithChiiTrans = useChiiTrans.Checked;
            game.AgthParameters = options.Text.Trim().ToLower().Replace("/c150", "/c");

            //Check if the user has reset AGTH options to default
            if (game.AgthParameters == GetDefaultAgthOptions().ToLower()) {
                game.AgthParameters = null;

                if (game.RunWithAgth == Settings.Instance.LaunchGamesWithAgth) {
                    game.RunWithAgth = null;
                }
            }

            if (game.RunWithChiiTrans == Settings.Instance.LaunchGamesWithChiiTrans)
            {
                game.RunWithChiiTrans = null;
            }

            game.UseCustomResolution = resolutionList.SelectedIndex != 0;
            game.CustomResolution = resolutionList.SelectedIndex < 2 ? null : supportedResolutions[resolutionList.SelectedIndex - 2];

            game.Save(false);
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void restoreButton_Click(object sender, EventArgs e) {
            if (tabControl.SelectedIndex == 0) {
                useAgth.Checked = Settings.Instance.LaunchGamesWithAgth;
                useChiiTrans.Checked = Settings.Instance.LaunchGamesWithChiiTrans;
                options.Text = GetDefaultAgthOptions();
                ParseAgthParameters();
            }
            else {
                resolutionList.SelectedIndex = 0;
            }
        }

        private void helpButton_Click(object sender, EventArgs e) {
            ShowAgthParameterList(this);
        }

        /// <summary>
        /// Creates and shows a message box containing the AGTH parameter list.
        /// </summary>
        /// <param name="parentWindow">The window that the message box will be centered on. </param>
        public static void ShowAgthParameterList(IWin32Window parentWindow = null) {
            const string title = "AGTH version 2008.11.20 command line help";

            var result = MessageBox.Show(parentWindow, helpMessage1, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            if (result == DialogResult.OK) {
                MessageBox.Show(parentWindow, helpMessage2, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private const string helpMessage1 =
@"Loader options:
/L[locale_id] - fix application locale to 'locale_id' by AppLocale (default parameter: 411)
/R[locale_id] - fix application locale to 'locale_id' (default parameter: 411)
/P[{process_id|Nprocess_name}] - attach to process, invalidates /L, /R keys, 'exe_file_to_load' and 'command_line'

Interface options:
/B[split_mul][:[min_time][:unconditional_split_time]] - set paragraph split parameters (default parameters: 4:24:1000)
/C[time] - copy captured text to clipboard after pause of 'time' milliseconds (default parameter: 150)
/Fnew_name@[context][:subcontext][;new_name2@...] - rename specified and hide all other contexts (default parameters: 0:any)
/KF[len_base][:len_mul] - suppress repetition of phrases, 'len_base' and 'len_mul' are tracing parameters (default parameters: 32:16)
/KS[number] - remove 'number' repetitions of each symbol (default parameter: 1)
/NA - less strict access control for text transfer
/NF - disable filtering of some characters
/NX - toggle auto-exit on close of all hooked processes
/T - always on top
/W[context][:subcontext] - autoselect context (default parameters: 0:any)

Hook options:
/H[X]{A|B|W|S|Q|H}[N][data_offset[*drdo]][:sub_offset[*drso]]@addr[:module[:{name|#ordinal}]] - select OK for more help
/NC - don't hook child processes
/NH - no default hooks
/NJ - use thread code page instead of Shift-JIS for non-unicode text (should be specified for capturing non-japanese text)
/NS - don't use subcontexts
/S[IP_address] - send text to custom computer (default parameter: local computer)
/V - process text threads from system contexts
/X[sets_mask] - extended sets of hooked functions (default parameter: 1; number of available sets: 2)

All numbers in /L, /R, /F, /W, /X, /H (except ordinal) are hexadecimal without any prefixes";

        private const string helpMessage2 =
@"/H[X]{A|B|W|S|Q|H}[N][data_offset[*drdo]][:sub_offset[*drso]]@addr[:module[:{name|#ordinal}]]

Set additional hook

Hook types:
A - DBCS char
B - DBCS char (big-endian)
W - UCS2 char
S - MBCS string
Q - UTF-16 string
H - two bytes in hexadecimal

Parameters:
X - use hardware breakpoints, available on Win2003+ x86 and all x64
N - don't use contexts
data_offset - stack offset to char / string pointer
drdo - add a level of indirection to data_offset
sub_offset - stack offset to subcontext
drso - add a level of indirection to sub_offset
addr - address of the hook
module - name of the module to use as base for 'addr'
name - name of the 'module' export to use as base for 'addr'
ordinal - number of the 'module' export ordinal to use as base for 'addr'

Negative values of 'data_offset' and 'sub_offset' refer to registers:
-4 for EAX, -8 for ECX, -C for EDX, -10 for EBX, -14 for ESP, -18 for EBP, -1C for ESI, -20 for EDI

""Add a level of indirection"" means in C/C++ style: (*(ESP+data_offset)+drdo) insted of (ESP+data_offset)

All numbers except ordinal are hexadecimal without any prefixes";

        private void useAgth_CheckedChanged(object sender, EventArgs e)
        {
            if (useAgth.Checked)
                useChiiTrans.Checked = false;
        }

        private void useChiiTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (useChiiTrans.Checked)
                useAgth.Checked = false;
        }
    }
}
