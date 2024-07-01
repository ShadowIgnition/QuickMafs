using System.Data;
using System.Resources;

namespace QuickMafs
{

    /// <summary>
    /// Represents a math field form for evaluating mathematical expressions.
    /// </summary>
    public partial class MathField : Form
    {
        /// <summary>
        /// Initializes a new instance of the MathField class.
        /// </summary>
        public MathField()
        {
            m_DataTable = new DataTable();
            StartPosition = FormStartPosition.Manual;
            Visible = false;
            ShowInTaskbar = false;
            ControlBox = false;
            Text = string.Empty;
            MaximizeBox = false;
            MinimizeBox = false;
            m_Screen = null;
            m_Timer = new System.Timers.Timer(TimeSpan.FromMilliseconds(TIMEOUT_TIME));
            m_Timer.Elapsed += HideForm;
            ResetTimer();
        }

        /// <summary>
        /// Handles the form's load event.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            InitializeComponent();
            base.OnLoad(e);
        }

        /// <summary>
        /// Handles the form's shown event.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            ResetTimer();
            base.OnShown(e);
            m_Screen ??= Utils.GetScreen();
            Utils.SetFormPositionNearTray(this, m_Screen);
        }

        /// <summary>
        /// Handles the text changed event of the expression box.
        /// </summary>
        void ExpressionBox_TextChanged(object sender, EventArgs e)
        {
            ResetTimer();
            if (string.IsNullOrEmpty(ExpressionBox.Text))
            {
                AnswerBox.Clear();
                return;
            }

            MathUtils.TryEvaluate(ExpressionBox.Text, m_DataTable, out string text);
            AnswerBox.Text = text;
        }

        /// <summary>
        /// Handles the click event of the answer box.
        /// </summary>
        void AnswerBox_Click(object sender, EventArgs e)
        {
            ResetTimer();
            if (!string.IsNullOrEmpty(AnswerBox.Text))
            {
                Clipboard.SetText(AnswerBox.Text);
                ExpressionBox.Clear();
            }
        }

        void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void HideForm(object sender, EventArgs e)
        {
            // Use Invoke to ensure the form is accessed on the UI thread
            if (InvokeRequired)
            {
                Invoke(Hide);
            }
            else
            {
                Hide();
            }
        }

        void ResetTimer()
        {
            if (m_Timer == null)
            {
                return;
            }

            m_Timer.Stop();
            m_Timer.Start();
        }

        internal static Icon GetIcon()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MathField));
            return (Icon)resources.GetObject("notifyIcon1.Icon");
        }

        const int TIMEOUT_TIME = 10000;
        readonly System.Timers.Timer? m_Timer;
        Screen? m_Screen;
        readonly DataTable m_DataTable;
    }
}