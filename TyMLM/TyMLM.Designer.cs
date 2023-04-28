using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TyMemoryLeakManager
{
    partial class TyMLM
    {

        public static PrivateFontCollection mFontCollection;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TyMLM));
            this.Category = new System.Windows.Forms.ComboBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.MemUsageLabel = new System.Windows.Forms.Label();
            this.MemUsage = new System.Windows.Forms.Label();
            this.SeverityLabel = new System.Windows.Forms.Label();
            this.Severity = new System.Windows.Forms.Label();
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MemUseBar = new PredictiveProgressBar();
            this.LayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Category
            // 
            this.Category.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Category.FormattingEnabled = true;
            this.Category.Items.AddRange(new object[] {
            "Any%",
            "51TEGS",
            "100%",
            "Max%",
            "Cheat% All Levels",
            "All Golden Cogs",
            "Save The Bilbies",
            "All Rainbow Scales"});
            this.Category.Location = new System.Drawing.Point(3, 23);
            this.Category.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(269, 21);
            this.Category.TabIndex = 1;
            this.Category.SelectedIndexChanged += new System.EventHandler(this.CategoryChanged);
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(3, 3);
            this.CategoryLabel.Margin = new System.Windows.Forms.Padding(3);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(50, 17);
            this.CategoryLabel.TabIndex = 0;
            this.CategoryLabel.Text = "Category";
            this.CategoryLabel.UseCompatibleTextRendering = true;
            // 
            // MemUsageLabel
            // 
            this.MemUsageLabel.AutoSize = true;
            this.MemUsageLabel.Location = new System.Drawing.Point(3, 64);
            this.MemUsageLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.MemUsageLabel.Name = "MemUsageLabel";
            this.MemUsageLabel.Size = new System.Drawing.Size(78, 13);
            this.MemUsageLabel.TabIndex = 2;
            this.MemUsageLabel.Text = "Memory Usage";
            // 
            // MemUsage
            // 
            this.MemUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MemUsage.AutoSize = true;
            this.MemUsage.Location = new System.Drawing.Point(3, 87);
            this.MemUsage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MemUsage.Name = "MemUsage";
            this.MemUsage.Size = new System.Drawing.Size(269, 13);
            this.MemUsage.TabIndex = 3;
            this.MemUsage.Text = "Open Ty";
            this.MemUsage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeverityLabel
            // 
            this.SeverityLabel.AutoSize = true;
            this.SeverityLabel.Location = new System.Drawing.Point(3, 141);
            this.SeverityLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.SeverityLabel.Name = "SeverityLabel";
            this.SeverityLabel.Size = new System.Drawing.Size(45, 13);
            this.SeverityLabel.TabIndex = 5;
            this.SeverityLabel.Text = "Severity";
            // 
            // Severity
            // 
            this.Severity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Severity.AutoSize = true;
            this.Severity.Location = new System.Drawing.Point(130, 164);
            this.Severity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Severity.Name = "Severity";
            this.Severity.Size = new System.Drawing.Size(142, 13);
            this.Severity.TabIndex = 6;
            this.Severity.Text = "Low - !! Full Runs Remaining";
            this.Severity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutPanel.AutoSize = true;
            this.LayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutPanel.Controls.Add(this.CategoryLabel, 0, 0);
            this.LayoutPanel.Controls.Add(this.MemUsageLabel, 0, 2);
            this.LayoutPanel.Controls.Add(this.Severity, 0, 6);
            this.LayoutPanel.Controls.Add(this.Category, 0, 1);
            this.LayoutPanel.Controls.Add(this.SeverityLabel, 0, 5);
            this.LayoutPanel.Controls.Add(this.MemUsage, 0, 3);
            this.LayoutPanel.Controls.Add(this.MemUseBar, 0, 4);
            this.LayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 7;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.Size = new System.Drawing.Size(275, 182);
            this.LayoutPanel.TabIndex = 8;
            // 
            // MemUseBar
            // 
            this.MemUseBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MemUseBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.MemUseBar.Location = new System.Drawing.Point(3, 110);
            this.MemUseBar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MemUseBar.Maximum = 1550;
            this.MemUseBar.MemValue = 200;
            this.MemUseBar.Name = "MemUseBar";
            this.MemUseBar.PredictedColor = System.Drawing.Color.DarkGreen;
            this.MemUseBar.PredictedValue = 1400;
            this.MemUseBar.Size = new System.Drawing.Size(269, 21);
            this.MemUseBar.TabIndex = 4;
            // 
            // TyMLM
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(299, 220);
            this.Controls.Add(this.LayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(315, 0);
            this.Name = "TyMLM";
            this.Text = "TyMLM";
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox Category;
        private Label CategoryLabel;
        private Label MemUsageLabel;
        private Label MemUsage;
        private PredictiveProgressBar MemUseBar;
        private Label SeverityLabel;
        private Label Severity;
        private TableLayoutPanel LayoutPanel;
    }
}

