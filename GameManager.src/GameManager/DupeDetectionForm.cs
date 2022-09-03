using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace GameManager {
    public partial class DupeDetectionForm : Form {
        public int DupeCount { get { return DuplicateGames.GetItemCount(); } }

        private struct Duplicate {
            public Game game1;
            public Game game2;
            public string type;

            public string RJCode { get { return game1.RJCode == null ? "" : game1.RJCode; } }
            public string Title { get { return String.IsNullOrWhiteSpace(game1.Title) ? "" : game1.Title; } }
            public string Reason { get { return "Same " + type + " as " + (game2.RJCode != null ? "[" + game2.RJCode + "]" : "") + game2.Title; } }

            public Duplicate(Game g1, Game g2, string dupeType) {
                game1 = g1;
                game2 = g2;
                type = dupeType;
            }
        };

        public DupeDetectionForm() {
            InitializeComponent();

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }

            var rjCodes = new Dictionary<string, Game>(Game.GetGames().Count);
            var titles = new Dictionary<string, Game>(Game.GetGames().Count, StringComparer.OrdinalIgnoreCase);
            var paths = new Dictionary<string, Game>(Game.GetGames().Count, StringComparer.OrdinalIgnoreCase);
            var dupes = new List<Duplicate>();

            foreach (var game in Game.GetGames()) {
                Game orig = null;
                var codeIsDuped = false;
                var titleIsDuped = false;
                var pathIsDuped = false;

                if (!String.IsNullOrWhiteSpace(game.RJCode)) {
                    if (!rjCodes.ContainsKey(game.RJCode)) {
                        rjCodes.Add(game.RJCode, game);
                    }
                    else {
                        orig = rjCodes[game.RJCode];
                        codeIsDuped = true;
                    }
                }

                if (!String.IsNullOrWhiteSpace(game.Title)) {
                    if (!titles.ContainsKey(game.Title)) {
                        titles.Add(game.Title, game);
                    }
                    else if (orig != null) {
                        titleIsDuped = orig == titles[game.Title];
                    }
                    else {
                        orig = titles[game.Title];
                        titleIsDuped = true;
                    }
                }

                if (!String.IsNullOrWhiteSpace(game.Path)) {
                    if (!paths.ContainsKey(game.Path)) {
                        paths.Add(game.Path, game);
                    }
                    else if (orig != null) {
                        pathIsDuped = orig == paths[game.Path];
                    }
                    else {
                        orig = paths[game.Path];
                        pathIsDuped = true;
                    }
                }

                if (codeIsDuped || titleIsDuped || pathIsDuped) {
                    var type = "";

                    if (codeIsDuped) {
                        type += "code, ";
                    }

                    if (titleIsDuped) {
                        type += "title, ";
                    }

                    if (pathIsDuped) {
                        type += "path, ";
                    }

                    type = type.Substring(0, type.Length - 2);
                    int lastCommaIndex = type.LastIndexOf(',');

                    if (lastCommaIndex > 0) {
                        type = type.Substring(0, lastCommaIndex) + " and" + type.Substring(lastCommaIndex + 1);
                    }

                    dupes.Add(new Duplicate(game, orig, type));
                }
            }

            if (dupes.Count > 0) {
                infoLabel.Text = infoLabel.Text.Replace("0", dupes.Count.ToString());
                DuplicateGames.SetObjects(dupes);
            }
        }

        private void okButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
