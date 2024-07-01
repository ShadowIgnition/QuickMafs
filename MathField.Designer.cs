namespace QuickMafs
{
    partial class MathField
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MathField));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            ExpressionBox = new TextBox();
            AnswerBox = new TextBox();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // ExpressionBox
            // 
            ExpressionBox.Dock = DockStyle.Left;
            ExpressionBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExpressionBox.Location = new Point(0, 0);
            ExpressionBox.Margin = new Padding(0);
            ExpressionBox.MaxLength = 64;
            ExpressionBox.Multiline = true;
            ExpressionBox.Name = "ExpressionBox";
            ExpressionBox.Size = new Size(322, 31);
            ExpressionBox.TabIndex = 1;
            ExpressionBox.WordWrap = false;
            ExpressionBox.TextChanged += ExpressionBox_TextChanged;
            // 
            // AnswerBox
            // 
            AnswerBox.BorderStyle = BorderStyle.FixedSingle;
            AnswerBox.Dock = DockStyle.Right;
            AnswerBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AnswerBox.Location = new Point(298, 0);
            AnswerBox.Margin = new Padding(0);
            AnswerBox.MaxLength = 64;
            AnswerBox.Multiline = true;
            AnswerBox.Name = "AnswerBox";
            AnswerBox.Size = new Size(100, 31);
            AnswerBox.TabIndex = 2;
            AnswerBox.WordWrap = false;
            AnswerBox.Click += AnswerBox_Click;
            // 
            // MathField
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(398, 31);
            ControlBox = false;
            Controls.Add(AnswerBox);
            Controls.Add(ExpressionBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "MathField";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem, hideToolStripMenuItem;
        private TextBox ExpressionBox;
        private TextBox AnswerBox;
    }
}
